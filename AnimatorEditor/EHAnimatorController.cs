using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EH.Animations
{
    public class EHAnimatorController : ActorAnimatorController 
    {
        [Header("Categories")]
        public EHGeneralState generalState;
        public CrouchState crouchState;
        public CollectStateCollection collectStates;
        public TreasureChestState treasureChestState;
        public CaughtStateCollection caughtStates;
        public ClimbState climbState;

        public OpenCloseStateCollection openCloseStates;
        public HideInsideStateCollection hideInsideStates;
        public PushPullStateCollection pushPullStates;
        public ThrowStateCollection throwStates;

        public EHKidStateCollection kidStates;
        public CheckpointStateCollection checkpointStates;
        //public TransitionStateCollection transitionStates;
        public CheekyStateCollection cheakyStates;

        public BirdViewState birdViewState;
        public MinecartState minecartState;
        public SwitchState switchState;
        public BalanceState balanceState;

        [Header("Modular Categories")]
        public EHModularTorsoStateCollection torsoLayerStates;

        public override void Initialize()
        {
            ChangeState(generalState);
            PlayAnimation(generalState.idle[0]);

            currentModularAnimationCallbacks = new UnityEngine.Events.UnityAction[1];
        }

        public override BaseState ChangeState(string state, string substate="")
        {
            BaseState animatorState = null;

            switch(state)
            {
                case ActorAnimatorStates.GeneralState:
                    animatorState = ChangeState(generalState);
                    break;
                case ActorAnimatorStates.CrouchState:
                    animatorState = ChangeState(crouchState);
                    break;
                case ActorAnimatorStates.CollectStates:
                    BaseState collectState = collectStates.GetSubstate(substate);
                    if(collectState != null)
                        animatorState = ChangeState(collectState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);
                    break;
                case ActorAnimatorStates.TreasureChest:
                    animatorState = ChangeState(treasureChestState);
                    break;
                case ActorAnimatorStates.CaughtStates:
                    BaseState caughtState = caughtStates.GetSubstate(substate);
                    if(caughtState != null)
                        animatorState = ChangeState(caughtState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);
                    break;
                case ActorAnimatorStates.ClimbState:
                    animatorState = ChangeState(climbState);
                    break;
                case ActorAnimatorStates.OpenCloseStates:
                    BaseState doorState = openCloseStates.GetSubstate(substate);
                    if(doorState != null)
                        animatorState = ChangeState(doorState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);
                    
                    break;
                case ActorAnimatorStates.HideInsideStates:
                    BaseState hidingState = hideInsideStates.GetSubstate(substate);
                    if(hidingState != null)
                        animatorState = ChangeState(hidingState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);
                    
                    break;
                case ActorAnimatorStates.PushPullStates:
                    BaseState pushingState = pushPullStates.GetSubstate(substate);
                    if(pushingState != null)
                        animatorState = ChangeState(pushingState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);
                    
                    break;
                case ActorAnimatorStates.ThrowStates:
                    BaseState throwingState = throwStates.GetSubstate(substate);
                    if(throwingState != null)
                        animatorState = ChangeState(throwingState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);
                    
                    break;
                case ActorAnimatorStates.KidStates:
                    BaseState kidState = kidStates.GetSubstate(substate);
                    if(kidState != null)
                        animatorState = ChangeState(kidState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);

                    break;
                case ActorAnimatorStates.CheckpointStates:
                    BaseState checkpointState = checkpointStates.GetSubstate(substate);
                    if(checkpointState != null)
                        animatorState = ChangeState(checkpointState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);

                    break;
                case ActorAnimatorStates.CheekyStates:
                    BaseState cheakyState = cheakyStates.GetSubstate(substate);
                    if(cheakyState != null)
                        animatorState = ChangeState(cheakyState);
                    else
                        Debug.LogErrorFormat("EHAnimatorController: substate '{0}' not found", substate);

                    break;
                case ActorAnimatorStates.BirdViewState:
                    animatorState = ChangeState(birdViewState);
                    break;
                case ActorAnimatorStates.MinecartState:
                    animatorState = ChangeState(minecartState);
                    break;
                case ActorAnimatorStates.SwitchState:
                    animatorState = ChangeState(switchState);
                    break;
                case ActorAnimatorStates.BalanceState:
                    animatorState = ChangeState(balanceState);
                    break;
                default:
                    Debug.LogErrorFormat("EHAnimatorController: state '{0}' not found", state);
                    break;
            }

            return animatorState;
        }

        #region Modular Animations

        public override bool PlayModularAnimation(string label, ActorAnimatorLayer layer, string subState, UnityAction callback = null)
        {
            AnimationObject animationObj = null;
            AnimationBaseDefinition definition = new AnimationBaseDefinition(label);
            ModularBaseState modularState = null;
            int layerIndex = -1;
            bool status = false;

            if(!IsModularStateExisting(layer, subState, out modularState, out layerIndex))
            {
                LogErrorFormat("{0}[{2}] (ActorAnimatorController): ModularLayer not found '{1}'.", name, layer, currentState.Name);
                return status;
            }

            // Get Animation
            animationObj = modularState.GetAnimation(definition);

            // --- Play Animation ---
            if(animationObj != null && animationObj.clip != null)
            {
                LogFormat("{0} (ActorAnimatorController): Play Modular Animation: '{1}'", name, animationObj.label);

                // Set Animation
                animator.SetBool(modularState.Name, true);
                animator.SetTrigger(animationObj.label); // Play Animation

                // FadeIn LayerWeight
                float layerWeight = animator.GetLayerWeight(layerIndex);

                if(layerWeight < 1f)
                {
                    if(modularState.fadeInDuration > 0f)
                        StartCoroutine(BlendLayer(layerIndex, animator.GetLayerWeight(layerIndex), 1f, modularState.fadeInDuration));
                    else
                        animator.SetLayerWeight(layerIndex, 1f);
                }

                status = true;

                // Set Callback
                currentModularAnimationCallbacks[0] = callback; // layerIndex - 1
            }
            else
            {
                LogErrorFormat("{0}[{2}] (ActorAnimatorController): ModularAnimationClip is not set '{1}'. Reset weight to '0'.", name, label, currentState.Name);
                animator.SetTrigger(string.Format("{0}_Reset", modularState.Name));
                animator.SetBool(modularState.Name, false);

                // Reset LayerWeight
                animator.SetLayerWeight(layerIndex, 0f);
            }

            return status;
        }

        public override void StopModularAnimation(ActorAnimatorLayer layer, string subState)
        {
            ModularBaseState modularState = null;
            int layerIndex = -1;

            if(IsModularStateExisting(layer, subState, out modularState, out layerIndex))
            {
                animator.SetTrigger(string.Format("{0}_Reset", modularState.Name));
                animator.SetBool(modularState.Name, false);

                // FadeIn LayerWeight
                if(modularState.fadeOutDuration > 0f)
                    StartCoroutine(BlendLayer(layerIndex, animator.GetLayerWeight(layerIndex), 0f, modularState.fadeOutDuration));
                else
                    animator.SetLayerWeight(layerIndex, 0f);
            }
            else
            {
                LogErrorFormat("{0}[{2}] (ActorAnimatorController): ModularLayer not found '{1}'.", name, layer, currentState.Name);
            }
        }

        private IEnumerator BlendLayer(int layerIndex, float from, float to, float time)
        {
            float progression = 0f;
            float step = 1f / time;
            //float duration = Time.time;
            //Debug.LogFormat("Blend Layer: Start {0} to {1}", from, to);

            while(progression < 1f)
            {
                yield return new WaitForEndOfFrame();
                animator.SetLayerWeight(layerIndex, Mathf.Lerp(from, to, progression));
                progression += step * Time.deltaTime;
            }

            animator.SetLayerWeight(layerIndex, to);

            //duration = Time.time - duration;
            //Debug.LogFormat("Blend Layer: Complete {0}sek", duration);
        }

        protected override bool IsModularStateExisting(ActorAnimatorLayer layer, string subState, out ModularBaseState modularState, out int layerIndex)
        {
            layerIndex = -1;
            modularState = null;

            switch(layer)
            {
                case ActorAnimatorLayer.Torso:
                    modularState = torsoLayerStates.GetSubstate(subState);
                    layerIndex = animator.GetLayerIndex(torsoLayerStates.Layer);
                    break;
                default:
                    break;
            }

            return (layerIndex > -1) && (modularState != null);
        }

        public override bool ContainsAnimation(string keyword, ActorAnimatorLayer layer)
        {
            bool status = false;

            switch(layer)
            {
                case ActorAnimatorLayer.Base:
                    status = currentState.ContainsAnimation(keyword);
                    break;
                case ActorAnimatorLayer.Torso:
                    status = torsoLayerStates.ContainsAnimation(keyword);
                    break;
                default:
                    break;
            }

            return status;
        }

        #endregion
    }
}