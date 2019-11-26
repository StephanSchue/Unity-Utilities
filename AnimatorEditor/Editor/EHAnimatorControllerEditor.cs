using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections.Generic;

namespace EH.Animations
{
    [CustomEditor(typeof(EHAnimatorController))]
    [CanEditMultipleObjects()]
    public class EHAnimatorControllerEditor : ActorAnimatorControllerEditor
    {
        // Use this for initialization
        protected void OnEnable()
        {
            Initialize();
        }

        // The inspector override
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        protected override void GenerateAnimator(ActorAnimatorController actorAnimationController)
        {
            base.GenerateAnimator(actorAnimationController);
            EHAnimatorController ehAnimatorController = actorAnimationController as EHAnimatorController;

            // --- Update Statemachines ---
            UpdateStatemachine(ehAnimatorController.generalState); // GeneralState
            UpdateStatemachine(ehAnimatorController.crouchState); // CrouchState
            UpdateStatemachine(ehAnimatorController.collectStates); // CollectState
            UpdateStatemachine(ehAnimatorController.treasureChestState); // TreasureChestState
            UpdateStatemachine(ehAnimatorController.caughtStates); // CaughtStates
            UpdateStatemachine(ehAnimatorController.climbState); // ClimbStates

            UpdateStatemachine(ehAnimatorController.openCloseStates); // OpenCloseStates
            UpdateStatemachine(ehAnimatorController.hideInsideStates); // HideInsideStates
            UpdateStatemachine(ehAnimatorController.pushPullStates); // PushPullStates
            UpdateStatemachine(ehAnimatorController.throwStates); // ThrowStates

            UpdateStatemachine(ehAnimatorController.kidStates); // KidStates
            UpdateStatemachine(ehAnimatorController.checkpointStates); // CheckpointStates
            UpdateStatemachine(ehAnimatorController.cheakyStates); // CheakyAnimations

            UpdateStatemachine(ehAnimatorController.birdViewState); // BirdViewAnimations
            UpdateStatemachine(ehAnimatorController.minecartState); // MinecartState
            UpdateStatemachine(ehAnimatorController.switchState); // SwitchState
            UpdateStatemachine(ehAnimatorController.balanceState); // BalanceState

            // -- Modular Animations --
            UpdateStatemachine(ehAnimatorController.torsoLayerStates);

            Debug.Log("Generate Animator finished!");
        }
    }
}