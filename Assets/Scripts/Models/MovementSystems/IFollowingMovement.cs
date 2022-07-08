namespace Models.MovementSystems
{
    public interface IFollowingMovement : IMovement
    {
        float TurningSpeed { get; }
    }
}