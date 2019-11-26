using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections.Generic;

namespace EH.Animations
{
    [CustomEditor(typeof(ActorAnimatorController))]
    public class ActorAnimatorControllerEditor : Editor
    {
        protected ActorAnimatorController t;
        private AnimatorController animatorController;
        private ChildAnimatorState[] animatorStates;

        // Use this for initialization
        private void OnEnable()
        {
            Initialize();
        }

        protected void Initialize()
        {
            if(t != null)
                return;

            t = target as ActorAnimatorController;
            animatorController = t.animatorController as AnimatorController;

            if(animatorController == null)
                return;

            animatorStates = animatorController.layers[0].stateMachine.states;
        }

        // The inspector override
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(animatorController == null)
                return;

            //if(t.animator != null && t.animatorController != t.animator.runtimeAnimatorController)
            //{
            //    t.animator.runtimeAnimatorController = t.animatorController;
            //}

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("State: " + (t.CurrentState != null ? t.CurrentState.Name : "None"));
            EditorGUILayout.LabelField("Animation: " + (t.CurrentAnimation != null ? t.CurrentAnimation.label : "None"));
            EditorGUILayout.EndVertical();
            Repaint();

            if(GUILayout.Button("Update Animator"))
            {
                GenerateAnimator(t);
            }
        }

        protected virtual void GenerateAnimator(ActorAnimatorController actorAnimationController)
        {
            
        }

        #region Helpers

        protected bool UpdateStatemachine(BaseStateCollection stateCollection, int layerIndex = 0)
        {
            bool status = true;
            AnimatorStateMachine parentState = null;

            ChildAnimatorStateMachine[] _animatorSubstates = animatorController.layers[layerIndex].stateMachine.stateMachines;

            // --- Create Collection State ---
            if (!AnimatorstatemachineExists(stateCollection.Name, _animatorSubstates, out parentState))
                parentState = this.animatorController.layers[layerIndex].stateMachine.AddStateMachine(stateCollection.Name);

            if (stateCollection.States.Length == 0)
                Debug.LogFormat("{0}: Statelist is empty!", stateCollection.Name);

            UpdateStatemachine(stateCollection.States, parentState, layerIndex);

            return status;
        }

        protected bool UpdateStatemachine(ModularStateCollection stateCollection)
        {
            bool status = true;
            int layerIndex = GetLayerIndex(stateCollection.Layer);

            // --- Add Layer ---
            if(layerIndex == -1)
                layerIndex = AddLayer(stateCollection.Layer);  

            AnimatorStateMachine parentState = null;
            ChildAnimatorStateMachine[] _animatorSubstates = animatorController.layers[layerIndex].stateMachine.stateMachines;

            // --- Create Collection State ---
            if(!AnimatorstatemachineExists(stateCollection.Name, _animatorSubstates, out parentState))
                parentState = this.animatorController.layers[layerIndex].stateMachine.AddStateMachine(stateCollection.Name);

            if(stateCollection.States.Length == 0)
                Debug.LogFormat("{0}: Statelist is empty!", stateCollection.Name);

            UpdateStatemachine(stateCollection.States, parentState, layerIndex);

            return status;
        }

        protected bool UpdateStatemachine(BaseState state, AnimatorStateMachine parentState, string layerName)
        {
            int layerIndex = GetLayerIndex(layerName);

            // --- Add Layer ---
            if (layerIndex == -1)
                layerIndex = AddLayer(layerName);

            return UpdateStatemachine(state, parentState, layerIndex);
        }

        protected bool UpdateStatemachine(BaseState[] states, AnimatorStateMachine parentState = null, int layerIndex=0)
        {
            bool status = true;

            if (states == null || states.Length == 0)
                return false;

            // --- Iterate trough States ---
            for (int i = 0; i < states.Length; i++)
            {
                status = UpdateStatemachine(states[i], parentState, layerIndex);

                if (!status)
                {
                    Debug.LogError("Error in State:" + states[i].Name);
                    return status;
                }
            }

            return status;
        }

        protected bool UpdateStatemachine(BaseState state, AnimatorStateMachine parentState = null, int layerIndex = 0)
        {
            bool status = true;
            AnimatorStateMachine statemachine = null;
            ChildAnimatorStateMachine[] _animatorSubstates = animatorController.layers[layerIndex].stateMachine.stateMachines;

            // --- Update State ---
            if (parentState != null)
            {
                // -- Add States into Parent State --
                if (!AnimatorstatemachineExists(state.Name, parentState.stateMachines, out statemachine))
                    statemachine = parentState.AddStateMachine(state.Name);
            }
            else
            {
                // -- Add States into Global State --
                if (!AnimatorstatemachineExists(state.Name, _animatorSubstates, out statemachine))
                    statemachine = this.animatorController.layers[layerIndex].stateMachine.AddStateMachine(state.Name);
            }

            // --- Add State Parameter ---
            string stateParameterName = state.Name;
            AnimatorControllerParameter stateParameter = null;

            if(!ParameterExists(stateParameterName, this.animatorController.parameters, out stateParameter))
            {
                this.animatorController.AddParameter(stateParameterName, AnimatorControllerParameterType.Bool);
                ParameterExists(stateParameterName, this.animatorController.parameters, out stateParameter); // Link Paramter to "stateParameter" ObjectReference
            }

            if(statemachine != null)
            {
                // --- Create BlendTree ---
                if(state.blendTree)
                {
                    BaseState.BlendTree1DInfo blendTree1D = state.GetBlendTree();
                    string blendTreeName = string.Format("{0}_{1}_BlendTree", state.Name, blendTree1D.parameter);

                    //// -- Update BlendTree Parameter --
                    string blendParameterName = blendTree1D.parameter;
                    AnimatorControllerParameter blendParameter = null;

                    if(!ParameterExists(blendParameterName, this.animatorController.parameters, out blendParameter))
                        this.animatorController.AddParameter(blendParameterName, AnimatorControllerParameterType.Float);

                    // --- Add BlendTree ---
                    AnimatorState blendTreeState;
                    BlendTree blendTree = null;

                    if(!AnimatorstateExists(blendTreeName, statemachine.states, out blendTreeState))
                    {
                        Debug.Log("CreateBlendTreeInController");
                        //blendTreeState = this.animatorController.CreateBlendTreeInController(blendTreeName, out blendTree);
                        blendTreeState = CreateBlendTreeInController(statemachine, blendTreeName, out blendTree);
                    }
                    else if(blendTreeState.motion == null)
                    {
                        Debug.Log("RecreateBlendTreeInController");
                        blendTreeState = RecreateBlendTreeInController(statemachine, blendTreeState, blendTreeName, out blendTree, 0);
                    }

                    if(blendTreeState.motion is BlendTree)
                        blendTree = blendTreeState.motion as BlendTree;

                    if(blendTree != null && blendTree1D.blocks != null)
                    {
                        blendTree.name = blendTreeName;
                        blendTree.blendParameter = blendParameterName;
                        blendTree.useAutomaticThresholds = false;

                        AnimatorState subBlendTreeState;
                        BlendTree subBlendTree = null;
                        AnimationClip animationClip = null;

                        for(int i = 0; i < blendTree1D.blocks.Count; i++)
                        {
                            if(blendTree1D.blocks.Count > 1)
                            {
                                // 1D BlendTree with SubBlendTrees that have motionClips as children
                                //Debug.LogFormat("Multi-BlendTree: {0}/{1}", blendTree1D.blocks.Keys[i], blendTree1D.blocks.Keys.Count);
                                string subBlendTreeName = string.Format("{0}_BlendTree", blendTree1D.blocks.Keys[i]);

                                //// -- Update BlendTree Parameter --
                                string subBlendParameterName = string.Format("{0}_Blend_{1}", state.Name, blendTree1D.blocks.Keys[i]);
                                AnimatorControllerParameter subBlendParameter = null;

                                if(!ParameterExists(subBlendParameterName, this.animatorController.parameters, out subBlendParameter))
                                    this.animatorController.AddParameter(subBlendParameterName, AnimatorControllerParameterType.Float);

                                // -- Create Sub-BlendTree --
                                if(i >= blendTree.children.Length)
                                {
                                    subBlendTree = CreateBlendTree(subBlendTreeName);
                                    blendTree.AddChild(subBlendTree);
                                }
                                else if(blendTree.children[i].motion == null)
                                {
                                    subBlendTree = CreateBlendTree(subBlendTreeName);
                                    blendTree.children[i].motion = subBlendTree;
                                }

                                subBlendTree = blendTree.children[i].motion as BlendTree;
                                subBlendTree.name = subBlendTreeName;
                                subBlendTree.blendParameter = subBlendParameterName;
                                subBlendTree.useAutomaticThresholds = false;

                                // -- Update Clips --
                                for(int y = 0; y < blendTree1D.blocks.Values[i].Length; y++)
                                {
                                    //Debug.LogFormat("- {0}: {1}", blendTree1D.blocks.Values[i][y].label, subBlendTree.children[y].motion);
                                    animationClip = blendTree1D.blocks.Values[i][y].clip;

                                    if(y < subBlendTree.children.Length)
                                        subBlendTree.children[y].motion = animationClip; // Update
                                    else
                                        subBlendTree.AddChild(animationClip); // Add
                                }

                                // Rewrite the Threshold
                                ChildMotion[] subChildren = subBlendTree.children;

                                for(int z = 0; z < subBlendTree.children.Length; z++)
                                    subChildren[z].threshold = z;

                                subBlendTree.children = subChildren;
                            }
                            else
                            {
                                // 1D BlendTree with Motion Clips and One Parameter
                                for(int x = 0; x < blendTree1D.blocks.Values[0].Length; x++)
                                {
                                    animationClip = blendTree1D.blocks.Values[0][x].clip;

                                    if(x < blendTree.children.Length) 
                                        blendTree.children[x].motion = animationClip; // Update
                                    else
                                        blendTree.AddChild(animationClip); // Add
                                }
                            }
                        }

                        // Rewrite the Threshold
                        ChildMotion[] children = blendTree.children;

                        for(int z = 0; z < blendTree.children.Length; z++)
                            children[z].threshold = z;

                        blendTree.children = children;
                    }

                    //// --- Anystate Transitions ---
                    string triggerParameterName = blendTreeName;
                    AnimatorControllerParameter transitionParameter = null;

                    if(!ParameterExists(triggerParameterName, this.animatorController.parameters, out transitionParameter))
                        this.animatorController.AddParameter(triggerParameterName, AnimatorControllerParameterType.Trigger);

                    AnimatorStateTransition transition = null;
                    if(!StateTransitionExists(triggerParameterName, this.animatorController.layers[layerIndex].stateMachine.anyStateTransitions, out transition))
                    {
                        transition = this.animatorController.layers[layerIndex].stateMachine.AddAnyStateTransition(blendTreeState);
                        transition.AddCondition(AnimatorConditionMode.If, 0f, triggerParameterName);
                        transition.AddCondition(AnimatorConditionMode.If, 0f, stateParameterName);

                        transition.destinationStateMachine = statemachine;
                    }
                }

                // --- Update Animations in State ---
                List<AnimationObject> animations = state.GetAnimations();
                for (int i = 0; i < animations.Count; i++)
                {
                    // -- Setup AnimatorState --
                    AnimationObject animation = animations[i];
                    AnimatorState animatorState = null;

                    if(string.IsNullOrEmpty(animation.label))
                        continue;

                    if(!AnimatorstateExists(animation.label, statemachine.states, out animatorState))
                        animatorState = statemachine.AddState(animation.label);

                    // -- Update AnimationState --
                    animatorState.motion = animation.clip; // Update MotionClip

                    // -- Animation Events --
                    if(animation.clip != null && animation.clip.events != null && animation.clip.events.Length > 0)
                    {
                        //for(int x = 0; x < animation.clip.events.Length; x++)
                        //{
                        //    Debug.LogFormat("{0}: ({1}) {2}", animation.clip.name,
                        //                    animation.clip.events[x].time,
                        //                    animation.clip.events[x].functionName);
                        //}

                        //AnimationEvent animationEvent = new AnimationEvent();
                        //animationEvent.
                        //animation.clip.AddEvent()
                    }

                    // -- Update Parameters --
                    string parameterName = animation.label;
                    AnimatorControllerParameter parameter = null;

                    if (!ParameterExists(parameterName, this.animatorController.parameters, out parameter))
                        this.animatorController.AddParameter(parameterName, AnimatorControllerParameterType.Trigger);

                    // -- Update Transition --
                    AnimatorStateTransition transition = null;

                    //// --- Anystate Transitions ---
                    if(!StateTransitionExists(parameterName, this.animatorController.layers[layerIndex].stateMachine.anyStateTransitions, out transition))
                    {
                        transition = this.animatorController.layers[layerIndex].stateMachine.AddAnyStateTransition(animatorState);
                        transition.AddCondition(AnimatorConditionMode.If, 0f, parameterName);

                        if(!(stateParameter.name.Contains("Reset") && layerIndex > 0))
                            transition.AddCondition(AnimatorConditionMode.If, 0f, stateParameterName);

                        transition.destinationStateMachine = statemachine;
                    }
                }

                // --- Add Transitions between States ---
                for(int i = 0; i < animations.Count; i++)
                {
                    AnimationObject animation = animations[i];
                    AnimatorState animatorSenderState = null;
                    AnimatorState animatorReceiverState = null;

                    if(AnimatorstateExists(animation.label, statemachine.states, out animatorSenderState) &&
                       AnimatorstateExists(animation.destination, statemachine.states, out animatorReceiverState))
                    {
                        AnimatorStateTransition transition = null;

                        if(!TransitionExists(animatorSenderState, animatorReceiverState, out transition))
                        {
                            //Debug.LogFormat("AnimatorController: Add Transition from '{0}' to {1}!", animatorSenderState.name, animatorReceiverState.name);   
                            transition = animatorSenderState.AddTransition(animatorReceiverState);
                            transition.exitTime = 1f;
                            transition.duration = 0f;
                            transition.hasExitTime = true;
                        }
                    }
                }
            }

            return status;
        }

        public AnimatorState CreateBlendTreeInController(AnimatorStateMachine statemachine, string name, out BlendTree tree)
        {
            return CreateBlendTreeInController(statemachine, name, out tree, 0);
        }

        public AnimatorState CreateBlendTreeInController(AnimatorStateMachine statemachine, string name, out BlendTree tree, int layerIndex)
        {
            tree = new BlendTree();
            tree.name = name;
            tree.blendParameter = tree.blendParameterY = null;

            if(AssetDatabase.GetAssetPath(t.animatorController) != "")
                AssetDatabase.AddObjectToAsset(tree, AssetDatabase.GetAssetPath(t.animatorController));

            AnimatorState state = statemachine.AddState(tree.name);
            state.motion = tree;
            return state;
        }

        public AnimatorState RecreateBlendTreeInController(AnimatorStateMachine statemachine, AnimatorState state, string name, out BlendTree tree, int layerIndex)
        {
            tree = new BlendTree();
            tree.name = name;
            tree.blendParameter = tree.blendParameterY = null;

            if(AssetDatabase.GetAssetPath(t.animatorController) != "")
                AssetDatabase.AddObjectToAsset(tree, AssetDatabase.GetAssetPath(t.animatorController));

            state.motion = tree;
            return state;
        }

        public BlendTree CreateBlendTree(string name)
        {
            BlendTree tree = new BlendTree();
            tree.name = name;
            tree.blendParameter = tree.blendParameterY = null;

            if(AssetDatabase.GetAssetPath(t.animatorController) != "")
                AssetDatabase.AddObjectToAsset(tree, AssetDatabase.GetAssetPath(t.animatorController));

            return tree;
        }

        /// <summary>
        /// Check if parameter exists in AnimatorController.
        /// </summary>
        /// <returns><c>true</c>, if exists was parametered, <c>false</c> otherwise.</returns>
        /// <param name="keyword">Keyword.</param>
        /// <param name="parameters">Parameters.</param>
        /// <param name="parameter">Parameter.</param>
        protected bool ParameterExists(string keyword, AnimatorControllerParameter[] parameters, out AnimatorControllerParameter parameter)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].name == keyword)
                {
                    parameter = parameters[i];
                    return true;
                }
            }

            parameter = null;
            return false;
        }

        /// <summary>
        /// Checks if Transition is existing in list of states.
        /// Transitions define when and how the state machine switch from on state to another. 
        /// AnimatorTransition always originate from a StateMachine or a StateMachine entry. They do not define timing parameters.
        /// </summary>
        /// <returns><c>true</c>, if exists was animatorstated, <c>false</c> otherwise.</returns>
        /// <param name="condition">Keyword.</param>
        /// <param name="transitions">Transitions.</param>
        /// <param name="transition">Animator state.</param>
        protected bool TransitionExists(string condition, AnimatorTransition[] transitions, out AnimatorTransition transition)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].conditions[0].parameter == condition)
                {
                    transition = transitions[i];
                    return true;
                }
            }

            transition = null;
            return false;
        }

        /// <summary>
        /// Checks if Transition is existing in list of states.
        /// Transitions define when and how the state machine switch from on state to another. 
        /// AnimatorTransition always originate from a StateMachine or a StateMachine entry. They do not define timing parameters.
        /// </summary>
        /// <returns><c>true</c>, if exists was animatorstated, <c>false</c> otherwise.</returns>
        /// <param name="condition">Keyword.</param>
        /// <param name="transitions">Transitions.</param>
        /// <param name="transition">Animator state.</param>
        protected bool TransitionExists(AnimatorState sender, AnimatorState receiver, out AnimatorStateTransition transition)
        {
            for (int i = 0; i < sender.transitions.Length; i++)
            {
                if (sender.transitions[i].destinationState == receiver)
                {
                    transition = sender.transitions[i];
                    return true;
                }
            }

            transition = null;
            return false;
        }


        /// <summary>
        /// Checks if AnimatorStateTransition is existing in list of states.
        /// Transitions define when and how the state machine switch from one state to another. 
        /// AnimatorStateTransition always originate from an Animator State (or AnyState) and have timing parameters.
        /// </summary>
        /// <returns><c>true</c>, if exists was animatorstated, <c>false</c> otherwise.</returns>
        /// <param name="condition">Keyword.</param>
        /// <param name="transitions">Transitions.</param>
        /// <param name="transition">Animator state.</param>
        protected bool StateTransitionExists(string condition, AnimatorStateTransition[] transitions, out AnimatorStateTransition transition)
        {
            for(int i = 0; i < transitions.Length; i++)
            {
                if(ConditionExists(condition, transitions[i].conditions))
                {
                    transition = transitions[i];
                    return true;
                }
            }

            transition = null;
            return false;
        }

        private bool ConditionExists(string condition, AnimatorCondition[] conditions)
        {
            for(int i = 0; i < conditions.Length; i++)
            {
                if(conditions[i].parameter == condition)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if Animatorstate is existing in list of states
        /// </summary>
        /// <returns><c>true</c>, if exists was animatorstated, <c>false</c> otherwise.</returns>
        /// <param name="keyword">Keyword.</param>
        /// <param name="states">States.</param>
        /// <param name="animatorState">Animator state.</param>
        protected bool AnimatorstateExists(string keyword, ChildAnimatorState[] states, out AnimatorState animatorState)
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i].state.name == keyword)
                {
                    animatorState = states[i].state;
                    return true;
                }
            }

            animatorState = null;
            return false;
        }

        /// <summary>
        /// Checks if Animatorstate is existing in list of states
        /// </summary>
        /// <returns><c>true</c>, if exists was animatorstated, <c>false</c> otherwise.</returns>
        /// <param name="keyword">Keyword.</param>
        /// <param name="states">States.</param>
        /// <param name="animatorState">Animator state.</param>
        protected bool AnimatorstatemachineExists(string keyword, ChildAnimatorStateMachine[] states, out AnimatorStateMachine animatorStatemachine)
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i].stateMachine.name == keyword)
                {
                    animatorStatemachine = states[i].stateMachine;
                    return true;
                }
            }

            animatorStatemachine = null;
            return false;
        }

        #endregion

        #region Layers

        public int GetLayerIndex(string layerName)
        {
            for(int i = 0; i < animatorController.layers.Length; i++)
            {
                if(animatorController.layers[i].name == layerName)
                    return i;
            }

            return -1;
        }

        public int AddLayer(string layerName)
        {
            animatorController.AddLayer(layerName);

            for(int i = 0; i < animatorController.layers.Length; i++)
            {
                if(animatorController.layers[i].name == layerName)
                    return i;
            }

            return -1;
        }

        #endregion
    }
}