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
            var ray = _main.ScreenPointToRay(Input.mousePosition);
            var casted = Physics.Raycast(ray, out var hitInfo, float.MaxValue);
            if (!casted) return;

            MoveTo(hitInfo.point);
            Attack(hitInfo.collider.gameObject.GetComponent<CombatTarget>());
        }

        private void MoveTo(Vector3 destination)
        {
            if (Input.GetMouseButton(0))
                _movement.MoveTo(destination);

            _movementAnimation.Blend();
        }
        
        private void Attack(CombatTarget target)
        {
            if (Input.GetMouseButtonDown(0))
                _fighter.Attack(target);
        }
    }
}