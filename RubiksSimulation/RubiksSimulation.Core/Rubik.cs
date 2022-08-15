namespace RubiksSimulation.Core
{
    public partial class Rubik
    {

        private IEnumerable<Face> State;
        private IEnumerable<IMoveStrategy> _Movements;

        public Rubik()
        {
            State = new Face[] {
                new Face(Color.Green, Orientation.Front),
                new Face(Color.Red, Orientation.Right),
                new Face(Color.White, Orientation.Top),
                new Face(Color.Blue, Orientation.Back),
                new Face(Color.Orange, Orientation.Left),
                new Face(Color.Yellow, Orientation.Bottom),
            };
            _Movements = new IMoveStrategy[] {
                new FrontMoveStrategy(this),
                new LeftMoveStrategy(this),
                new RightMoveStrategy(this),
                new BackMoveStrategy(this),
                new TopMoveStrategy(this),
                new BottomMoveStrategy(this),
        };
        }

        public Face GetFace(Orientation orientation)
            => State.FirstOrDefault(f => f == orientation) ?? throw new Exception("Face not assigned to cube");

        public Rubik Rotate(Orientation orientation, Direction direction)
        {
            IMoveStrategy strategy = _Movements.FirstOrDefault(f => f.Orientation == orientation)
                ?? throw new Exception($"Movement strategy not found for Face {orientation} => {direction}");

            strategy.Move(direction);
            CubeMoved?.Invoke(this, new CubeMovementEvent(orientation, direction));
            return this;
        }

        public void Reset()
        {
            foreach (Face face in State)
                face.Reset();
        }

        public EventHandler<CubeMovementEvent> CubeMoved;
        public EventHandler<CubeSolved> CubeSolved;


        public override string ToString()
            => $@"{string.Join(" ", State.Select(f => f.ToString()))}";
    }
}
