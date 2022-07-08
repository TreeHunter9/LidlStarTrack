using UnityEngine;

namespace Models.MovementSystems
{
    public interface IMovement
    {
        public float Speed { get; }
        public Transform Transform { get; }
    }
}