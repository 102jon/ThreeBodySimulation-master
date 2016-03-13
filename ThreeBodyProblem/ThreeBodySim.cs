using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ThreeBodyProblem
{
    public partial class ThreeBodySim : Form
    {
        private Engine engine;
        private Planet[] planets = new Planet[3];
        private Planet[] initialState = new Planet[3];
        private int size = 20;
        private bool firstRun = true;

        public ThreeBodySim()
        {
            InitializeComponent();
            // Initialize planets with default settings          
            planets[0] = new Planet(new Rectangle(150, 235, size, size), Color.CornflowerBlue, 0, 0);
            planets[1] = new Planet(new Rectangle(334, 235, size, size), Color.Red, 0, 0);
            planets[2] = new Planet(new Rectangle(518, 235, size, size), Color.LawnGreen, 0, 0);
        }

        private void displayPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (Planet planet in this.planets)
            {
                e.Graphics.FillEllipse(new SolidBrush(planet.Color), planet.BoundingBox);
            }
        }

        private void displayPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Attach front-most planet containing mouse (if any)
            if (xVelPlanet1.Enabled)
            {
                for (int i = planets.Length - 1; i >= 0; i--)
                {
                    if (planets[i].BoundingBox.Contains(e.Location))
                    {
                        planets[i].Attached = true;
                        return;
                    }
                }
            }
        }

        private void displayPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Translate the bounding box of an attached planet to mouse location
            if (displayPanel.DisplayRectangle.Contains(e.Location))
            {
                planets = (planets.Select(x =>
                    {
                        if (x.Attached) 
                        {
                            x.TranslateBoundingBox(e.Location, x.BoundingBox);
                            x.Position[0] = x.GetCenter().X;
                            x.Position[1] = x.GetCenter().Y;
                            firstRun = true;
                            return x;
                        }
                        else return x;
                    })).ToArray();

                displayPanel.Invalidate();         
            }
        }

        private void displayPanel_MouseUp(object sender, MouseEventArgs e)
        {
            // Detach any attached planet
            planets = (planets.Select(x =>
            {
                if (x.Attached) return new Planet(x.BoundingBox, x.Color, x.Velocity[0], x.Velocity[1]);
                else return x;
            })).ToArray();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start")
            {
                if (firstRun)
                {
                    initialState[0] = planets[0].Copy();
                    initialState[1] = planets[1].Copy();
                    initialState[2] = planets[2].Copy();
                    firstRun = false;
                }

                // Instantiate background worker and begin simulation
                engine = new Engine();
                engine.WorkerReportsProgress = true;
                engine.WorkerSupportsCancellation = true;
                engine.DoWork += engine.backgroundWorker_DoWork;
                engine.ProgressChanged += engine_ProgressChanged;
                engine.RunWorkerAsync(planets);
                startBtn.Text = "Pause";
                resetBtn.Enabled = false;
                toolStrip1.Enabled = false;
                xVelPlanet1.Enabled = false;
                yVelPlanet1.Enabled = false;
                xVelPlanet2.Enabled = false;
                yVelPlanet2.Enabled = false;
                xVelPlanet3.Enabled = false;
                yVelPlanet3.Enabled = false;
            }
            else
            {
                if (engine != null)
                {
                    if (engine.IsBusy)
                        engine.CancelAsync();

                    while (engine.IsBusy)
                        Application.DoEvents();

                    engine.Dispose();

                    // Return to a cartesian system for the user; set positive y to be up rather than down
                    foreach (Planet pln in planets)
                        pln.Velocity[1] *= -1;
                }

                startBtn.Text = "Start";
                resetBtn.Enabled = true;
                toolStrip1.Enabled = true;
            }
        }

        private void engine_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            planets = (Planet[])e.UserState;
            displayPanel.Invalidate();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            planets[0] = initialState[0].Copy();
            planets[1] = initialState[1].Copy();
            planets[2] = initialState[2].Copy();
            foreach (Planet pln in planets)
                pln.TranslateBoundingBox(pln.GetCenter(), pln.BoundingBox);

            xVelPlanet1.Enabled = true;
            yVelPlanet1.Enabled = true;
            xVelPlanet2.Enabled = true;
            yVelPlanet2.Enabled = true;
            xVelPlanet3.Enabled = true;
            yVelPlanet3.Enabled = true;

            firstRun = true;
            displayPanel.Invalidate();
        }

        private void ThreeBodySim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (engine != null)
            {
                if (engine.IsBusy)
                    engine.CancelAsync();

                while (engine.IsBusy)
                    Application.DoEvents();

                engine.Dispose();
            }
        }

        private void xVelPlanet1_Scroll(object sender, EventArgs e)
        {
            planets[0].Velocity[0] = xVelPlanet1.Value;
            firstRun = true;
        }

        private void yVelPlanet1_Scroll(object sender, EventArgs e)
        {
            planets[0].Velocity[1] = yVelPlanet1.Value;
            firstRun = true;
        }

        private void xVelPlanet2_Scroll(object sender, EventArgs e)
        {
            planets[1].Velocity[0] = xVelPlanet2.Value;
            firstRun = true;
        }

        private void yVelPlanet2_Scroll(object sender, EventArgs e)
        {
            planets[1].Velocity[1] = yVelPlanet2.Value;
            firstRun = true;
        }

        private void xVelPlanet3_Scroll(object sender, EventArgs e)
        {
            planets[2].Velocity[0] = xVelPlanet3.Value;
            firstRun = true;
        }

        private void yVelPlanet3_Scroll(object sender, EventArgs e)
        {
            planets[2].Velocity[1] = yVelPlanet3.Value;
            firstRun = true;
        }

        // Here are some preset orbit settings the user can try to see how the application works
        private void sampleDropBtn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            firstRun = true;
            xVelPlanet1.Enabled = true;
            yVelPlanet1.Enabled = true;
            xVelPlanet2.Enabled = true;
            yVelPlanet2.Enabled = true;
            xVelPlanet3.Enabled = true;
            yVelPlanet3.Enabled = true;
            resetBtn.Enabled = false;
            sampleDropBtn.Text = e.ClickedItem.Text;
            int[] pos1 = new int[] { 0, 0 };
            int[] pos2 = new int[] { 0, 0 };
            int[] pos3 = new int[] { 0, 0 };

            if (e.ClickedItem.Text == "Orbit 1")
            {
                xVelPlanet1.Value = 0;
                yVelPlanet1.Value = -200;
                pos1 = new int[] { 150, 235 };

                xVelPlanet2.Value = 0;
                yVelPlanet2.Value = 0;
                pos2 = new int[] { 334, 235 };

                xVelPlanet3.Value = 0;
                yVelPlanet3.Value = 200;
                pos3 = new int[] { 518, 235 };
            }
            else if (e.ClickedItem.Text == "Orbit 2")
            {
                xVelPlanet1.Value = 45;
                yVelPlanet1.Value = 38;
                pos1 = new int[] { 150, 278 };

                xVelPlanet2.Value = 45;
                yVelPlanet2.Value = 38;
                pos2 = new int[] { 334, 235 };

                xVelPlanet3.Value = -90;
                yVelPlanet3.Value = -75;
                pos3 = new int[] { 518, 192 };
            }

            planets[0] = new Planet(new Rectangle(pos1[0], pos1[1], size, size), Color.CornflowerBlue, xVelPlanet1.Value, yVelPlanet1.Value);
            planets[1] = new Planet(new Rectangle(pos2[0], pos2[1], size, size), Color.Red, xVelPlanet2.Value, yVelPlanet2.Value);
            planets[2] = new Planet(new Rectangle(pos3[0], pos3[1], size, size), Color.LawnGreen, xVelPlanet3.Value, yVelPlanet3.Value);
        }
    }

    /// <summary>
    /// Custom Panel class optimized for graphics
    /// </summary>
    public class DisplayPanel : Panel
    {
        public DisplayPanel()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
}
