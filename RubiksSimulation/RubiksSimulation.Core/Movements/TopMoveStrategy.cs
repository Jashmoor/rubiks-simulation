
namespace RubiksSimulation.Core
{
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
}
