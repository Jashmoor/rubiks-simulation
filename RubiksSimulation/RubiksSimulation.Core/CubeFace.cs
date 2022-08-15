namespace RubiksSimulation.Core
{
    public class Face
    {
        private Color[,] _Colors { get; set; }

        public Face(Color color, Orientation orientation)
        {
            Color = color;
            Orientation = orientation;

            _Colors = new Color[3, 3] {
             { color, color, color },
             { color, color, color },
             { color, color, color }
            };
        }

        public Color this[int row, int column]
        {
            get { return _Colors[row, column]; }
            set { _Colors[row, column] = value; }
        }

        private Color Color { get; init; }
        public Orientation Orientation { get; init; }
        public Color[,] Colors => _Colors;

        public void Rotate()
        {
            Color[,] @new = new Color[3, 3];

            for (int i = 2; i >= 0; i--)
                for (int j = 0; j < 3; j++)
                    @new[j, 2 - i] = Colors[i, j];

            _Colors = @new;
        }

        public void Reset()
        {
            _Colors = new Color[3, 3] {
                { Color, Color,Color },
                { Color, Color, Color },
                { Color, Color, Color }
            };
        }

        public static explicit operator Color[,](Face face) => face.Colors;
        public static implicit operator Orientation(Face face) => face.Orientation;
        public override string ToString()
        => $@"
        {Orientation} : ===================================
        {_Colors[0, 0]} - {_Colors[0, 1]} - {_Colors[0, 2]}
        {_Colors[1, 0]} - {_Colors[1, 1]} - {_Colors[1, 2]}
        {_Colors[2, 0]} - {_Colors[2, 1]} - {_Colors[2, 2]}
        ";
    }

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

    public class CubeSolved : EventArgs
    {
        public string Message => "Congratulations !!!!";
    }
}
