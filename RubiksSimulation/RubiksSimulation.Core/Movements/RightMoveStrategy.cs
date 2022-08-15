
namespace RubiksSimulation.Core
{
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
}
