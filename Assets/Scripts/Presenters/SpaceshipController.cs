using Models.InputSystem;
using Models.MovementSystems;
using Models.Weapon;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presenters
{
    public class SpaceshipController : MonoBehaviour, IAccelerationMovement, IDamageable
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accelerationTime;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private BaseFactory<Bullet> _bulletFactory;

        [Header("First Weapon")]
        [SerializeField] private float _firstWeaponcooldownTimeInSeconds = 0.3f;

        [Header("Second Weapon")] 
        [SerializeField] private float _secondWeaponcooldownTimeInSeconds = 3f;
        [SerializeField] private int _secondWeaponBulletCount = 3;

        private ISpaceshipBaseInputs _spaceshipInputs;
        private IUpdatableMovement _spaceshipMovement;

        private BaseWeapon _firstBaseWeapon;
        private BaseWeapon _secondBaseWeapon;

        public BaseWeapon GetFirstWeapon => _firstBaseWeapon;
        public BaseWeapon GetSecondWeapon => _secondBaseWeapon;
        
        public float Speed => _maxSpeed;
        public float AccelerationTime => _accelerationTime;
        public float RotationSpeed => _rotationSpeed;
        public Transform Transform => transform;


        private void Awake()
        {
            _spaceshipInputs = new SpaceshipInputSystem();
            _spaceshipMovement = new SpaceshipMovement(this);
        
            _firstBaseWeapon = new CannonWeapon(_firstWeaponcooldownTimeInSeconds, 1);
            _secondBaseWeapon = new LaserWeapon(_secondWeaponcooldownTimeInSeconds, _secondWeaponBulletCount);
        }

        private void OnEnable()
        {
            _spaceshipInputs.Enable();
            _spaceshipInputs.FirstFireAction.started += FirstFireShoot;
            _spaceshipInputs.SecondFireAction.started += SecondFireShoot;
        }

        private void OnDisable()
        {
            _spaceshipInputs.Disable();
            _spaceshipInputs.FirstFireAction.started -= FirstFireShoot;
            _spaceshipInputs.SecondFireAction.started -= SecondFireShoot;
        }

        private void Update()
        {
            _spaceshipMovement.OnUpdate(_spaceshipInputs.MoveInputs);
        }

        private void FirstFireShoot(InputAction.CallbackContext obj)
        {
            if (_firstBaseWeapon.TryShoot(transform.position, transform.up, out var bullet))
            {
                _bulletFactory.Create(bullet);
            }
        }

        private void SecondFireShoot(InputAction.CallbackContext obj)
        {
            if (_secondBaseWeapon.TryShoot(transform.position, transform.up, out var bullet))
            {
                _bulletFactory.Create(bullet);
            }
        }

        public void TakeDamage()
        {
            gameObject.SetActive(false);
        }

        public float GetVelocity()
        {
            if (_spaceshipMovement is SpaceshipMovement spaceshipMovement)
            {
                return spaceshipMovement.GetCurrentVelocity.magnitude * Time.deltaTime;
            }

            return 0f;
        }
    }
}
