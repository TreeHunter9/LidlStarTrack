using UnityEngine;

namespace Models.MovementSystems
{
    public class FollowingMovement : IUpdatableMovement
    {
        private IFollowingMovement _followingObject;
        private Vector2 slerp;

        public FollowingMovement(IFollowingMovement followingObject)
        {
            _followingObject = followingObject;
        }

        public void OnUpdate(Vector2 targetPosition)
        {
            Vector2 direction = targetPosition - (Vector2)_followingObject.Transform.position;
            slerp = Vector3.Slerp(slerp, direction, _followingObject.TurningSpeed * Time.deltaTime);
            _followingObject.Transform.position += (Vector3)slerp.normalized * _followingObject.Speed * Time.deltaTime;
        }
    }
}