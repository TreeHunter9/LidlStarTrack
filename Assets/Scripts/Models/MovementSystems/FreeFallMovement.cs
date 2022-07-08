using UnityEngine;

namespace Models.MovementSystems
{
    public class FreeFallMovement : IUpdatableMovement
    {
        private IMovement _movableObject;

        public FreeFallMovement(IMovement movableObject)
        {
            _movableObject = movableObject;
        }
        
        public void OnUpdate(Vector2 direction)
        {
            _movableObject.Transform.position += (Vector3)direction * _movableObject.Speed * Time.deltaTime;
        }
    }
}