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

        private void Start()
        {
            var animator = GetComponent<Animator>();
            var agent = GetComponent<NavMeshAgent>();
            
            _main = Camera.main;
            _movement = new Movement(agent);
            _movementAnimation = new MovementAnimation(agent, animator);
        }

        private void Update()
        {
            var ray = _main.ScreenPointToRay(Input.mousePosition);
            var casted = Physics.Raycast(ray, out var hitInfo, float.MaxValue);

            if (casted) 
                MoveTo(hitInfo.point);
        }

        private void MoveTo(Vector3 destination)
        {
            if (Input.GetMouseButton(0)) 
                _movement.MoveTo(destination);
            
            _movementAnimation.Blend();
        }
    }
}