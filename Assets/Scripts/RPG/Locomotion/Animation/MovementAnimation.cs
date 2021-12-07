using UnityEngine;
using UnityEngine.AI;

namespace RPG.Locomotion.Animation
{
    public class MovementAnimation
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private readonly Animator _animator;
        private readonly NavMeshAgent _agent;
        
        public MovementAnimation(NavMeshAgent agent, Animator animator)
        {
            _agent = agent;
            _animator = animator;
        }
        
        public void Blend() => _animator.SetFloat(Speed, _agent.velocity.magnitude / _agent.speed);
    }
}