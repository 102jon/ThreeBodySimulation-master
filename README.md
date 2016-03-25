# ThreeBodySimulation-master
C# Application to simulate the motion of 3 planets in gravitational space

The three body problem is a popular area of study in physics, differential equations and numerical approximation.
This application simulates the motion of three planetary objects in space (in two dimensions); the user can set some initial
conditions for the planets and then start the simulation, which graphically depicts the objects interacting in space.

The code for this application is organized as follows:

ThreeBodySim.cs - Implements all graphics and event-handling related to the user interface.

Planet.cs - The class file for Planet objects, contains methods and properties related to the planets.

Engine.cs - A background worker that does all the calculations in the simulation. Contains the differential equation,
a numerical integration solver, and helper methods.
