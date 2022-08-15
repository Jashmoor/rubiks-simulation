
namespace RubiksSimulation.Core
{

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
}
