using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (target == null) return;
            if (!(Vector3.Distance(transform.position, target.position) < weaponRange))
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                // Cancel();
                GetComponent<Mover>().Stop();
            }
        }

        public void Cancel()
        {
            target = null;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }
    }
}
