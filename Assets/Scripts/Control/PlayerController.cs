using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            print("Nothing to do...");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.collider.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (Input.GetMouseButtonDown(0))
                {
                    AttackTarget(target);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        void AttackTarget(CombatTarget target)
        {
            GetComponent<Fighter>().Attack(target);
        }
    }
}
