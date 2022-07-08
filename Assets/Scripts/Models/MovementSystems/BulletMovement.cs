using UnityEngine;

namespace Models.MovementSystems
{
    public class BulletMovement : IUpdatableMovement
    {
        private Transform _transform;
        private float _speed;

        public BulletMovement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }
    
        public void OnUpdate(Vector2 direction)
        {
            _transform.position += (Vector3) direction * _speed * Time.deltaTime;
        }
    }
}
