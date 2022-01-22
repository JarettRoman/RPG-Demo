using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
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

        public void Stop()
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
            GetComponent<NavMeshAgent>().destination = destination;
            navMeshAgent.isStopped = false;
        }
    }
}

