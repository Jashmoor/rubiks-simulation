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
}
