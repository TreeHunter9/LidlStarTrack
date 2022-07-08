using UnityEngine;
using UnityEngine.InputSystem;

namespace Models.InputSystem
{
    public class SpaceshipInputSystem : ISpaceshipBaseInputs
    {
        private readonly SpaceshipInputs _spaceshipInputs;

        private InputAction MovementAction { get; set; }
        public InputAction FirstFireAction { get; private set; }
        public InputAction SecondFireAction { get; private set; }
        public Vector2 MoveInputs => MovementAction.ReadValue<Vector2>();

        public SpaceshipInputSystem()
        {
            _spaceshipInputs = new SpaceshipInputs();

            MovementAction = _spaceshipInputs.Spaceship.MoveForward;
            FirstFireAction = _spaceshipInputs.Spaceship.FirstFire;
            SecondFireAction = _spaceshipInputs.Spaceship.SecondFire;
        }

        public void Enable() => _spaceshipInputs.Enable();
        public void Disable() => _spaceshipInputs.Disable();
    }
}