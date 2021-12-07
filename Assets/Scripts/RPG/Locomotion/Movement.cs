using UnityEngine;
using UnityEngine.AI;

namespace RPG.Locomotion
{
    public class Movement
    {
        private readonly NavMeshAgent _agent;

        public Movement(NavMeshAgent agent)
        {
            _agent = agent;
        }
        
        public bool IsStopped() => _agent.velocity.magnitude == 0;
        public void SetDestination(Vector3 destination) => _agent.SetDestination(destination);
        public void SetDestination(Vector3 destination, float offset)
        {
            var vectorFromDestinationToAgent = _agent.transform.position - destination;

            var newDestination = new Vector3
            {
                x = destination.x + vectorFromDestinationToAgent.normalized.x * offset,
                y = destination.y,
                z = destination.z + vectorFromDestinationToAgent.normalized.z * offset
            };

            _agent.SetDestination(newDestination);
        }
    }
}