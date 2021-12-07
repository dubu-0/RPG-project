using RPG.Combat;
using RPG.Locomotion;
using RPG.Locomotion.Animation;
using UnityEngine;

namespace RPG.States
{
    public sealed class AttackState : State
    {
        private bool _isAttacking;
        
        public AttackState(Movement movement, Fighter fighter, MovementAnimation movementAnimation, IStateSwitcher stateSwitcher) : base(movement, fighter, movementAnimation, stateSwitcher)
        {
        }
        
        public override void Attack(CombatTarget target, float weaponRange)
        {
            if (Input.GetMouseButtonDown(0) && target)
            {
                Fighter.Attack(target);
                _isAttacking = true;
            }
        }

        public override void SetDestination(CombatTarget target, float weaponRange)
        {
            if (Input.GetMouseButtonDown(0) && target && !_isAttacking) 
                StateSwitcher.SwitchState<MovementState>();
        }

        public override void SetDestination(Vector3 newPosition)
        {
            if (Input.GetMouseButton(0))
            {
                _isAttacking = false;
                StateSwitcher.SwitchState<MovementState>();
            }
        }
    }
}