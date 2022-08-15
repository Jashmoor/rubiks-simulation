# Rubiks Simulation

pull down the repository and open in your favourite IDE

make sure the RubiksSimulation.Console is the startup project

Run the project

## Commands

the 'front' face of the cube is locked to the green side and follows the same
layout of the 3d solver found here:

[Rubiks Solver](https://rubiks-cube-solver.com/).

a list of commands will display on load and you can follow them in your console
or type 'help' to display the commands again

```
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
```
