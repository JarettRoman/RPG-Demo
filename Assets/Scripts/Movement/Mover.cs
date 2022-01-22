using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent navMeshAgent;
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            UpdateAnimation();
        }
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        void UpdateAnimation()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(
                GetComponent<UnityEngine.AI.NavMeshAgent>().velocity
            );
            GetComponent<Animator>().SetFloat("forwardSpeed", localVelocity.z);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
    }
}

