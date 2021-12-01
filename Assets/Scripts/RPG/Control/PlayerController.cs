using RPG.Combat;
using RPG.Locomotion;
using RPG.Locomotion.Animation;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        private Camera _main;
        private Movement _movement;
        private MovementAnimation _movementAnimation;
        private Fighter _fighter;

        private void Start()
        {
            var animator = GetComponent<Animator>();
            var agent = GetComponent<NavMeshAgent>();
            
            _main = Camera.main;
            _movement = new Movement(agent);
            _movementAnimation = new MovementAnimation(agent, animator);
            _fighter = new Fighter();
        }

        private void Update()
        {
            _movementAnimation.Blend();
            
            var ray = _main.ScreenPointToRay(Input.mousePosition);
            var casted = Physics.Raycast(ray, out var hitInfo);
            if (!casted) return;

            if (TryAttack(hitInfo.collider.gameObject.GetComponent<CombatTarget>())) return;
            if (TryMoveTo(hitInfo.point)) return;
        }

        private bool TryMoveTo(Vector3 destination)
        {
            var lmbPressed = Input.GetMouseButton(0);
            if (lmbPressed)
                _movement.MoveTo(destination);
            return lmbPressed;
        }
        
        private bool TryAttack(CombatTarget target)
        {
            if (Input.GetMouseButtonDown(0) && target) 
                _fighter.Attack(target);
            return target;
        }
    }
}