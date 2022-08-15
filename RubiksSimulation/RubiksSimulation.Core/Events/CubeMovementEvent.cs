namespace RubiksSimulation.Core
{
    public class CubeMovementEvent : EventArgs
    {
        public CubeMovementEvent(Orientation orientation, Direction direction)
        {
            Orientation = orientation;
            Direction = direction;
        }

        public Orientation Orientation { get; }
        public Direction Direction { get; }
    }
}
