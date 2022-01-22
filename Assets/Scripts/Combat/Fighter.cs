using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
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
            if (!inRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }
        }

        private void AttackBehavior()
        {
            GetComponent<Animator>().SetTrigger("attack");
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

        bool inRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        // Animation Event
        void Hit()
        {

        }
    }
}
