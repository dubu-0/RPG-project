using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        private const string TerrainLayerName = "Terrain";
        private static readonly int Speed = Animator.StringToHash("Speed");
        private NavMeshAgent _agent;
        private Camera _main;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _main = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(1)) 
                Move();

            BlendAnimation();
        }

        private void Move()
        {
            var ray = _main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, float.MaxValue, LayerMask.GetMask(TerrainLayerName)))
                _agent.SetDestination(hitInfo.point);
        }

        private void BlendAnimation() => _animator.SetFloat(Speed, _agent.velocity.magnitude / _agent.speed);
    }
}