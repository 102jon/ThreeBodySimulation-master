using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBodyProblem
{
    public partial class Engine : BackgroundWorker
    {
        // We specify masses of 5000000; it is just an arbitrary number that works with our
        // units of distance and velocity. Can be changed at any time
        private double mass = 5000000;

        public Engine()
        {
            InitializeComponent();
        }

        public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Planet[] planets = (Planet[])e.Argument;

            // Y-direction is actually the reverse of a normal cartesian plane;
            // positive direction is down rather than up
            foreach (Planet pln in planets)
            {
                pln.Velocity[1] *= -1;
            }

            // Run the simulation until the user stops it
            while (!CancellationPending)
            {
                RunSimulation(planets);
            }

            e.Cancel = true;
            return;
        }

        /// <summary>
        /// Runs the simulation for one time step. The differential equation is solved for each planet,
        /// giving them new positions and velocities.
        /// </summary>
        /// <param name="planets"></param>
        private void RunSimulation(Planet[] planets)
        {      
            EvaluateDE(planets[0], planets[1], planets[2]);
            EvaluateDE(planets[1], planets[0], planets[2]);
            EvaluateDE(planets[2], planets[0], planets[1]);
            foreach (Planet pln in planets)
                pln.TranslateBoundingBox(new Point((int)pln.Position[0], (int)pln.Position[1]), pln.BoundingBox);

            ReportProgress(0, planets);
            System.Threading.Thread.Sleep(10);
        }

        /// <summary>
        /// This function is the heart of the application. It solves the differential equation
        /// numerically using the 4th order Runge-Kutta method. Note that since our differential equation
        /// is a 2nd order DE, we have to solve for velocity and position changes in conjunction.
        /// </summary>
        /// <param name="planet"></param>
        /// <param name="force1"></param>
        /// <param name="force2"></param>
        private void EvaluateDE(Planet planet, Planet force1, Planet force2)
        {
            double step = 0.01;

            // Compute initial slopes for velocity and position
            double[] dx1 = planet.Velocity.Select(x => step * x).ToArray();
            double[] dv1 = DifferentialEquation(planet, force1, force2).Select(x => step * x).ToArray();

            // Compute mid-point slopes for velocity and position
            double[] dx2 = new double[2];
            dx2[0] = step * (planet.Velocity[0] + (dv1[0] / 2));
            dx2[1] = step * (planet.Velocity[1] + (dv1[1] / 2));
            Planet temp = planet.Copy();
            temp.Position[0] = planet.Position[0] + (dx1[0]/2);
            temp.Position[1] = planet.Position[1] + (dx1[1]/2);
            double[] dv2 = DifferentialEquation(temp, force1, force2).Select(x => step * x).ToArray();

            // Compute second mid-point slopes for velocity and position
            double[] dx3 = new double[2];
            dx3[0] = step * (planet.Velocity[0] + (dv2[0] / 2));
            dx3[1] = step * (planet.Velocity[1] + (dv2[1] / 2));
            temp = planet.Copy();
            temp.Position[0] = planet.Position[0] + (dx2[0]/2);
            temp.Position[1] = planet.Position[1] + (dx2[1]/2);
            double[] dv3 = DifferentialEquation(temp, force1, force2).Select(x => step * x).ToArray();

            // Compute end-point slopes for velocity and position
            double[] dx4 = new double[2];
            dx4[0] = step * (planet.Velocity[0] + dv3[0]);
            dx4[1] = step * (planet.Velocity[1] + dv3[1]);
            temp = planet.Copy();
            temp.Position[0] = planet.Position[0] + dx3[0];
            temp.Position[1] = planet.Position[1] + dx3[1];
            double[] dv4 = DifferentialEquation(temp, force1, force2).Select(x => step * x).ToArray();

            // Weighted average of 4 slopes will be the change in velocity and position of the planet
            double[] dx = new double[2];
            dx[0] = (dx1[0] + (2 * dx2[0]) + (2 * dx3[0]) + dx4[0]) / 6.0;
            dx[1] = (dx1[1] + (2 * dx2[1]) + (2 * dx3[1]) + dx4[1]) / 6.0;

            double[] dv = new double[2];
            dv[0] = (dv1[0] + (2 * dv2[0]) + (2 * dv3[0]) + dv4[0]) / 6.0;
            dv[1] = (dv1[1] + (2 * dv2[1]) + (2 * dv3[1]) + dv4[1]) / 6.0;

            planet.Velocity[0] += dv[0];
            planet.Velocity[1] += dv[1];
            planet.Position[0] += dx[0];
            planet.Position[1] += dx[1];

            // If two planets get dangerously close that they could occupy the same position,
            // we need to manually push one slightly to avoid division by zero
            if (CalculateDistance(planet, force1) <= 1)
                HandleEpsilon(planet, force1);

            else if (CalculateDistance(planet, force2) <= 1)
                HandleEpsilon(planet, force1);
        }

        /// <summary>
        /// The differential equation representing the total force acting on a given planet.
        /// The second time derivative of a planet's displacement is its acceleration.
        /// </summary>
        /// <param name="planet"></param>
        /// <param name="force1"></param>
        /// <param name="force2"></param>
        /// <returns>Acceleration of the planet</returns>
        private double[] DifferentialEquation(Planet planet, Planet force1, Planet force2)
        {
            double[] accel = new double[2];
            double constantF1 = mass / Math.Pow(CalculateDistance(planet, force1), 3);
            double constantF2 = mass / Math.Pow(CalculateDistance(planet, force2), 3);

            accel[0] = (constantF1 * (force1.Position[0] - planet.Position[0])) + (constantF2 * (force2.Position[0] - planet.Position[0]));
            accel[1] = (constantF1 * (force1.Position[1] - planet.Position[1])) + (constantF2 * (force2.Position[1] - planet.Position[1]));

            return accel;
        }

        /// <summary>
        /// Calculate the distance between two planets
        /// </summary>
        /// <param name="planet1"></param>
        /// <param name="planet2"></param>
        /// <returns>Value of distance</returns>
        private double CalculateDistance(Planet planet1, Planet planet2)
        {
            return Math.Sqrt(
                Math.Pow(planet1.Position[0] - planet2.Position[0], 2)
                + Math.Pow(planet1.Position[1] - planet2.Position[1], 2)
                );
        }

        /// <summary>
        /// If two planets are close enough that they might occupy the same position, manually 
        /// push one planet to the other side to prevent them flying off to infinity
        /// </summary>
        /// <param name="planet1"></param>
        /// <param name="planet2"></param>
        private void HandleEpsilon(Planet planet1, Planet planet2)
        {
            if (planet1.Position[0] <= planet2.Position[0] && planet1.Velocity[0] > 0)
                planet1.Position[0] = planet2.Position[0] + 1;
            else if (planet1.Position[0] > planet2.Position[0] && planet1.Velocity[0] < 0)
                planet1.Position[0] = planet2.Position[0] - 1;

            if (planet1.Position[1] <= planet2.Position[1] && planet1.Velocity[1] > 0)
                planet1.Position[1] = planet2.Position[1] + 1;
            else if (planet1.Position[1] > planet2.Position[1] && planet1.Velocity[1] < 0)
                planet1.Position[1] = planet2.Position[1] - 1;
        }
    }
}
