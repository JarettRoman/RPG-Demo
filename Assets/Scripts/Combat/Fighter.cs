using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        Transform target;
        NavMeshAgent navMeshAgent;
        float timeSinceLastAttack = 0f;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

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
            // Triggers Hit() event
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                timeSinceLastAttack = 0;
                GetComponent<Animator>().SetTrigger("attack");
            }
        }

        // Animation Event
        void Hit()
        {
            target.GetComponent<Health>().TakeDamage(weaponDamage);
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
    }
}
