using RPG.Combat;
using RPG.Locomotion;
using RPG.Locomotion.Animation;
using UnityEngine;

namespace RPG.States
{
    public abstract class State
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly Fighter Fighter;
        protected readonly Movement Movement;
        protected readonly MovementAnimation MovementAnimation;

        protected State(Movement movement, Fighter fighter, MovementAnimation movementAnimation, IStateSwitcher stateSwitcher)
        {
            Movement = movement;
            Fighter = fighter;
            MovementAnimation = movementAnimation;
            StateSwitcher = stateSwitcher;
        }
        
        public abstract void SetDestination(Vector3 newPosition);
        public abstract void SetDestination(CombatTarget target, float weaponRange);
        public abstract void Attack(CombatTarget target, float weaponRange);
    }
}