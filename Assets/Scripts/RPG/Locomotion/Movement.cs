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

        public void MoveTo(Vector3 destination) => _agent.SetDestination(destination);
    }
}