using System.Collections;
using Models.MovementSystems;
using Models.Weapon;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Presenters
{
    public class AsteroidEnemyComponent : BaseEnemyComponent, IMovement
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private BaseFactory<BaseEnemyComponent> _enemyFactory;
        private IUpdatableMovement _asteroidMovement;
        private Vector2 _direction;
        private float _angleRotation;

        public Transform Transform => transform;
        public float Speed => _speed;

        private void Awake()
        {
            _asteroidMovement = new FreeFallMovement(this);
            _angleRotation = Random.Range(-0.3f, 0.3f);
        }

        private void Start()
        {
            StartCoroutine(DestroyAfterTime(25f));
        }

        private void Update()
        {
            _asteroidMovement.OnUpdate(_direction);
            transform.Rotate(Vector3.forward, _angleRotation);
        }

        protected override void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.CompareTag("Player"))
            {
                col.transform.GetComponent<IDamageable>().TakeDamage();
                return;
            }
        }

        public void Init(Vector2 direction)
        {
            _direction = direction;
        }

        public override void TakeDamage()
        {
            Destroy(gameObject);
        }

        private IEnumerator DestroyAfterTime(float timeInSeconds)
        {
            yield return new WaitForSeconds(timeInSeconds);
            Destroy(gameObject);
        }
    }
}