using UnityEngine;

namespace Models.MovementSystems
{
    public class SpaceshipMovement : IUpdatableMovement
    {
        private Vector2 _currentVelocity;
        private Vector2 _smoothDampVelocity;

        private IAccelerationMovement _movementObject;

        public Vector2 GetCurrentVelocity => _currentVelocity;

        public SpaceshipMovement(IAccelerationMovement movementObject)
        {
            _movementObject = movementObject;
        }

        public void OnUpdate(Vector2 moveInputs)
        {
            if (moveInputs.y > 0f)
                MoveForward();
            else
                ApplyFreeFallVelocity();
        
            Rotate(moveInputs.x);
        }
    
        private void MoveForward()
        {
            _currentVelocity = Vector2.SmoothDamp(_currentVelocity,
                _movementObject.Transform.up * _movementObject.Speed, ref _smoothDampVelocity, _movementObject.AccelerationTime);
            _movementObject.Transform.position += (Vector3)_currentVelocity * Time.deltaTime;
        }

        private void Rotate(float xAxis)
        {
            if (xAxis == 0f)
                return;
            float direction = xAxis > 0 ? -1f : 1f;
            _movementObject.Transform.Rotate(Vector3.forward, _movementObject.RotationSpeed * direction * Time.deltaTime);
        }

        private void ApplyFreeFallVelocity() => _movementObject.Transform.Translate(_currentVelocity * Time.deltaTime, Space.World);
    }
}
