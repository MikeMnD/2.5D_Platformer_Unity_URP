﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Roundbeargames
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AI/StartWalking")]
    public class StartWalking : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.aiController.WalkStraightToStartSphere();
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //jump
            if (characterState.characterControl.aiProgress.EndSphereIsHigher())
            {
                if (characterState.characterControl.aiProgress.GetDistanceToStartSphere() < 0.01f)
                {
                    characterState.characterControl.MoveRight = false;
                    characterState.characterControl.MoveLeft = false;

                    animator.SetBool(AI_Walk_Transitions.jump_platform.ToString(), true);
                    return;
                }
            }

            //fall
            if (characterState.characterControl.aiProgress.EndSphereIsLower())
            {
                animator.SetBool(AI_Walk_Transitions.fall_platform.ToString(), true);
                return;
            }

            //straight
            if (characterState.characterControl.aiProgress.GetDistanceToStartSphere() > 3f)
            {
                characterState.characterControl.Turbo = true;
            }
            else
            {
                characterState.characterControl.Turbo = false;
            }

            characterState.characterControl.aiController.WalkStraightToStartSphere();
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(AI_Walk_Transitions.jump_platform.ToString(), false);
            animator.SetBool(AI_Walk_Transitions.fall_platform.ToString(), false);
        }
    }
}