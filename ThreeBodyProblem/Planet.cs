using System;
using System.Drawing;

namespace ThreeBodyProblem
{
    public class Planet
    {
        public double[] Position { get; set; }
        public double[] Velocity { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool Attached { get; set; }
        public Color Color { get; set; }

        public Planet()
        {
            Attached = false;
            Position = new double[2];
            Velocity = new double[2];
        }

        public Planet(Rectangle bbox, Color color, double velx, double vely)
        {
            BoundingBox = bbox;
            Color = color;
            Attached = false;
            Position = new double[2];
            Position[0] = GetCenter().X;
            Position[1] = GetCenter().Y;
            Velocity = new double[2];
            Velocity[0] = velx;
            Velocity[1] = vely;
        }

        /// <summary>
        /// Create a new bounding box based on planet center and size
        /// </summary>
        /// <param name="center">Center of planet</param>
        /// <param name="newBox">Size of new planet</param>
        public void TranslateBoundingBox(Point center, Rectangle newBox)
        {
            BoundingBox = new Rectangle(center.X - (int)Math.Round(((newBox.Width) / 2.0)),
                center.Y - (int)Math.Round(((newBox.Height) / 2.0)), newBox.Width, newBox.Height);
        }

        /// <summary>
        /// Get center of planet
        /// </summary>
        /// <returns>Center</returns>
        public Point GetCenter()
        {
            Point center = new Point(BoundingBox.X + (int)(BoundingBox.Width / 2.0),
                BoundingBox.Y + (int)(BoundingBox.Height / 2.0));

            return center;
        }

        public Planet Copy()
        {
            return new Planet(BoundingBox, Color, Velocity[0], Velocity[1]);
        }
    }
}
