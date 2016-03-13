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
        public delegate double[] DifferentialEquation(Planet planet1, Planet planet2, Planet planet3);

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
            DifferentialEquation velocityDE = new DifferentialEquation(AccelDE);
            EvaluateDE(planets[0], planets[1], planets[2], velocityDE);
            EvaluateDE(planets[1], planets[0], planets[2], velocityDE);
            EvaluateDE(planets[2], planets[0], planets[1], velocityDE);
            planets[0].TranslateBoundingBox(new Point((int)planets[0].Position[0], (int)planets[0].Position[1]), planets[0].BoundingBox);
            planets[1].TranslateBoundingBox(new Point((int)planets[1].Position[0], (int)planets[1].Position[1]), planets[1].BoundingBox);
            planets[2].TranslateBoundingBox(new Point((int)planets[2].Position[0], (int)planets[2].Position[1]), planets[2].BoundingBox);
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
        /// <param name="f"></param>
        private void EvaluateDE(Planet planet, Planet force1, Planet force2, DifferentialEquation f)
        {
            double step = 0.01;
            double[] dx1 = planet.Velocity.Select(x => step * x).ToArray();
            double[] dv1 = f(planet, force1, force2).Select(x => step * x).ToArray();
            double[] dx2 = new double[2];
            dx2[0] = step * (planet.Velocity[0] + (dv1[0] / 2));
            dx2[1] = step * (planet.Velocity[1] + (dv1[1] / 2));
            Planet temp1 = new Planet(planet.BoundingBox, planet.Color, planet.Velocity[0], planet.Velocity[1]);
            temp1.Position[0] = planet.Position[0] + (dx1[0]/2);
            temp1.Position[1] = planet.Position[1] + (dx1[1]/2);
            double[] dv2 = f(temp1, force1, force2).Select(x => step * x).ToArray();
            double[] dx3 = new double[2];
            dx3[0] = step * (planet.Velocity[0] + (dv2[0] / 2));
            dx3[1] = step * (planet.Velocity[1] + (dv2[1] / 2));
            Planet temp2 = new Planet(planet.BoundingBox, planet.Color, planet.Velocity[0], planet.Velocity[1]);
            temp2.Position[0] = planet.Position[0] + (dx2[0]/2);
            temp2.Position[1] = planet.Position[1] + (dx2[1]/2);
            double[] dv3 = f(temp2, force1, force2).Select(x => step * x).ToArray();
            double[] dx4 = new double[2];
            dx4[0] = step * (planet.Velocity[0] + dv3[0]);
            dx4[1] = step * (planet.Velocity[1] + dv3[1]);
            Planet temp3 = new Planet(planet.BoundingBox, planet.Color, planet.Velocity[0], planet.Velocity[1]);
            temp3.Position[0] = planet.Position[0] + dx3[0];
            temp3.Position[1] = planet.Position[1] + dx3[1];
            double[] dv4 = f(temp3, force1, force2).Select(x => step * x).ToArray();

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
            // we need to manually push one slightly so they don't fly off to infinity
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
        private double[] AccelDE(Planet planet, Planet force1, Planet force2)
        {
            double[] accel = new double[2];
            double constantF1 = 5000000 / Math.Pow(CalculateDistance(planet, force1), 3);
            double constantF2 = 5000000 / Math.Pow(CalculateDistance(planet, force2), 3);

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
