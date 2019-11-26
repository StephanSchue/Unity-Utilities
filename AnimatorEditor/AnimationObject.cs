using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EH.Animations
{
    #region Animation Layer & ID Enumerators

    // --- Modular Animation Layers ---
    public enum ActorAnimatorLayer
    {
        Base,
        Head,
        ArmLeft,
        Torso
    }

    // --- Animation Identifier ---
    public enum PushPullAnimationID
    {
        PushPull_01 = 1,
        PushPull_02 = 2,
        PushPull_03 = 3
    }

    public enum CollectAnimationID
    {
        Collect_01 = 0,
        Collect_02 = 1,
        Collect_10 = 9, // WindupToy
        Collect_20 = 19, // PoisenCactus + Fireworks
        Collect_30 = 29, // Sombrero
        Collect_40 = 39 // Shoes
    }

    public enum ThrowAnimationID
    {
        Throw_01 = 1,
        Throw_02 = 2,
        Throw_03 = 3,
        Throw_10 = 4,
        Throw_20 = 5,
        Throw_30 = 6
    }

    public enum HideInsideAnimationID
    {
        HideInside_01 = 1,
        HideInside_02 = 2,
        HideInside_03 = 3,
        HideInside_04 = 4,
        HideInside_05 = 5,
        HideInside_06 = 6,
        HideInside_07 = 7,
        HideInside_08 = 8,
        HideInside_09 = 9,
        HideInside_10 = 10,
        HideInside_11 = 11,
        HideInside_12 = 12,
        HideInside_13 = 13,
        HideInside_14 = 14,
        HideInside_15 = 15,
        HideInside_16 = 16,
        HideInside_17 = 17,
        HideInside_18 = 18,
        HideInside_19 = 19,
        HideInside_20 = 20,
        HideInside_21 = 21,
        HideInside_22 = 22,
        HideInside_23 = 23,
        HideInside_24 = 24,
        HideInside_25 = 25,
        HideInside_26 = 26,
        HideInside_27 = 27,
        HideInside_28 = 28,
        HideInside_29 = 29,
        HideInside_30 = 30,
        HideInside_100 = 100 // Sombrero
    }

    public enum ButtonAnimationID
    {
        General = -1,
        OpenClose_00 = 0,
        Collect = 1,
        Checkpoint = 2,
        Transition = 3,
        Cheeky = 4,
        Switch = 5
    }

    public enum SwingAnimationID
    {
        Swing_01,
        Swing_02
    }

    public enum ObjectInteractionID
    {
        Interaction_01,
        Interaction_02,
        Interaction_03
    }

    public enum HangAnimationID
    {
        Hang_01,
        Hang_02
    }

    public enum CarryAnimationID
    {
        Carry_B01,
        Carry_B02,
        Carry_B03,
        Carry_S01
    }

    public enum InvestigateToyID
    {
        InvestigateToy_01
    }

    public enum SitAnimationID
    {
        Sit_01,
        Sit_02,
        Sit_03,
        Sit_04,
        Sit_05
    }

    public enum OpenCloseAnimationID
    {
        OpenClose_00 = 0,
        OpenClose_01 = 1
    }

    public enum HoldAnimationID
    {
        General,
        Hold_01,
        Hold_02,
        Hold_03,
        Bear_01
    }

    public enum HoldAnchorID
    {
        None = -1,
        Arm_Left_01 = 0,
        Small_01 = 10,
        Small_02 = 11,
        Small_03 = 12,
        Small_04 = 13,
        Long_01 = 20,
        Long_02 = 21,
        Long_03 = 22,
        Long_04 = 23,
        Long_05 = 24,
        Long_06 = 25
    }

    public enum TorsoID
    {
        Small_01 = 10,
        Small_02 = 11,
        Small_03 = 12,
        Small_04 = 13,
        Long_01 = 20,
        Long_02 = 21,
        Long_03 = 22,
        Long_04 = 23,
        Long_05 = 24,
        Long_06 = 25
    }

    public enum KidStateID
    {
        Kid_01,
        Kid_02,
        Kid_03,
        Kid_04,
        Kid_05,
        Kid_06,
        Kid_07,
        Kid_08,
        Kid_09,
        Kid_10,
        Kid_11,
        Kid_12,
        Kid_13,
        Kid_14,
        Kid_15,
        Kid_16,
        Kid_17,
        Kid_18,
        Kid_19,
        Kid_20,
        Kid_21,
        Kid_22,
        Kid_23,
        Kid_24,
        Kid_25,
        Kid_26,
        Kid_27,
        Kid_28,
        Kid_29,
        Kid_30,
        Kid_31,
        Kid_32,
        kid_33,
        Kid_34,
        Kid_35,
        Kid_36,
        Kid_37,
        Kid_38,
        Kid_39,
        Kid_40,
        Kid_41,
        Kid_42,
        Kid_43,
        Kid_44,
        Kid_45,
        Kid_46,
        Kid_47,
        Kid_48,
        Kid_49,
        Kid_50,
        Kid_99 = 98,
        Kid_100 = 99,
        Kid_101,
        Kid_102,
        Kid_103,
        Kid_104,
        Kid_105,
        Kid_106,
        Kid_107,
        Kid_108,
        Kid_109,
        Kid_110,
        Kid_111,
        Kid_112,
        Kid_113,
        Kid_114,
        Kid_115,
        Kid_116,
        Kid_117,
        Kid_118,
        Kid_119,
    }

    public enum CheckpointAnimationID
    {
        Checkpoint_01,
        Checkpoint_02,
        Checkpoint_03,
        Checkpoint_04,
        Checkpoint_05,
        Checkpoint_06,
        Checkpoint_07,
        Checkpoint_08,
        Checkpoint_09,
        Checkpoint_10
    }

    public enum TransitionAnimationID
    {
        Start,
        End
    }

    public enum CheekyAnimationID
    {
        Cheeky_01,
        Cheeky_02,
        Cheeky_03,
        Cheeky_04,
        Cheeky_05,
        Cheeky_06,
        Cheeky_07,
        Cheeky_08,
        Cheeky_09,
        Cheeky_10
    }

    #endregion

    #region Animation Objects

    // --- Animation Objects ----
    [System.Serializable]
    public class AnimationObject
    {
        public string label;
        public AnimationClip clip;
        public string destination;
    }

    [System.Serializable]
    public class AnimationProximityObject : AnimationObject
    {
        public EH.Game.Actors.Actor.ProximityLevel proximity;
    }

    [System.Serializable]
    public class AnimationTurnObject
    {
        public AnimationObject clockwise;
        public AnimationObject counterclockwise;

        public AnimationObject GetAnimation(bool clockwise)
        {
            return clockwise ? this.clockwise : this.counterclockwise;
        }
    }

    [System.Serializable]
    public class NPCAnimationTurnObject
    {
        public NPCAnimationObject general;
        public NPCAnimationObject clockwise;
        public NPCAnimationObject counterclockwise;

        public AnimationObject GetAnimation(bool clockwise)
        {
            return clockwise ? this.clockwise : this.counterclockwise;
        }
    }

    [System.Serializable]
    public class NPCAnimationObject : AnimationObject
    {
        public bool rotateLOS = true;
    }

    [System.Serializable]
    public class KidAnimationObject : AnimationObject
    {
        public EH.Game.Actors.Kid.AccessoryID accessoryID;
    }

    [System.Serializable]
    public class NPCConversationAnimationObject : NPCAnimationObject
    {
        public bool active = true;
    }

    [System.Serializable]
    public class AnimationCrouchObject
    {
        public AnimationObject left;
        public AnimationObject right;

        public AnimationObject GetAnimation(bool left)
        {
            // TODO: Use Direction for desition
            return left ? this.left : this.right;
        }
    }

    [System.Serializable]
    public class AnimationOpenCloseObject
    {
        public AnimationCloseObject left;
        public AnimationCloseObject right;

        public AnimationObject GetAnimation(bool forward, bool left)
        {
            return left ? this.left.GetAnimation(forward) : this.right.GetAnimation(forward);
        }
    }

    [System.Serializable]
    public class AnimationCloseObject
    {
        public AnimationObject pull;
        public AnimationObject swing;

        public AnimationObject GetAnimation(bool swing)
        {
            return swing ? this.swing : this.pull;
        }
    }

    [System.Serializable]
    public class AnimationPushPullObject
    {
        public AnimationObject pull;
        public AnimationObject push;

        public AnimationObject GetAnimation(bool forward)
        {
            return forward ? push : pull;
        }
    }

    [System.Serializable]
    public class AnimationClimbAttachObject
    {
        public AnimationObject attach;
        public AnimationObject idle;

        public AnimationObject GetAnimation(bool attach)
        {
            if(attach)
                return this.attach;
            else
                return this.idle;
        }
    }

    [System.Serializable]
    public class AnimationClimbStepObject
    {
        public AnimationObject left;
        public AnimationObject right;

        public AnimationObject GetAnimation(bool left)
        {
            return left ? this.left : this.right;
        }
    }

    #endregion

    #region Definitions

    // --- AnimationDefinitions ---
    public class AnimationBaseDefinition
    {
        public string animationLabel;

        public AnimationBaseDefinition(string animationLabel)
        {
            this.animationLabel = animationLabel;
        }
    }

    public class AnimationCategoryGeneralDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationCategoryGeneralDefinition(string category, string animationLabel) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationNPCCarryDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationNPCCarryDefinition(string category, string animationLabel) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationNPCInvestigateDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationNPCInvestigateDefinition(string category, string animationLabel) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationNPCChaseDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationNPCChaseDefinition(string category, string animationLabel) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationInspectDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationInspectDefinition(string category, string animationLabel) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationProximityDefinition : AnimationBaseDefinition
    {
        public EH.Game.Actors.Actor.ProximityLevel proximityLevel;

        public AnimationProximityDefinition(string animationLabel, EH.Game.Actors.Actor.ProximityLevel proximityLevel) : base(animationLabel)
        {
            this.proximityLevel = proximityLevel;
        }
    }

    public class AnimationCrouchDefinition : AnimationBaseDefinition
    {
        public bool left;

        public AnimationCrouchDefinition(string animationLabel, bool left) : base(animationLabel)
        {
            this.left = left;
        }
    }

    public class AnimationOpenCloseDefinition : AnimationBaseDefinition
    {
        public string category;
        public bool forward;
        public bool left;

        public AnimationOpenCloseDefinition(string animationLabel, string category, bool forward, bool left) : base(animationLabel)
        {
            this.category = category;
            this.forward = forward;
            this.left = left;
        }
    }

    public class AnimationPushPullDefinition : AnimationBaseDefinition
    {
        public bool forward;
        public string category;
        public bool moving;

        public AnimationPushPullDefinition(bool forward, string category, bool moving) : base("")
        {
            this.forward = forward;
            this.animationLabel = this.forward ? ActorAnimationStateNames.Push : ActorAnimationStateNames.Pull;
            this.category = category;
            this.moving = moving;
        }
    }

    public class AnimationClimbAttachDefinition : AnimationBaseDefinition
    {
        public bool top;

        public AnimationClimbAttachDefinition(string animationLabel, bool top) : base(animationLabel)
        {
            this.top = top;
        }
    }

    public class AnimationClimbStepDefinition : AnimationBaseDefinition
    {
        public bool up;
        public bool left;

        public AnimationClimbStepDefinition(string animationLabel, bool up, bool left) : base(animationLabel)
        {
            this.up = up;
            this.left = left;
        }
    }

    public class AnimationCaugtDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationCaugtDefinition(string animationLabel, string category) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationCollectDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationCollectDefinition(string animationLabel, string category) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationHideInsideDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationHideInsideDefinition(string animationLabel, string category) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationThrowDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationThrowDefinition(string animationLabel, string category) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationModularArmDefinition : AnimationBaseDefinition
    {
        public string category;

        public AnimationModularArmDefinition(string animationLabel, string category) : base(animationLabel)
        {
            this.category = category;
        }
    }

    public class AnimationInteractionDefinition : AnimationBaseDefinition
    {
        public int levelIndex;

        public AnimationInteractionDefinition(string animationLabel, int levelIndex) : base(animationLabel)
        {
            this.levelIndex = levelIndex;
        }
    }

    #endregion

    #region Base States

    // --- States ---
    [System.Serializable]
    public abstract class BaseState
    {
        public virtual string Name { get { return "BaseState"; } }
        public abstract List<AnimationObject> GetAnimations();
        public virtual bool blendTree { get { return false; } }

        public struct BlendTree1DInfo
        {
            public string parameter;
            public SortedList<string, AnimationObject[]> blocks;

            public BlendTree1DInfo(string parameter, SortedList<string, AnimationObject[]> blocks)
            {
                this.parameter = parameter;
                this.blocks = blocks;
            }
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public virtual AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            foreach(AnimationObject animation in GetAnimations())
            {
                if(definition.animationLabel == animation.label)
                    return animation;
            }

            return null;
        }

        public virtual bool ContainsAnimation(string keyword)
        {
            foreach(AnimationObject animation in GetAnimations())
            {
                if(keyword == animation.label && animation.clip != null)
                    return true;
            }

            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);
            return false;
        }

        public virtual BlendTree1DInfo GetBlendTree()
        {
            return new BlendTree1DInfo();
        }

        public virtual int GetBlendValue(AnimationBaseDefinition definition)
        {
            return 0;
        }

        protected int GetBlendValue(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return i;
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return 0;
        }
    }

    [System.Serializable]
    public abstract class BaseStateCollection : BaseState
    {
        public BaseState[] states;
        public virtual BaseState[] States { get { return states; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            for(int x = 0; x < states.Length; x++)
            {
                animations.AddRange(states[x].GetAnimations());
            }

            return animations;
        }

        public virtual BaseState GetSubstate(string label)
        {
            for(int i = 0; i < States.Length; i++)
            {
                if(States[i].Name == label)
                    return States[i];
            }

            //Debug.LogErrorFormat("AnimationState: SubState with label '{0}' was not found.", label);
            return null;
        }
    }

    [System.Serializable]
    public class ModularBaseState : BaseState
    {
        public string name = "";

        [Header("FadeIn/Out")]
        public float fadeInDuration = 0;
        public float fadeOutDuration = 0;

        public virtual string Layer { get { return "None"; } }

        public override List<AnimationObject> GetAnimations()
        {
            throw new System.NotImplementedException();
        }
    }

    [System.Serializable]
    public abstract class ModularStateCollection : BaseStateCollection
    {
        public virtual string Layer { get { return "None"; } }
    }

    #endregion

    #region El Hijo

    [System.Serializable]
    public class EHGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public AnimationProximityObject[] idle;
        public AnimationProximityObject[] walk;
        public AnimationObject[] reactions;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            //animations.AddRange(idle);
            //animations.AddRange(walk);
            animations.AddRange(reactions);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationProximityDefinition poximityDefinition = definition as AnimationProximityDefinition;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    if(poximityDefinition != null)
                        animationObject = GetAnimationByProximityLevel(idle, poximityDefinition.proximityLevel);
                    else
                        animationObject = idle[0];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk[0];
                    break;
                case ActorAnimationStateNames.Run:
                    if(poximityDefinition != null)
                        animationObject = GetAnimationByProximityLevel(walk, poximityDefinition.proximityLevel, 1);
                    else
                        animationObject = walk[1];
                    break;
                case ActorAnimationStateNames.ReactionCliff:
                    animationObject = reactions[0];
                    break;
                case ActorAnimationStateNames.ReactionCollision:
                    animationObject = reactions[1];
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        /// <summary>
        /// Gets the animation by proximity level.
        /// If there is no animation with the set poximitylevel, the first animation of the row will be used
        /// </summary>
        /// <returns>The animation of a array "AnimationProximityObject".</returns>
        /// <param name="animations">Animations.</param>
        /// <param name="proximityLevel">Proximity level.</param>
        private AnimationObject GetAnimationByProximityLevel(AnimationProximityObject[] animations, EH.Game.Actors.Actor.ProximityLevel proximityLevel, int defaultIndex = 0)
        {
            AnimationObject animationObject = animations[defaultIndex];

            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].proximity == proximityLevel)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class CollectStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.CollectStates; } }
        public new CollectState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCollectDefinition caughtDefinition = definition as AnimationCollectDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(caughtDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class CollectState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Collect_01";
        public AnimationObject start;
        public AnimationObject pickup;
        public AnimationObject store;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(start);
            animations.Add(pickup);
            animations.Add(store);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Start:
                    animationObject = start;
                    break;
                case ActorAnimationStateNames.Pickup:
                    animationObject = pickup;
                    break;
                case ActorAnimationStateNames.Store:
                    animationObject = store;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class TreasureChestState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.TreasureChest; } }
        public AnimationObject open;
        public AnimationObject grab;
        public AnimationObject showEnter;
        public AnimationObject showIdle;
        public AnimationObject showExit;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(open);
            animations.Add(grab);
            animations.Add(showEnter);
            animations.Add(showIdle);
            animations.Add(showExit);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Open:
                    animationObject = open;
                    break;
                case ActorAnimationStateNames.Pickup:
                    animationObject = grab;
                    break;
                case ActorAnimationStateNames.Treasure_ShowEnter:
                    animationObject = showEnter;
                    break;
                case ActorAnimationStateNames.Treasure_ShowIdle:
                    animationObject = showIdle;
                    break;
                case ActorAnimationStateNames.Treasure_ShowExit:
                    animationObject = showExit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class CrouchState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.CrouchState; } }
        public AnimationCrouchObject idle;
        public AnimationCrouchObject walk;
        public AnimationCrouchObject turn;
        public AnimationCrouchObject turnCorner;

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCrouchDefinition crouchDefinition = definition as AnimationCrouchDefinition;

            if(crouchDefinition != null)
            {
                switch(crouchDefinition.animationLabel)
                {
                    case ActorAnimationStateNames.Idle:
                        animationObject = idle.GetAnimation(crouchDefinition.left);
                        break;
                    case ActorAnimationStateNames.Walk:
                        animationObject = walk.GetAnimation(crouchDefinition.left);
                        break;
                    case ActorAnimationStateNames.Turn:
                        animationObject = turn != null ? turn.GetAnimation(crouchDefinition.left) : null;
                        break;
                    case ActorAnimationStateNames.TurnCorner:
                        animationObject = turnCorner.GetAnimation(crouchDefinition.left);
                        break;
                    default:
                        //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                        break;
                }
            }
            else
            {
                Debug.LogWarningFormat("Animation: Call 'CrouchState' without Crouch-Definition.");
            }

            return animationObject;
        }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(idle.left);
            animations.Add(idle.right);
            animations.Add(walk.left);
            animations.Add(walk.right);
            animations.Add(turn.left);
            animations.Add(turn.right);
            animations.Add(turnCorner.left);
            animations.Add(turnCorner.right);
            return animations;
        }
    }

    [System.Serializable]
    public class CaughtStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.CaughtStates; } }
        public new CaughtState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCaugtDefinition caughtDefinition = definition as AnimationCaugtDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(caughtDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class CaughtState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Caught_00";
        public AnimationObject stop;
        public AnimationObject inspect;
        public AnimationObject surrender;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(stop);
            animations.Add(inspect);
            animations.Add(surrender);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition generalDefinition = definition as AnimationCategoryGeneralDefinition;

            if(definition.animationLabel == ActorAnimationStateNames.Stop || (generalDefinition != null && generalDefinition.category == ActorAnimationStateNames.Stop))
                animationObject = stop;
            else if(definition.animationLabel == ActorAnimationStateNames.Inspect)
                animationObject = inspect;
            else if(definition.animationLabel == ActorAnimationStateNames.Surrender)
                animationObject = surrender;
            //else
            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' ({1}) was not found.", definition.animationLabel, Name);

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);

            return (animations.Length > 0) ? animations[0] : null;
        }
    }

    [System.Serializable]
    public class GeneralAnimationState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "General";
        public AnimationObject animation;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(animation);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            if(definition.animationLabel == animation.label)
                animationObject = animation;
            //else
            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);

            return animationObject;
        }

        public AnimationObject GetAnimation()
        {
            return animation;
        }
    }

    [System.Serializable]
    public class ClimbState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.ClimbState; } }
        public AnimationClimbAttachObject getOnTop;
        public AnimationClimbAttachObject getOnBottom;
        public AnimationObject getOffTop;
        public AnimationObject getOffBottom;
        public AnimationClimbStepObject stepUp;
        public AnimationClimbStepObject stepDown;
        public AnimationClimbStepObject idleUp;
        public AnimationClimbStepObject idleDown;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(getOnTop.attach);
            animations.Add(getOnTop.idle);
            animations.Add(getOnBottom.attach);
            animations.Add(getOnBottom.idle);

            animations.Add(getOffTop);
            animations.Add(getOffBottom);

            animations.Add(stepUp.left);
            animations.Add(stepUp.right);
            animations.Add(stepDown.left);
            animations.Add(stepDown.right);

            animations.Add(idleUp.left);
            animations.Add(idleUp.right);
            animations.Add(idleDown.left);
            animations.Add(idleDown.right);

            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            if(definition is AnimationClimbAttachDefinition)
            {
                AnimationClimbAttachDefinition attachDefinition = definition as AnimationClimbAttachDefinition;

                if(attachDefinition.animationLabel == EH.ActorAnimationStateNames.GetOn)
                {
                    // GetOn
                    if(attachDefinition.top)
                        animationObject = getOnTop.GetAnimation(true);
                    else
                        animationObject = getOnBottom.GetAnimation(true);
                }
                else if(attachDefinition.animationLabel == EH.ActorAnimationStateNames.GetOff)
                {
                    // GetOff
                    if(attachDefinition.top)
                        animationObject = getOffTop;
                    else
                        animationObject = getOffBottom;
                }
            }
            else if(definition is AnimationClimbStepDefinition)
            {
                AnimationClimbStepDefinition stepDefinition = definition as AnimationClimbStepDefinition;

                if(stepDefinition.animationLabel == EH.ActorAnimationStateNames.Idle)
                {
                    if(stepDefinition.up)
                        animationObject = idleUp.GetAnimation(stepDefinition.left);
                    else
                        animationObject = idleDown.GetAnimation(stepDefinition.left);
                }
                else if(stepDefinition.animationLabel == ActorAnimationStateNames.Step)
                {
                    if(stepDefinition.up)
                        animationObject = stepUp.GetAnimation(stepDefinition.left);
                    else
                        animationObject = stepDown.GetAnimation(stepDefinition.left);
                }
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class OpenCloseStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.OpenCloseStates; } }
        public GeneralAnimationState generalOpen;
        public new OpenCloseTwoSidesState[] states;
        //public OpenCloseOneSideState door_02; 

        public override BaseState[] States
        {
            get
            {
                List<BaseState> allStates = new List<BaseState>();
                allStates.AddRange(states);
                allStates.Add(generalOpen);
                return allStates.ToArray();
            }
        } //new BaseState[2] {door_01, door_02}; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationOpenCloseDefinition doorDefinition = definition as AnimationOpenCloseDefinition;

            for(int i = 0; i < States.Length; i++)
            {
                if(doorDefinition.category == States[i].Name)
                {
                    if(States[i] is GeneralAnimationState) // Play the general Open Animation
                        return (States[i] as GeneralAnimationState).GetAnimation();
                    else
                        return states[i].GetAnimation(definition);
                }
            }

            return null;
        }
    }

    [System.Serializable]
    public class OpenCloseTwoSidesState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "DoorState_01";
        public AnimationPushPullObject open;
        public AnimationOpenCloseObject close;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(open.push);
            animations.Add(open.pull);
            animations.Add(close.left.pull);
            animations.Add(close.left.swing);
            animations.Add(close.right.pull);
            animations.Add(close.right.swing);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationOpenCloseDefinition doorDefinition = definition as AnimationOpenCloseDefinition;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Open:
                    animationObject = doorDefinition != null ? open.GetAnimation(doorDefinition.forward) : open.push;
                    break;
                case ActorAnimationStateNames.Close:
                    animationObject = doorDefinition != null ? close.GetAnimation(doorDefinition.forward, doorDefinition.left) : close.left.pull;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class OpenCloseOneSideState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "DoorState_01";
        public AnimationObject open;
        public AnimationObject close;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(open);
            animations.Add(close);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationOpenCloseDefinition doorDefinition = definition as AnimationOpenCloseDefinition;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Open:
                    animationObject = open;
                    break;
                case ActorAnimationStateNames.Close:
                    animationObject = close;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class HideInsideStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.HideInsideStates; } }
        public new HidInsideState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationHideInsideDefinition hideoutDefinition = definition as AnimationHideInsideDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(hideoutDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class HidInsideState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "HideInside_01";
        public AnimationObject enter;
        public AnimationObject idle;
        public AnimationObject exit;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class PushPullStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.PushPullStates; } }
        public new PushPullState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationPushPullDefinition pushDefinition = definition as AnimationPushPullDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(pushDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            //Debug.LogErrorFormat("PushingAnimationState: Animation-Category with label '{0}' was not found.", pushDefinition.category);
            return null;
        }
    }

    [System.Serializable]
    public class PushPullState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "PushPull_01";
        public AnimationPushPullObject idle;
        public AnimationPushPullObject walk;

        public override bool blendTree => true;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.Add(idle.pull);
                animations.Add(idle.push);
                animations.Add(walk.pull);
                animations.Add(walk.push);
            }

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationPushPullDefinition pushDefinition = definition as AnimationPushPullDefinition;

            if(pushDefinition != null)
            {
                if(pushDefinition.moving)
                    animationObject = walk.GetAnimation(pushDefinition.forward);
                else
                    animationObject = idle.GetAnimation(pushDefinition.forward);
            }

            return animationObject;
        }

        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("PushPull", new AnimationObject[] { walk.pull, walk.push });
            return new BlendTree1DInfo("PushPull_Mode", blendTreeBlocks);
        }
    }

    [System.Serializable]
    public class ThrowStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.ThrowStates; } }
        public new ThrowState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationThrowDefinition hideoutDefinition = definition as AnimationThrowDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(hideoutDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class ThrowState : BaseState
    {
        public override string Name => name;
        public string name = "Throw_01";
        public AnimationObject take;
        // this contains all the animations needed for the aiming blendTree
        public AnimationObject[] aiming;
        public AnimationObject shoot;
        public AnimationObject cancel;

        public override bool blendTree => true;

        public override BlendTree1DInfo GetBlendTree()
        {
            var blendTreeBlocks = new SortedList<string, AnimationObject[]>
            {
                {"Aiming", aiming}
            };
            return new BlendTree1DInfo("Aiming", blendTreeBlocks);
        }

        public override List<AnimationObject> GetAnimations() =>
            new List<AnimationObject> { take, shoot, cancel };

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Take:
                    animationObject = take;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = aiming[0];
                    break;
                case ActorAnimationStateNames.Shoot:
                    animationObject = shoot;
                    break;
                case ActorAnimationStateNames.Cancel:
                    animationObject = cancel;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    // --- Kids ---

    [System.Serializable]
    public class EHKidStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.KidStates; } }
        public new EHKidState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            for(int i = 0; i < states.Length; i++)
                animations.AddRange(states[i].GetAnimations());

            return animations;
        }
    }

    [System.Serializable]
    public class EHKidState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Kid_Interact_01";
        public EH.Game.Actors.Player.AccessoryID accessoryID;

        public AnimationObject interaction;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(interaction);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Interact:
                    animationObject = interaction;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    // --- Checkpoints ---
    [System.Serializable]
    public class CheckpointStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.CheckpointStates; } }
        public new CheckpointState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            for(int i = 0; i < states.Length; i++)
            {
                if(definition.animationLabel == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class CheckpointState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Checkpoint_01";
        public AnimationObject activate;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(activate);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Activate:
                    animationObject = activate;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class BirdViewState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.BirdViewState; } }
        public AnimationObject enter;
        public AnimationObject idle;
        public AnimationObject exit;

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            return animations;
        }
    }

    [System.Serializable]
    public class BirdViewModularState : ModularBaseState
    {
        public override string Name { get { return ActorAnimatorStates.BirdViewModularState; } }
        public AnimationObject enter;
        public AnimationObject idle;
        public AnimationObject exit;

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            return animations;
        }
    }

    // --- Transitions ---
    [System.Serializable]
    public class TransitionStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.TransitionStates; } }
        public new TransitionState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            for(int i = 0; i < states.Length; i++)
            {
                if(definition.animationLabel == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class TransitionState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Transition_01";
        public AnimationObject start;
        public AnimationObject end;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(start);
            animations.Add(end);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Start:
                    animationObject = start;
                    break;
                case ActorAnimationStateNames.End:
                    animationObject = end;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    // --- Transitions ---
    [System.Serializable]
    public class CheekyStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.CheekyStates; } }
        public new CheekyState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            for(int i = 0; i < states.Length; i++)
            {
                if(definition.animationLabel == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class CheekyState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Cheeky_01";
        public AnimationObject[] clips;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.AddRange(clips);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            for(int i = 0; i < clips.Length; i++)
            {
                if(clips[i].label == definition.animationLabel)
                    return clips[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);   
            return null;
        }
    }

    [System.Serializable]
    public class MinecartState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.MinecartState; } }
        public AnimationObject enter;
        public AnimationObject idle;
        public AnimationObject pump;
        public AnimationObject exit;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(pump);
            animations.Add(exit);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Push:
                    animationObject = pump;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class SwitchState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.SwitchState; } }
        public AnimationObject left;
        public AnimationObject right;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(left);
            animations.Add(right);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Left:
                    animationObject = left;
                    break;
                case ActorAnimationStateNames.Right:
                    animationObject = right;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class BalanceState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.BalanceState; } }
        public AnimationObject idle;
        public AnimationObject walk;
        public AnimationObject turn;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.Add(idle);
                animations.Add(walk);
            }

            animations.Add(turn);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("", new AnimationObject[] { idle, walk });
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }
    }

    [System.Serializable]
    public class VaultState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.VaultState; } }
        public AnimationObject interact;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(interact);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Interact:
                    animationObject = interact;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class JumpState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.JumpState; } }
        public AnimationObject interact;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(interact);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Interact:
                    animationObject = interact;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class SwingStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.SwingStates; } }
        public new SwingState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            for(int i = 0; i < states.Length; i++)
            {
                if(definition.animationLabel == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class SwingState : BaseState
    {
        public override string Name { get { return name; } }
        public string name;
        public AnimationObject getOnTop;
        public AnimationObject getOffTop;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(getOnTop);
            animations.Add(getOffTop);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.GetOn:
                    animationObject = getOnTop;
                    break;
                case ActorAnimationStateNames.GetOff:
                    animationObject = getOffTop;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class KickState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.KickState; } }
        public AnimationObject interact;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(interact);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Interact:
                    animationObject = interact;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class HangStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.HangStates; } }
        public new HangState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            for(int i = 0; i < states.Length; i++)
            {
                if(definition.animationLabel == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class HangState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "";
        public AnimationObject getOnTop;
        public AnimationObject getOffTop;
        public AnimationObject idle;
        public AnimationCrouchObject climb;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(getOnTop);
            animations.Add(getOffTop);
            animations.Add(idle);
            animations.Add(climb.left);
            animations.Add(climb.right);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.GetOn:
                    animationObject = getOnTop;
                    break;
                case ActorAnimationStateNames.GetOff:
                    animationObject = getOffTop;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Left:
                    animationObject = climb.left;
                    break;
                case ActorAnimationStateNames.Right:
                    animationObject = climb.right;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    #endregion

    #region Kid States

    [System.Serializable]
    public class KidGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public NPCAnimationObject[] idles;
        public NPCAnimationObject walk;
        public NPCAnimationObject run;
        public NPCAnimationTurnObject turn;
        public NPCAnimationTurnObject scan;

        public override bool blendTree => true;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.AddRange(idles);
                animations.Add(walk);
                animations.Add(run);
            }

            animations.Add(turn.general);
            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);
            animations.Add(scan.clockwise);
            animations.Add(scan.counterclockwise);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            string category = definition is AnimationCategoryGeneralDefinition ? (definition as AnimationCategoryGeneralDefinition).category : definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, definition.animationLabel);
                    break;
                case "Idles":
                    animationObject = GetAnimation(idles, definition.animationLabel);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Run:
                    animationObject = run;
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.ScanCW:
                    animationObject = scan.clockwise;
                    break;
                case ActorAnimationStateNames.ScanCCW:
                    animationObject = scan.counterclockwise;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);

            return (animations.Length > 0) ? animations[0] : null;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[0];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Run:
                    animationObject = run;
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.ScanCW:
                    animationObject = scan.clockwise;
                    break;
                case ActorAnimationStateNames.ScanCCW:
                    animationObject = scan.counterclockwise;
                    break;
                default:
                    break;
            }

            //if (animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", new AnimationObject[] { walk, run });
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(npcDefinition.category)
            {
                case ActorAnimationStateNames.Idle:
                    return GetBlendValue(idles, npcDefinition.animationLabel);
                case ActorAnimationStateNames.Walk:
                    return 0;
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class KidState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Kid_01";
        public KidAnimationObject[] animations;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> _animations = new List<AnimationObject>();
            _animations.AddRange(animations);
            return _animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(npcDefinition.category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(animations, npcDefinition.animationLabel);
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = GetAnimation(animations, keyword);

            //if (animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string label)
        {
            AnimationObject animationObject = null;

            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == label)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class KidReactionStateCollection : BaseStateCollection
    {
        public override string Name { get { return name; } }
        public string name = "KidEHReactionStates";
        public new KidNPCReactionState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(npcDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class KidNPCReactionState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Kid_01";
        public NPCAnimationObject reaction;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(reaction);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            string animationLabel = definition.animationLabel;

            switch(animationLabel)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                default:
                    break;
            }

            //if (animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }
    }

    // --- Modular Animations ---

    // -- Torso --
    [System.Serializable]
    public class EHModularTorsoStateCollection : ModularStateCollection
    {
        public override string Name { get { return name; } }
        public string name = "ModularTorso";
        public override string Layer { get { return layer; } }
        private string layer = "Torso Layer";

        public BirdViewModularState birdViewModularState;

        public override BaseState[] States { get { return GetStates(); } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationModularArmDefinition modularDefinition = definition as AnimationModularArmDefinition;

            if(modularDefinition.category == birdViewModularState.Name)
                return birdViewModularState.GetAnimation(definition);

            return null;
        }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            for(int x = 0; x < States.Length; x++)
            {
                animations.AddRange(States[x].GetAnimations());
            }

            return animations;
        }

        public ModularBaseState[] GetStates()
        {
            List<ModularBaseState> _states = new List<ModularBaseState>();
            _states.Add(birdViewModularState);
            return _states.ToArray();
        }

        public ModularBaseState GetSubstate(string label)
        {
            ModularBaseState[] _states = GetStates();

            for(int i = 0; i < _states.Length; i++)
            {
                if(_states[i].Name.Contains(label))
                    return _states[i];
            }

            //Debug.LogErrorFormat("AnimationState: SubState with label '{0}' was not found.", label);
            return null;
        }
    }

    #endregion

    #region NPC States

    // --- NPC States ---
    [System.Serializable]
    public class NPCGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public NPCAnimationObject[] idles;
        public NPCAnimationObject[] walks;
        public NPCAnimationTurnObject turn;
        public NPCAnimationTurnObject scan;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.AddRange(idles);
                animations.AddRange(walks);
            }

            animations.Add(turn.general);
            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);
            animations.Add(scan.clockwise);
            animations.Add(scan.counterclockwise);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;
            string animationLabel = definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, animationLabel);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = GetAnimation(walks, animationLabel);
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.ScanCW:
                    animationObject = scan.clockwise;
                    break;
                case ActorAnimationStateNames.ScanCCW:
                    animationObject = scan.counterclockwise;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[0];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walks[0];
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.ScanCW:
                    animationObject = scan.clockwise;
                    break;
                case ActorAnimationStateNames.ScanCCW:
                    animationObject = scan.counterclockwise;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }


        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", walks);
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(npcDefinition.category)
            {
                case ActorAnimationStateNames.Idle:
                    return GetBlendValue(idles, npcDefinition.animationLabel);
                case ActorAnimationStateNames.Walk:
                    return GetBlendValue(walks, npcDefinition.animationLabel);
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class NPCHoldStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.HoldStates; } }
        public new NPCHoldState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(npcDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCHoldState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Hold_01";
        public NPCAnimationObject idle;
        public NPCAnimationObject walk;
        public NPCAnimationTurnObject turn;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.Add(idle);
                animations.Add(walk);
            }

            animations.Add(turn.general);
            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);

            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;
            string animationLabel = definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                default:
                    break;
            }

            if(animationObject == null || animationObject.clip == null)
                Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("", new AnimationObject[] { idle, walk });
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }
    }

    [System.Serializable]
    public class NPCBearStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.BearStates; } }
        public new NPCBearState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(npcDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCBearState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Hold_01";
        public NPCAnimationObject enter;
        public NPCAnimationObject exit;
        public NPCAnimationObject[] idles;
        public NPCAnimationObject[] walks;
        public NPCAnimationTurnObject turn;
        public NPCAnimationObject reactionInvestigate;
        public NPCAnimationObject reactionChase;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(exit);

            if(!blendTree)
            {
                animations.AddRange(idles);
                animations.AddRange(walks);
            }

            animations.Add(turn.general);
            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);
            animations.Add(reactionInvestigate);
            animations.Add(reactionChase);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;
            string animationLabel = definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, animationLabel);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = GetAnimation(walks, animationLabel);
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.Reaction_Investigate:
                    animationObject = reactionInvestigate;
                    break;
                case ActorAnimationStateNames.Reaction_Chase:
                    animationObject = reactionChase;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, keyword);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = GetAnimation(walks, keyword);
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.Reaction_Investigate:
                    animationObject = reactionInvestigate;
                    break;
                case ActorAnimationStateNames.Reaction_Chase:
                    animationObject = reactionChase;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", walks);
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(npcDefinition.category)
            {
                case ActorAnimationStateNames.Idle:
                    return GetBlendValue(idles, npcDefinition.animationLabel);
                case ActorAnimationStateNames.Walk:
                    return GetBlendValue(walks, npcDefinition.animationLabel);
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class NPCSitStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.SitStates; } }
        public new NPCSitState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition carryDefinition = definition as AnimationCategoryGeneralDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(carryDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCSitState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Sit_01";
        public NPCAnimationObject enter;
        public NPCAnimationObject idle;
        public NPCAnimationObject exit;
        public NPCAnimationObject reactionInvestigate;
        public NPCAnimationObject reactionChase;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            animations.Add(reactionInvestigate);
            animations.Add(reactionChase);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;
            string label = npcDefinition != null ? npcDefinition.category : definition.animationLabel;

            switch(label)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                case ActorAnimationStateNames.Reaction_Investigate:
                    animationObject = reactionInvestigate;
                    break;
                case ActorAnimationStateNames.Reaction_Chase:
                    animationObject = reactionChase;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return null;
        }
    }

    [System.Serializable]
    public class NPCSleepState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.SleepState; } }
        public NPCAnimationObject idle;
        public NPCAnimationObject chaseReaction;
        public NPCAnimationObject chaseGiveUp;
        public NPCAnimationObject catching;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(idle);
            animations.Add(chaseReaction);
            animations.Add(chaseGiveUp);
            animations.Add(catching);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Sleep_Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Reaction:
                    animationObject = chaseReaction;
                    break;
                case ActorAnimationStateNames.GiveUp:
                    animationObject = chaseGiveUp;
                    break;
                case ActorAnimationStateNames.Catch:
                    animationObject = catching;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return null;
        }
    }

    [System.Serializable]
    public class NPCCarryStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.CarryStates; } }
        public new NPCCarryState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationNPCCarryDefinition carryDefinition = definition as AnimationNPCCarryDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(carryDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCCarryState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Carrying_01";

        public NPCAnimationObject enter;
        public NPCAnimationObject[] idles;
        public NPCAnimationObject[] walks;
        public NPCAnimationTurnObject turn;
        public NPCAnimationObject exit;
        public NPCAnimationObject drop;
        public NPCAnimationObject reactionInvestigate;
        public NPCAnimationObject reactionChase;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);

            if(!blendTree)
            {
                animations.AddRange(idles);
                animations.AddRange(walks);
            }

            animations.Add(turn.general);
            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);
            animations.Add(exit);
            animations.Add(drop);
            animations.Add(reactionInvestigate);
            animations.Add(reactionChase);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationNPCCarryDefinition npcDefinition = definition as AnimationNPCCarryDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;

            //if(npcDefinition == null)
            //{
            //    Debug.LogError("Animation can't be casted: " + definition.animationLabel);
            //    return null;
            //}

            switch(category)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, npcDefinition.animationLabel);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = GetAnimation(walks, npcDefinition.animationLabel);
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                case ActorAnimationStateNames.Drop:
                    animationObject = drop;
                    break;
                case ActorAnimationStateNames.Reaction_Investigate:
                    animationObject = reactionInvestigate;
                    break;
                case ActorAnimationStateNames.Reaction_Chase:
                    animationObject = reactionChase;
                    break;
                default:
                    //Debug.LogErrorFormat("NPCCarryState (AnimationState): Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogWarningFormat("AnimationState: Animation with label '{0}' was not found. Fallback to default", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, keyword);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = GetAnimation(walks, keyword);
                    break;
                case ActorAnimationStateNames.Turn:
                    animationObject = turn.general;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                case ActorAnimationStateNames.Drop:
                    animationObject = drop;
                    break;
                case ActorAnimationStateNames.Reaction_Investigate:
                    animationObject = reactionInvestigate;
                    break;
                case ActorAnimationStateNames.Reaction_Chase:
                    animationObject = reactionChase;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", walks);
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(npcDefinition.category)
            {
                case ActorAnimationStateNames.Idle:
                    return GetBlendValue(idles, npcDefinition.animationLabel);
                case ActorAnimationStateNames.Walk:
                    return GetBlendValue(walks, npcDefinition.animationLabel);
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class NPCInvestigateStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.InvestigateStates; } }
        public new NPCInvestigateState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationNPCInvestigateDefinition investigateDefinition = definition as AnimationNPCInvestigateDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(investigateDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCInvestigateState : BaseState
    {
        public override string Name { get { return name; } }
        public string name;
        public NPCAnimationObject reaction;
        public NPCAnimationObject walk;
        public NPCAnimationObject lookAround;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(reaction);
            animations.Add(walk);
            animations.Add(lookAround);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.LookAround:
                    animationObject = lookAround;
                    break;
                default:
                    //Debug.LogErrorFormat("InvestigateState (AnimationState): Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class NPCChaseStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.ChaseStates; } }
        public new NPCChaseState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationNPCChaseDefinition chaseDefinition = definition as AnimationNPCChaseDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(chaseDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class InteractionState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.InteractionState; } }

        [Header("Animations")]
        public NPCAnimationObject[] animations;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> anims = new List<AnimationObject>();
            anims.AddRange(animations);
            return anims;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            for(int i = 0; i < animations.Length; i++)
            {
                if(definition.animationLabel == animations[i].label)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class NPCCallState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.CallState; } }

        [Header("Animations")]
        public NPCAnimationObject[] animations;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> anims = new List<AnimationObject>();
            anims.AddRange(animations);
            return anims;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            for(int i = 0; i < animations.Length; i++)
            {
                if(definition.animationLabel == animations[i].label)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class NPCChaseState : BaseState
    {
        public override string Name { get { return name; } }
        public string name;
        public NPCAnimationObject reaction;
        public NPCAnimationObject walk;
        public NPCAnimationObject giveup;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(reaction);
            animations.Add(walk);
            animations.Add(giveup);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationProximityDefinition poximityDefinition = definition as AnimationProximityDefinition;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.GiveUp:
                    animationObject = giveup;
                    break;
                default:
                    //Debug.LogErrorFormat("ChaseState (AnimationState): Animation with label '{0}' was not found. ({1})", definition.animationLabel, definition.GetType());
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class NPCInspectStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.InspectStates; } }
        public new NPCInspectState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationInspectDefinition inspectDefinition = definition as AnimationInspectDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(inspectDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCInspectState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "";
        public NPCAnimationObject walk;
        public NPCAnimationObject inspect;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(walk);
            animations.Add(inspect);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationProximityDefinition poximityDefinition = definition as AnimationProximityDefinition;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Inspect:
                    animationObject = inspect;
                    break;
                default:
                    //Debug.LogErrorFormat("InspectState (AnimationState): Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class NPCCatchStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.CatchStates; } }
        public new NPCCatchState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationCaugtDefinition catchDefinition = definition as AnimationCaugtDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(catchDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCCatchState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Catch_00";
        public NPCAnimationObject stepBack; // -> Catch_StepBack(for cases like Inspect & Catch_01 - 07 + Catch_50) [Animation in Place] 
        public NPCAnimationObject alert;    // -> Catch_Alert(pull out & shoot)
        public NPCAnimationObject[] point;    // -> Catch_Point(BlendTree -> Aim, BlendTree, Bottom, Center, Top)

        public override bool blendTree => (point.Length > 0);

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(stepBack);
            animations.Add(alert);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.StepBack:
                    animationObject = stepBack;
                    break;
                case ActorAnimationStateNames.Alert:
                    animationObject = alert;
                    break;
                case ActorAnimationStateNames.Point:
                    animationObject = point.Length > 0 ? point[point.Length > 1 ? 1 : 0] : null;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Point", point);
            return new BlendTree1DInfo("Point", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Point:
                    return GetBlendValue(point, npcDefinition.animationLabel);
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class NPCInterchangeState : ModularBaseState
    {
        public override string Name { get { return name; } }

        [Header("Animations")]
        public NPCConversationAnimationObject[] animations;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> anims = new List<AnimationObject>();
            anims.AddRange(animations);
            return anims;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            for(int i = 0; i < animations.Length; i++)
            {
                if(definition.animationLabel == animations[i].label)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class NPCKidStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.KidStates; } }
        public new NPCKidState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            for(int i = 0; i < states.Length; i++)
                animations.AddRange(states[i].GetAnimations());

            return animations;
        }
    }

    [System.Serializable]
    public class NPCKidState : BaseState
    {
        public override string Name { get { return name; } }
        public string name = "Kid_Interact_01";
        public EH.Game.Actors.NPC.AccessoryID accessoryID;
        public AnimationObject interaction;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(interaction);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Interact:
                    animationObject = interaction;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    // --- Fireworks ---
    [System.Serializable]
    public class NPCFireworkState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.FireworkState; } }
        public NPCAnimationObject enter;
        public NPCAnimationObject idle;
        public NPCAnimationObject exit;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("FireworkState (AnimationState): Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    #endregion

    #region Modular Animations 

    // --- Head ---
    [System.Serializable]
    public class NPCModularHeadStateCollection : ModularStateCollection
    {
        public override string Name { get { return name; } }
        public string name = "ModularHead";
        public override string Layer { get { return layer; } }
        private string layer = "Head Layer";

        public override BaseState[] States { get { return GetStates(); } }

        public ModularHeadScanState scanState;
        public NPCInterchangeState interchangeActions;
        public NPCInterchangeState interchangeReactions;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            for(int x = 0; x < States.Length; x++)
            {
                animations.AddRange(States[x].GetAnimations());
            }

            return animations;
        }

        public ModularBaseState[] GetStates()
        {
            List<ModularBaseState> _states = new List<ModularBaseState>();
            _states.Add(scanState);
            _states.Add(interchangeActions);
            _states.Add(interchangeReactions);
            return _states.ToArray();
        }

        public ModularBaseState GetSubstate(string label)
        {
            ModularBaseState[] _states = GetStates();

            for(int i = 0; i < _states.Length; i++)
            {
                if(_states[i].Name.Contains(label))
                    return _states[i];
            }

            //Debug.LogErrorFormat("AnimationState: SubState with label '{0}' was not found.", label);
            return null;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    break;
                case ActorAnimationStateNames.ScanCW:
                    animationObject = scanState.GetAnimation(definition);
                    break;
                case ActorAnimationStateNames.ScanCCW:
                    animationObject = scanState.GetAnimation(definition);
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class ModularHeadScanState : ModularBaseState
    {
        public override string Name { get { return name; } }

        [Header("Animations")]
        public AnimationObject scanCW;
        public AnimationObject scanCCW;
        public AnimationObject reset;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(scanCW);
            animations.Add(scanCCW);
            animations.Add(reset);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.ScanCW:
                    animationObject = scanCW;
                    break;
                case ActorAnimationStateNames.ScanCCW:
                    animationObject = scanCCW;
                    break;
                case ActorAnimationStateNames.Reset:
                    animationObject = reset;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    // --- Left Arm ---
    [System.Serializable]
    public class NPCModularArmLeftState : ModularBaseState
    {
        public override string Name { get { return name; } }

        public override string Layer { get { return layer; } }
        private string layer = "Arm Left Layer";

        [Header("Animations")]
        public AnimationObject enter;
        public AnimationObject idle;
        public AnimationObject exit;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    // --- Torso ---
    [System.Serializable]
    public class NPCModularTorsoStateCollection : ModularStateCollection
    {
        public override string Name { get { return name; } }
        public string name = "ModularTorso";
        public override string Layer { get { return layer; } }
        private string layer = "Torso Layer";

        public ModularTrosoSmallState[] smallStates;
        public ModularTorsoLongState[] longStates;
        public NPCInterchangeState interchangeActions;
        public NPCInterchangeState interchangeReactions;

        public override BaseState[] States { get { return GetStates(); } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationModularArmDefinition armDefinition = definition as AnimationModularArmDefinition;

            for(int i = 0; i < smallStates.Length; i++)
            {
                if(armDefinition.category == smallStates[i].Name)
                    return smallStates[i].GetAnimation(definition);
            }

            return null;
        }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            for(int x = 0; x < States.Length; x++)
            {
                animations.AddRange(States[x].GetAnimations());
            }

            return animations;
        }

        public ModularBaseState[] GetStates()
        {
            List<ModularBaseState> _states = new List<ModularBaseState>();
            _states.AddRange(smallStates);
            _states.AddRange(longStates);
            _states.Add(interchangeActions);
            _states.Add(interchangeReactions);
            return _states.ToArray();
        }

        public ModularBaseState GetSubstate(string label)
        {
            ModularBaseState[] _states = GetStates();

            for(int i = 0; i < _states.Length; i++)
            {
                if(_states[i].Name.Contains(label))
                    return _states[i];
            }

            //Debug.LogErrorFormat("AnimationState: SubState with label '{0}' was not found.", label);
            return null;
        }
    }

    [System.Serializable]
    public class ModularTrosoSmallState : ModularBaseState
    {
        public override string Name { get { return name; } }

        [Header("Animations")]
        public AnimationObject enter;
        public AnimationObject idle;
        public AnimationObject exit;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(enter);
            animations.Add(idle);
            animations.Add(exit);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Enter:
                    animationObject = enter;
                    break;
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Exit:
                    animationObject = exit;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    [System.Serializable]
    public class ModularTorsoLongState : ModularBaseState
    {
        public override string Name { get { return name; } }

        [Header("Animations")]
        public AnimationObject idle;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(idle);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    #endregion

    #region Buffalo

    [System.Serializable]
    public class BuffaloGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public AnimationObject[] idles;
        public AnimationObject walk;
        public AnimationObject run;
        public AnimationTurnObject turn;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.AddRange(idles);
                animations.Add(walk);
                animations.Add(run);
            }

            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcGeneralDefinition = definition as AnimationCategoryGeneralDefinition;
            string category = npcGeneralDefinition != null ? npcGeneralDefinition.category : definition.animationLabel;
            string animationLabel = npcGeneralDefinition != null ? npcGeneralDefinition.animationLabel : "";

            switch(category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, animationLabel);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Run:
                    animationObject = run;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[0];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Run:
                    animationObject = run;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", new AnimationObject[] { walk, run });
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    return Random.Range(0, idles.Length);
                case ActorAnimationStateNames.Walk:
                    return 0;
                default:
                    break;
            }

            return 0;
        }
    }

    #endregion

    #region Crow

    [System.Serializable]
    public class CrowGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public AnimationObject idle;
        public AnimationObject fly;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(idle);
            animations.Add(fly);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = fly;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = fly;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }
    }

    #endregion

    #region Coyote

    [System.Serializable]
    public class CoyoteGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public AnimationObject idle;
        public AnimationObject walk;
        public AnimationTurnObject turn;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.Add(idle);
                animations.Add(walk);
            }

            animations.Add(turn.clockwise);
            animations.Add(turn.counterclockwise);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idle;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.TurnCW:
                    animationObject = turn.clockwise;
                    break;
                case ActorAnimationStateNames.TurnCCW:
                    animationObject = turn.counterclockwise;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("", new AnimationObject[] { idle, walk });
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }
    }

    #endregion

    #region Chicken

    [System.Serializable]
    public class ChickenGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public AnimationObject[] idles;
        public AnimationObject walk;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(blendTree)
            {
                animations.AddRange(idles);
                animations.Add(walk);
            }

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[Random.Range(0, idles.Length)];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[0];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", new AnimationObject[] { walk });
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Idle:
                    return Random.Range(0, idles.Length);
                case ActorAnimationStateNames.Walk:
                    return 0;
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class ChickenEscapeState : BaseState
    {
        public override string Name => ActorAnimatorStates.EscapeState;
        public AnimationObject reaction;
        public AnimationObject run;

        public override List<AnimationObject> GetAnimations() => new List<AnimationObject> { reaction, run };

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                case ActorAnimationStateNames.Run:
                    animationObject = run;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                case ActorAnimationStateNames.Run:
                    animationObject = run;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }
    }

    // --- Sheriff ---
    [System.Serializable]
    public class SheriffGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public NPCAnimationObject[] idles;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.AddRange(idles);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;
            string animationLabel = definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, animationLabel);
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[0];
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }
    }

    #endregion

    #region Toy Investigate Categories

    [System.Serializable]
    public class NPCToyInvestigateStateCollection : BaseStateCollection
    {
        public override string Name { get { return ActorAnimatorStates.InvestigateToyStates; } }
        public new NPCToyInvestigateState[] states;
        public override BaseState[] States { get { return this.states; } }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationNPCInvestigateDefinition investigateDefinition = definition as AnimationNPCInvestigateDefinition;

            for(int i = 0; i < states.Length; i++)
            {
                if(investigateDefinition.category == states[i].Name)
                    return states[i].GetAnimation(definition);
            }

            return null;
        }
    }

    [System.Serializable]
    public class NPCToyInvestigateState : BaseState
    {
        public override string Name { get { return name; } }
        public string name;
        public NPCAnimationObject reaction;
        public NPCAnimationObject walk;
        public NPCAnimationObject anticipation;
        public NPCAnimationObject destroy;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(reaction);
            animations.Add(walk);
            animations.Add(anticipation);
            animations.Add(destroy);
            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Reaction:
                    animationObject = reaction;
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walk;
                    break;
                case ActorAnimationStateNames.Anticipation:
                    animationObject = anticipation;
                    break;
                case ActorAnimationStateNames.Destroy:
                    animationObject = destroy;
                    break;
                default:
                    //Debug.LogErrorFormat("InvestigateState (AnimationState): Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }
    }

    #endregion

    #region Mother

    [System.Serializable]
    public class MotherGeneralState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.GeneralState; } }
        public NPCAnimationObject[] idles;
        public NPCAnimationObject[] walks;
        public NPCAnimationObject[] reactions;

        public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            if(!blendTree)
            {
                animations.AddRange(idles);
                animations.AddRange(walks);
            }

            animations.AddRange(reactions);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;
            string animationLabel = definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = GetAnimation(idles, animationLabel);
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = GetAnimation(walks, animationLabel);
                    break;
                case ActorAnimationStateNames.ReactionCliff:
                    animationObject = reactions[0];
                    break;
                case ActorAnimationStateNames.ReactionCollision:
                    animationObject = reactions[1];
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.Idle:
                    animationObject = idles[0];
                    break;
                case ActorAnimationStateNames.Walk:
                    animationObject = walks[0];
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }


        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            return new BlendTree1DInfo();

            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            blendTreeBlocks.Add("Idles", idles);
            blendTreeBlocks.Add("Walks", walks);
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            switch(npcDefinition.category)
            {
                case ActorAnimationStateNames.Idle:
                    return GetBlendValue(idles, npcDefinition.animationLabel);
                case ActorAnimationStateNames.Walk:
                    return GetBlendValue(walks, npcDefinition.animationLabel);
                default:
                    break;
            }

            return 0;
        }
    }

    [System.Serializable]
    public class MotherOpenCloseState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.OpenCloseStates; } }
        public AnimationObject open;

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();
            animations.Add(open);
            return animations;
        }

        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            switch(definition.animationLabel)
            {
                case ActorAnimationStateNames.Open:
                    animationObject = open;
                    break;
                default:
                    break;
            }

            return animationObject;
        }

        public AnimationObject GetAnimation()
        {
            return open;
        }
    }

    #endregion

    #region Shootout

    [System.Serializable]
    public class NPCShootoutState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.ShootoutState; } }
        public NPCAnimationObject putOut;
        public NPCAnimationObject shoot;
        public NPCAnimationObject putIn;

        public NPCAnimationObject hide;
        public NPCAnimationObject reload;

        /*
            Shoot_01 (Deputy)
            Shoot_01_PutOut (stand&aim)
            Shoot_01_Shoot (stand&shoot)
            Shoot_01_PutIn (stand&lower gun)
            Shoot_01_Hide (crouch Idle)
            Shoot_01_Reload (crouch)
            Shoot_01_Stunned (stand)
            Shoot_01_Stunned (crouch)
        */

        //public override bool blendTree { get { return true; } }

        public override List<AnimationObject> GetAnimations()
        {
            List<AnimationObject> animations = new List<AnimationObject>();

            animations.Add(putOut);
            animations.Add(shoot);
            animations.Add(putIn);

            animations.Add(hide);
            animations.Add(reload);

            return animations;
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            string category = npcDefinition != null ? npcDefinition.category : definition.animationLabel;
            string animationLabel = definition.animationLabel;

            switch(category)
            {
                case ActorAnimationStateNames.PutOut:
                    animationObject = putOut;
                    break;
                case ActorAnimationStateNames.Shoot:
                    animationObject = shoot;
                    break;
                case ActorAnimationStateNames.PutIn:
                    animationObject = putIn;
                    break;
                case ActorAnimationStateNames.Hide:
                    animationObject = hide;
                    break;
                case ActorAnimationStateNames.Reload:
                    animationObject = reload;
                    break;
                default:
                    //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", definition.animationLabel);
                    break;
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] animations, string keyword)
        {
            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                    return animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            switch(keyword)
            {
                case ActorAnimationStateNames.PutOut:
                    animationObject = putOut;
                    break;
                case ActorAnimationStateNames.Shoot:
                    animationObject = shoot;
                    break;
                case ActorAnimationStateNames.PutIn:
                    animationObject = putIn;
                    break;
                case ActorAnimationStateNames.Hide:
                    animationObject = hide;
                    break;
                case ActorAnimationStateNames.Reload:
                    animationObject = reload;
                    break;
                default:
                    break;
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }


        // --- BlendTree ---
        public override BlendTree1DInfo GetBlendTree()
        {
            SortedList<string, AnimationObject[]> blendTreeBlocks = new SortedList<string, AnimationObject[]>();
            //blendTreeBlocks.Add("Idles", idles);
            //blendTreeBlocks.Add("Walks", walks);
            return new BlendTree1DInfo("Velocity", blendTreeBlocks);
        }

        public override int GetBlendValue(AnimationBaseDefinition definition)
        {
            AnimationCategoryGeneralDefinition npcDefinition = definition as AnimationCategoryGeneralDefinition;

            //switch(npcDefinition.category)
            //{
            //    case ActorAnimationStateNames.Idle:
            //        return GetBlendValue(idles, npcDefinition.animationLabel);
            //    case ActorAnimationStateNames.Walk:
            //        return GetBlendValue(walks, npcDefinition.animationLabel);
            //    default:
            //        break;
            //}

            return 0;
        }
    }

    #endregion

    #region Actor SingleShot Animations

    // --- NPC States ---
    [System.Serializable]
    public class ActorStandaloneState : BaseState
    {
        public override string Name { get { return ActorAnimatorStates.StandaloneState; } }
        public NPCAnimationObject[] animations;

        public override List<AnimationObject> GetAnimations()
        {
            return new List<AnimationObject>(animations);
        }

        /// <summary>
        /// Gets an Animation of the State.
        /// </summary>
        /// <returns>The animation.</returns>
        /// <param name="definition">AnimationDefinition</param>
        public override AnimationObject GetAnimation(AnimationBaseDefinition definition)
        {
            AnimationObject animationObject = null;

            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == definition.animationLabel)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            return animationObject;
        }

        private AnimationObject GetAnimation(AnimationObject[] _animations, string keyword)
        {
            for(int i = 0; i < _animations.Length; i++)
            {
                if(_animations[i].label == keyword)
                    return _animations[i];
            }

            //Debug.LogErrorFormat("AnimationState: Animation with label '{0}' was not found.", keyword);
            return _animations[0];
        }

        public override bool ContainsAnimation(string keyword)
        {
            AnimationObject animationObject = null;

            for(int i = 0; i < animations.Length; i++)
            {
                if(animations[i].label == keyword)
                {
                    animationObject = animations[i];
                    break;
                }
            }

            //if(animationObject == null || animationObject.clip == null)
            //Debug.LogErrorFormat("ContainsAnimation: Animation with label '{0}' was not found.", keyword);

            return (animationObject != null && animationObject.clip != null);
        }

        #endregion
    }
}