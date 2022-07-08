using UnityEngine;

namespace Models.MovementSystems
{
    public interface IUpdatableMovement
    {
        void OnUpdate(Vector2 data);
    }
}