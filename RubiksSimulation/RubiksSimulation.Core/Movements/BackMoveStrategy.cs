
namespace RubiksSimulation.Core
{
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
}
