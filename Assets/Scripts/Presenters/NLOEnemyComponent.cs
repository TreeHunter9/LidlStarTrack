using Models.MovementSystems;
using Models.Weapon;
using UnityEngine;

namespace Presenters
{
    public class NLOEnemyComponent : BaseEnemyComponent, IFollowingMovement
    {
        [SerializeField] private float _speed;
        [Range(0f, 2f)]
        [SerializeField] private float _turningSpeed;

        private IUpdatableMovement _nloMovement;
        private Transform _targetTransform;

        public float Speed => _speed;
        public float TurningSpeed => _turningSpeed;
        public Transform Transform => transform;

        private void Awake()
        {
            _nloMovement = new FollowingMovement(this);
        }

        private void Update()
        {
            _nloMovement.OnUpdate(_targetTransform.position);
        }

        protected override void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.CompareTag("Player"))
            {
                col.transform.GetComponent<IDamageable>().TakeDamage();
                Destroy(gameObject);
            }
        }

        public void Init(Transform target)
        {
            _targetTransform = target;
        }

        public override void TakeDamage() => Destroy(gameObject);
    }
}