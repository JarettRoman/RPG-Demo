using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;

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
            if (target != null && !(Vector3.Distance(transform.position, target.position) < weaponRange))
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                target = null;
                GetComponent<Mover>().Stop();
            }
        }

        public void Stop()
        {

        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
