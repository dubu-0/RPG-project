using RPG.Combat;
using RPG.Locomotion;
using RPG.Locomotion.Animation;
using UnityEngine;

namespace RPG.States
{
    public sealed class IdleState : State
    {
        public IdleState(Movement movement, Fighter fighter, MovementAnimation movementAnimation, IStateSwitcher stateSwitcher) : base(movement, fighter, movementAnimation, stateSwitcher)
        {
        }

        public override void Attack(CombatTarget target, float weaponRange)
        {
        }

        public override void SetDestination(CombatTarget target, float weaponRange)
        {
            if (Input.GetMouseButtonDown(0) && target) 
                StateSwitcher.SwitchState<MovementState>();
        }

        public override void SetDestination(Vector3 newPosition)
        {
            if (Input.GetMouseButton(0)) 
                StateSwitcher.SwitchState<MovementState>();
        }
    }
}