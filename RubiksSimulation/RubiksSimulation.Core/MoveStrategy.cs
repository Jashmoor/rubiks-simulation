
namespace RubiksSimulation.Core
{
    public interface IMoveStrategy
    {
        void Move(Direction direction);
        abstract Orientation Orientation { get; }
    }

    public class FrontMoveStrategy : IMoveStrategy
    {
        private readonly Rubik _Cube;
        private readonly Face Target;

        public FrontMoveStrategy(Rubik cube)
        {
            _Cube = cube;
            Target = _Cube.GetFace(Orientation);
        }

        public Orientation Orientation => Orientation.Front;

        public void Move(Direction direction)
        {
            int rotations = (int)direction;
            while (rotations != 0)
            {
                Face top = _Cube.GetFace(Orientation.Top);
                Face left = _Cube.GetFace(Orientation.Left);
                Face right = _Cube.GetFace(Orientation.Right);
                Face bottom = _Cube.GetFace(Orientation.Bottom);

                Color first = top[2, 0];
                Color second = top[2, 1];
                Color third = top[2, 2];

                top[2, 0] = left[2, 2];
                top[2, 1] = left[1, 2];
                top[2, 2] = left[0, 2];

                left[0, 2] = bottom[0, 0];
                left[1, 2] = bottom[0, 1];
                left[2, 2] = bottom[0, 2];

                bottom[0, 0] = right[0, 0];
                bottom[0, 1] = right[1, 0];
                bottom[0, 2] = right[2, 0];

                right[0, 0] = first;
                right[1, 0] = second;
                right[2, 0] = third;

                Target.Rotate();

                rotations--;
            }
        }
    }

    public class BackMoveStrategy : IMoveStrategy
    {
        private readonly Rubik _Cube;
        private readonly Face Target;

        public BackMoveStrategy(Rubik cube)
        {
            _Cube = cube;
            Target = _Cube.GetFace(Orientation);
        }

        public Orientation Orientation => Orientation.Back;

        public void Move(Direction direction)
        {
            int rotations = (int)direction;
            while (rotations != 0)
            {
                Face top = _Cube.GetFace(Orientation.Top);
                Face left = _Cube.GetFace(Orientation.Left);
                Face right = _Cube.GetFace(Orientation.Right);
                Face bottom = _Cube.GetFace(Orientation.Bottom);

                Color first = top[0, 2];
                Color second = top[0, 1];
                Color third = top[0, 0];

                top[0, 0] = right[0, 2];
                top[0, 1] = right[1, 2];
                top[0, 2] = right[2, 2];

                right[0, 2] = bottom[2, 2];
                right[1, 2] = bottom[2, 1];
                right[2, 2] = bottom[2, 0];

                bottom[2, 2] = left[2, 0];
                bottom[2, 1] = left[1, 0];
                bottom[2, 0] = left[0, 0];

                left[0, 0] = first;
                left[1, 0] = second;
                left[2, 0] = third;

                Target.Rotate();

                rotations--;
            }
        }
    }

    public class LeftMoveStrategy : IMoveStrategy
    {
        private readonly Rubik _Cube;
        private readonly Face Target;

        public LeftMoveStrategy(Rubik cube)
        {
            _Cube = cube;
            Target = _Cube.GetFace(Orientation);
        }

        public Orientation Orientation => Orientation.Left;

        public void Move(Direction direction)
        {
            int rotations = (int)direction;
            while (rotations != 0)
            {
                Face top = _Cube.GetFace(Orientation.Top);
                Face front = _Cube.GetFace(Orientation.Front);
                Face bottom = _Cube.GetFace(Orientation.Bottom);
                Face back = _Cube.GetFace(Orientation.Back);

                Color first = top[0, 0];
                Color second = top[1, 0];
                Color third = top[2, 0];

                top[0, 0] = back[2, 2];
                top[1, 0] = back[1, 2];
                top[2, 0] = back[0, 2];

                back[2, 2] = bottom[0, 0];
                back[1, 2] = bottom[1, 0];
                back[0, 2] = bottom[2, 0];

                bottom[0, 0] = front[0, 0];
                bottom[1, 0] = front[1, 0];
                bottom[2, 0] = front[2, 0];

                front[0, 0] = first;
                front[1, 0] = second;
                front[2, 0] = third;

                Target.Rotate();

                rotations--;
            }
        }
    }

    public class RightMoveStrategy : IMoveStrategy
    {
        private readonly Rubik _Cube;
        private readonly Face Target;

        public RightMoveStrategy(Rubik cube)
        {
            _Cube = cube;
            Target = _Cube.GetFace(Orientation);
        }

        public Orientation Orientation => Orientation.Right;

        public void Move(Direction direction)
        {
            int rotations = (int)direction;
            while (rotations != 0)
            {
                Face top = _Cube.GetFace(Orientation.Top);
                Face front = _Cube.GetFace(Orientation.Front);
                Face bottom = _Cube.GetFace(Orientation.Bottom);
                Face back = _Cube.GetFace(Orientation.Back);

                Color first = top[0, 2];
                Color second = top[1, 2];
                Color third = top[2, 2];

                top[0, 2] = front[0, 2];
                top[1, 2] = front[1, 2];
                top[2, 2] = front[2, 2];

                front[0, 2] = bottom[0, 2];
                front[1, 2] = bottom[1, 2];
                front[2, 2] = bottom[2, 2];

                bottom[0, 2] = back[2, 0];
                bottom[1, 2] = back[1, 0];
                bottom[2, 2] = back[0, 0];

                back[2, 0] = first;
                back[1, 0] = second;
                back[0, 0] = third;

                Target.Rotate();

                rotations--;
            }
        }
    }

    public class TopMoveStrategy : IMoveStrategy
    {
        private readonly Rubik _Cube;
        private readonly Face Target;

        public TopMoveStrategy(Rubik cube)
        {
            _Cube = cube;
            Target = _Cube.GetFace(Orientation);
        }

        public Orientation Orientation => Orientation.Top;

        public void Move(Direction direction)
        {
            int rotations = (int)direction;
            while (rotations != 0)
            {
                Face left = _Cube.GetFace(Orientation.Left);
                Face front = _Cube.GetFace(Orientation.Front);
                Face right = _Cube.GetFace(Orientation.Right);
                Face back = _Cube.GetFace(Orientation.Back);

                Color first = back[0, 0];
                Color second = back[0, 1];
                Color third = back[0, 2];

                back[0, 0] = left[0, 0];
                back[0, 1] = left[0, 1];
                back[0, 2] = left[0, 2];

                left[0, 0] = front[0, 0];
                left[0, 1] = front[0, 1];
                left[0, 2] = front[0, 2];

                front[0, 0] = right[0, 0];
                front[0, 1] = right[0, 1];
                front[0, 2] = right[0, 2];

                right[0, 0] = first;
                right[0, 1] = second;
                right[0, 2] = third;

                Target.Rotate();

                rotations--;
            }
        }
    }

    public class BottomMoveStrategy : IMoveStrategy
    {
        private readonly Rubik _Cube;
        private readonly Face Target;

        public BottomMoveStrategy(Rubik cube)
        {
            _Cube = cube;
            Target = _Cube.GetFace(Orientation);
        }

        public Orientation Orientation => Orientation.Bottom;

        public void Move(Direction direction)
        {
            int rotations = (int)direction;
            while (rotations != 0)
            {
                Face left = _Cube.GetFace(Orientation.Left);
                Face front = _Cube.GetFace(Orientation.Front);
                Face right = _Cube.GetFace(Orientation.Right);
                Face back = _Cube.GetFace(Orientation.Back);

                Color first = front[2, 0];
                Color second = front[2, 1];
                Color third = front[2, 2];

                front[2, 0] = left[2, 0];
                front[2, 1] = left[2, 1];
                front[2, 2] = left[2, 2];

                left[2, 0] = back[2, 0];
                left[2, 1] = back[2, 1];
                left[2, 2] = back[2, 2];

                back[2, 0] = right[2, 0];
                back[2, 1] = right[2, 1];
                back[2, 2] = right[2, 2];

                right[2, 0] = first;
                right[2, 1] = second;
                right[2, 2] = third;

                Target.Rotate();

                rotations--;
            }
        }
    }
}
