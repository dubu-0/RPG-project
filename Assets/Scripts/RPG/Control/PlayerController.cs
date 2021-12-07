using System.Collections.Generic;
using System.Linq;
using RPG.Combat;
using RPG.Locomotion;
using RPG.Locomotion.Animation;
using RPG.States;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    [RequireComponent(typeof(Animator)), RequireComponent(typeof(NavMeshAgent))]
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour, IStateSwitcher
    {
        private State _currentState;
        private List<State> _allStates;
        private Camera _main;
        private CombatTarget _target;

        private void Start()
        {
            var animator = GetComponent<Animator>();
            var agent = GetComponent<NavMeshAgent>();
            
            var movement = new Movement(agent);
            var movementAnimation = new MovementAnimation(agent, animator);
            var fighter = new Fighter();

            CreateStates(movement, fighter, movementAnimation);
            _currentState = _allStates[0];
            
            _main = Camera.main;
        }

        private void Update()
        {
            if (!CastNewRayToCursor(out var hitInfo)) return;

            if (Input.GetMouseButtonDown(0)) 
                _target = hitInfo.collider.gameObject.GetComponent<CombatTarget>();

            _currentState.Attack(_target, 2.5f);
            _currentState.SetDestination(_target, 2.5f);
            _currentState.SetDestination(hitInfo.point);

            Debug.Log(_currentState);
        }

        void IStateSwitcher.SwitchState<T>() => _currentState = _allStates.FirstOrDefault(s => s is T);

        private void CreateStates(Movement movement, Fighter fighter, MovementAnimation movementAnimation)
        {
            var attackState = new AttackState(movement, fighter, movementAnimation, this);
            var movementState = new MovementState(movement, fighter, movementAnimation, this);
            var idleState = new IdleState(movement, fighter, movementAnimation, this);
            
            _allStates = new List<State>
            {
                idleState, 
                movementState, 
                attackState
            };
        }

        private bool CastNewRayToCursor(out RaycastHit hitInfo)
        {
            var ray = _main.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hitInfo);
        }
    }
}