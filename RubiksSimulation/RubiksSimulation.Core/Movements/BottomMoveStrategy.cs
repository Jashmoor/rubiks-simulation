
namespace RubiksSimulation.Core
{
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
