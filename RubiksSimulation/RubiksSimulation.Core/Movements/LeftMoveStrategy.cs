
namespace RubiksSimulation.Core
{
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
}
