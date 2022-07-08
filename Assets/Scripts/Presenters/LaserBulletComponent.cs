using Models.Weapon;
using UnityEngine;

namespace Presenters
{
    public class LaserBulletComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        
        public void Init(Vector2 direction)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 50f, _layerMask);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.TryGetComponent(out IDamageable damageableObject))
                {
                    damageableObject.TakeDamage();
                }
            }
        }
    }
}