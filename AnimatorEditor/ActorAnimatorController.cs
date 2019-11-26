using System;
using System.Collections;
using System.Collections.Generic;
using EH.Game.Actors;
using EH.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace EH.Animations
{
    public abstract class ActorAnimatorController : MonoBehaviour
    {
        // --- Definitions ---
        public struct BlendFloatInfo
        {
            public string label;
            public Timer timer;
            public float startValue;
            public float destinationValue;

            public BlendFloatInfo(string label, float duration, float startValue, float destinationValue)
            {
                this.label = label;
                this.timer = new Timer(duration);
                this.startValue = startValue;
                this.destinationValue = destinationValue;
            }
        }

        // --- Components/Settings/Variables ---
        [Header("Components")]
        public Animator animator;
        public RuntimeAnimatorController animatorController;

        [Header("Settings")]
        public bool debug = false;

        protected BaseState currentState;
        protected AnimationObject currentAnimation;

        protected List<BlendFloatInfo> blendFloatInfos = new List<BlendFloatInfo>();
        protected bool blendFloatActive = false;

        // General Animation Callback
        protected UnityAction currentAnimationCallback;
        // Modular Animation Callbacks
        protected UnityAction[] currentModularAnimationCallbacks;

        public BaseState CurrentState { get { return currentState; } }
        public AnimationObject CurrentAnimation { get { return currentAnimation; } }

        private void Reset()
        {
            animator = GetComponent<Animator>();
            animatorController = animator != null ? animator.runtimeAnimatorController : null;
        }

        protected void Awake()
        {
            if(animator.runtimeAnimatorController == null)
                animator.runtimeAnimatorController = animatorController;
        }

        public virtual void Initialize()
        {

        }

        protected void FixedUpdate()
        {
            if(blendFloatActive)
                UpdateBlendFloat(Time.fixedDeltaTime);
        }

        public virtual BaseState ChangeState(string state, string substate = "")
        {
            return null;
        }

        public BaseState ChangeState(BaseState state)
        {
            LogFormat("ChangeState from '{0}' to '{1}'", currentState, state);

            if(currentState != null)
                animator.SetBool(currentState.Name, false);

            currentState = state;
            animator.SetBool(currentState.Name, true);

            return state;
        }

        public bool ContainsAnimation(string keyword)
        {
            return currentState.ContainsAnimation(keyword);
        }

        public abstract bool ContainsAnimation(string keyword, ActorAnimatorLayer layer);

        #region Play Animation

        public bool PlayAnimation(AnimationBaseDefinition definition, UnityAction callback = null, bool forceAnimation=false)
        {
            if(currentState == null)
                return false;

            if(!forceAnimation && currentAnimation != null && definition.animationLabel == currentAnimation.label)
            {
                LogFormat("ActorAnimatorController: Try to trigger Animation twice '{0}'", definition.animationLabel);
                return false;
            }

            // --- Search Animation ---
            AnimationObject animationObj = currentState.GetAnimation(definition);

            // --- Play Animation ---
            bool status = false;

            if(animationObj != null && animationObj.clip != null)
                status = PlayAnimation(animationObj, callback, forceAnimation);
            else if(animationObj != null && animationObj.clip == null)
                LogErrorFormat("{0}[{2}] (ActorAnimatorController): AnimationClip is not set '{1}'", name, animationObj.label, currentState.Name);
            else
                LogErrorFormat("{0}[{2}] (ActorAnimatorController): Animation is not found: '{1}'", name, definition.animationLabel, currentState.Name);

            return status;
        }

        public AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            return currentState.GetAnimation(definition);
        }

        public virtual bool PlayModularAnimation(string label, ActorAnimatorLayer layer, string subState, UnityAction callback=null)
        {
            throw new NotImplementedException();
        }

        public virtual void StopModularAnimation(ActorAnimatorLayer layer, string subState)
        {
            throw new NotImplementedException();
        }

        protected bool PlayAnimation(AnimationObject animation, UnityAction callback = null, bool forceAnimation = false)
        {
            if(animation == null)
                return false;

            if(!forceAnimation && currentAnimation != null && animation == currentAnimation)
            {
                LogFormat("{0}[{2}] (ActorAnimatorController): Try to trigger Animation twice '{1}'", name, animation.label, currentState.Name);

                return false;
            }

            LogFormat("{0} (ActorAnimatorController): Play Animation '{1}' ({2})", name, animation.label, animation.clip.name);
            animator.SetTrigger(animation.label);
            currentAnimation = animation;
            currentAnimationCallback = callback;

            return true;
        }

        public void OnAnimationEnd()
        {
            if(currentAnimationCallback != null)
            {
                UnityAction unityAction = currentAnimationCallback.Clone() as UnityAction;
                currentAnimationCallback = null;
                unityAction.Raise();
            }
        }

        public void OnModularAnimationEnd(string layerName)
        {
            //Debug.Log("OnModularAnimationEnd");
            int modularCallbackIndex = -1;
            string _layerName = "";

            if(currentModularAnimationCallbacks.Length == 1)
            {
                if(animator.GetLayerIndex(string.Format("{0} Layer", layerName)) > 0)
                    modularCallbackIndex = 0;
            }
            else
            {
                for(int i = 0; i < currentModularAnimationCallbacks.Length; i++)
                {
                    _layerName = Enum.GetName(typeof(ActorAnimatorLayer), (ActorAnimatorLayer)(i+1));

                    if(layerName == _layerName)
                    {
                        modularCallbackIndex = i;
                        break;
                    }  
                }
            }

            if(modularCallbackIndex == -1 || modularCallbackIndex >= currentModularAnimationCallbacks.Length)
            {
                LogErrorFormat("OnModularAnimationEnd: Called layerIndex ({0}) that is bigger than layers on the model", modularCallbackIndex);
                return;
            }

            currentModularAnimationCallbacks[modularCallbackIndex].Raise();
            currentModularAnimationCallbacks[modularCallbackIndex] = null;
        }

        public void SetTrigger(string label)
        {
            LogFormat(string.Format("SetTrigger: {0}", label));
            animator.SetTrigger(label);
        }

        public void ResetTrigger(string label)
        {
            //LogFormat(string.Format("ResetTrigger: {0}", label));
            animator.ResetTrigger(label);
        }

        public void SetFloat(string label, float value)
        {
            //LogFormat(string.Format("SetFloat: {0} ({1})", label, value));
            animator.SetFloat(label, value);
        }

        public float GetFloat(string label)
        {
            return animator.GetFloat(label);
        }

        public void SetBool(string label, bool active)
        {
            //LogFormat(string.Format("SetBool: {0} ({1})", label, active));
            animator.SetBool(label, active);
        }

        public bool GetBool(string label)
        {
            return animator.GetBool(label);
        }

        #endregion

        #region BlendTree Methods

        public void StartBlendFloat(string label, float destinationValue, float duration)
        {
            int infoIndex = 0;
            bool found = false;

            for(int i = 0; i < blendFloatInfos.Count; i++)
            {
                if(label == blendFloatInfos[i].label)
                {
                    infoIndex = i;
                    found = true;

                    if(Mathf.Abs(destinationValue - blendFloatInfos[i].destinationValue) < 0.01f)
                        return;
                }
            }

            if(found) // --- Existing ---
                blendFloatInfos.RemoveAt(infoIndex);

            // --- Create new Blend ---
            BlendFloatInfo info = new BlendFloatInfo(label, duration, animator.GetFloat(label), destinationValue);
            blendFloatInfos.Add(info);
            blendFloatActive = true;
        }

        protected virtual void UpdateBlendFloat(float dt)
        {
            List<BlendFloatInfo> finishedBlends = new List<BlendFloatInfo>();

            for(int i = 0; i < blendFloatInfos.Count; i++)
            {
                BlendFloatInfo info = blendFloatInfos[i];
                SetFloat(info.label, Mathf.Lerp(info.startValue, info.destinationValue, 1f - info.timer.percentage));

                if(info.timer.Update(dt))
                    finishedBlends.Add(info);
            }

            for(int x = 0; x < finishedBlends.Count; x++)
                blendFloatInfos.Remove(finishedBlends[x]);

            if(blendFloatInfos.Count == 0)
                StopBlendFloat();
        }

        public void StopBlendFloat()
        {
            blendFloatActive = false;
        }

        #endregion

        #region Blend

        public virtual int GetBlendValue(AnimationBaseDefinition definition)
        {
            return currentState.GetBlendValue(definition);
        }

        #endregion

        #region Editor Messages

        protected void LogErrorFormat(string message, params object[] args)
        {
            if(debug)
                Debug.LogErrorFormat(gameObject, message, args);
        }

        protected void LogFormat(string message, params object[] args)
        {
            if(debug)
                Debug.LogFormat(gameObject, message, args);
        }

        protected abstract bool IsModularStateExisting(ActorAnimatorLayer layer, string subState, out ModularBaseState modularState, out int layerIndex);

        #endregion
    }
}