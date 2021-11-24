using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        private const string TerrainLayerName = "Terrain";
        private NavMeshAgent _agent;
        private Camera _main;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _main = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1)) 
                Move();
        }

        private void Move()
        {
            var ray = _main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, float.MaxValue, LayerMask.GetMask(TerrainLayerName)))
                _agent.SetDestination(hitInfo.point);
        }
    }
}