using UnityEngine;
using UnityEngine.InputSystem;

namespace Models.InputSystem
{
    public interface ISpaceshipBaseInputs
    {
        Vector2 MoveInputs { get; }
        
        InputAction FirstFireAction { get; }
        InputAction SecondFireAction { get; }

        void Enable();
        void Disable();
    }
}