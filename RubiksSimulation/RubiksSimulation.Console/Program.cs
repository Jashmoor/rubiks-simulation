// See https://aka.ms/new-console-template for more information
using RubiksSimulation.Core;

string help = @"

print : Print the current state of the cube.
f : Rotate the front face 90' clockwise
f' : Rotate the front face 90' counterclockwise
reset: reset all of the faces to their initial state
help: display these commands again.
exit: Exit the simulation

";

Console.WriteLine("Rubiks Cube Simulation");
Console.WriteLine("Heres a list of commands");
Console.WriteLine(help);

Rubik cube = new Rubik();

cube.CubeMoved += (object sender, CubeMovementEvent e) => {
    Console.WriteLine($"Moving Cube {e.Orientation} {e.Direction}");
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

        if(command == "help"){
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
