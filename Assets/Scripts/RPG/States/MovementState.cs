using RPG.Combat;
using RPG.Locomotion;
using RPG.Locomotion.Animation;
using UnityEngine;

namespace RPG.States
{
    public sealed class MovementState : State
    {
        public MovementState(Movement movement, Fighter fighter, MovementAnimation movementAnimation, IStateSwitcher stateSwitcher) : base(movement, fighter, movementAnimation, stateSwitcher)
        {
        }

        public override void Attack(CombatTarget target, float weaponRange)
        {
        }

        public override void SetDestination(CombatTarget target, float weaponRange)
        {
            if (!target) return;

            Movement.SetDestination(target.transform.position, weaponRange);
            
            if (Movement.IsStopped())
                StateSwitcher.SwitchState<AttackState>();
        }

        public override void SetDestination(Vector3 newPosition)
        {
            MovementAnimation.Blend();
            
            if (Input.GetMouseButton(0))
                Movement.SetDestination(newPosition);

            if (Movement.IsStopped())
                StateSwitcher.SwitchState<IdleState>();
        }
    }
}