namespace Models.MovementSystems
{
    public interface IAccelerationMovement : IMovement
    {
        float RotationSpeed { get; }
        float AccelerationTime { get; }
    }
}