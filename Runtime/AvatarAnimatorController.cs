using System;
using UnityEngine;

namespace IronCarpStudios.Unity.Avatar
{
    public class AvatarAnimatorController : MonoBehaviour
    {
        private Animator Animator;

        public event EventHandler AttackAnimationComplete;

        public bool IsLockedOn => Animator.GetBool("IsLockedOn");
        public bool IsMoving => Animator.GetBool("IsMoving");
        public bool IsInCombatState => Animator.GetBool("CombatStateEnabled");
        public bool IsAttacking => Animator.GetBool("IsAttacking");

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        public void AnimationHit()
        {
            AttackAnimationComplete?.Invoke(this, null);
        }

        public void SetLockOn(bool isLockedOn)
        {
            Animator.SetBool("IsLockedOn", isLockedOn);
        }

        public void SetIsMoving(bool isMoving)
        {
            Animator.SetBool("IsMoving", isMoving);
        }

        public void SetForwardMovement(float direction)
        {
            var clampedDirection = Mathf.Clamp(direction, -1f, 1f);
            Animator.SetFloat("ForwardMovement", clampedDirection);
        }

        public void EnableCombatState()
        {
            Animator.SetBool("CombatStateEnabled", true);
        }

        public void DisableCombatState()
        {
            Animator.SetBool("CombatStateEnabled", false);
        }

        public void PlayCombatAction(int weaponId, int actionId)
        {
            if (!IsAttacking)
            {
                Animator.SetInteger("WeaponId", weaponId);
                Animator.SetInteger("AttackSequenceId", actionId);
                Animator.SetBool("IsAttacking", true);
            }
        }
    }
}
