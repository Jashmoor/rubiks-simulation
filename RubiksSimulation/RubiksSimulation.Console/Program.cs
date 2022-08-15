// See https://aka.ms/new-console-template for more information
using RubiksSimulation.Core;

string help = @"

print : Print the current state of the cube.

f : Rotate the front face 90' clockwise
f' : Rotate the front face 90' counterclockwise
r : Rotate the right face 90' clockwise
r' : Rotate the right face 90' counterclockwise
u : Rotate the top face 90' clockwise
u' : Rotate the top face 90' counterclockwise
b : Rotate the back face 90' clockwise
b' : Rotate the back face 90' counterclockwise
l : Rotate the left face 90' clockwise
l' : Rotate the left face 90' counterclockwise
d : Rotate the bottom face 90' clockwise
d' : Rotate the bottom face 90' counterclockwise

reset: reset all of the faces to their initial state
help: display these commands again.
exit: Exit the simulation

";

Console.WriteLine("Rubiks Cube Simulation");
Console.WriteLine("Heres a list of commands");
Console.WriteLine(help);

Rubik cube = new Rubik();

cube.CubeMoved += (object sender, CubeMovementEvent e) =>
{
    Console.WriteLine($"Moving Cube {e.Orientation} {e.Direction}");
};

cube.CubeSolved += (object sender, CubeSolved e) =>
{
    Console.WriteLine(e.Message);
};

bool escape = false;

while (escape != true)
{

    Console.WriteLine("Enter a command");
    string? command = Console.ReadLine();

    if (!string.IsNullOrEmpty(command))
    {
        command = command.Trim().ToLower();

        if (command == "exit")
        {
            escape = true;
            continue;
        }

        if (command == "print")
        {
            Console.WriteLine(cube.ToString());
            continue;
        }

        if (command == "help")
        {
            Console.WriteLine(help);
            continue;
        }

        if (command == "reset")
        {
            cube.Reset();
            continue;
        }
        try
        {
            _ = command switch
            {
                "f" => cube.Rotate(Orientation.Front, Direction.Clockwise),
                "f'" => cube.Rotate(Orientation.Front, Direction.CounterClockwise),
                "r" => cube.Rotate(Orientation.Right, Direction.Clockwise),
                "r'" => cube.Rotate(Orientation.Right, Direction.CounterClockwise),
                "u" => cube.Rotate(Orientation.Top, Direction.Clockwise),
                "u'" => cube.Rotate(Orientation.Top, Direction.CounterClockwise),
                "b" => cube.Rotate(Orientation.Back, Direction.Clockwise),
                "b'" => cube.Rotate(Orientation.Back, Direction.CounterClockwise),
                "l" => cube.Rotate(Orientation.Left, Direction.Clockwise),
                "l'" => cube.Rotate(Orientation.Left, Direction.CounterClockwise),
                "d" => cube.Rotate(Orientation.Bottom, Direction.Clockwise),
                "d'" => cube.Rotate(Orientation.Bottom, Direction.CounterClockwise),
                _ => cube
            };

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    };
}
