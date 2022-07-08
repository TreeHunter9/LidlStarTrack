using System.Collections;
using Models.MovementSystems;
using Models.Weapon;
using UnityEngine;

namespace Presenters
{
    public class CannonBulletComponent : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
    
        private BulletMovement _bulletMovement;
        private Vector2 _direction;

        private void Awake()
        {
            _bulletMovement = new BulletMovement(transform, _bulletSpeed);
        }

        private void Start()
        {
            StartCoroutine(DestroyAfterTime(4f));
        }

        public void Init(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            _bulletMovement.OnUpdate(_direction);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.TakeDamage();
                Destroy(gameObject);
            }
        }

        private IEnumerator DestroyAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}
