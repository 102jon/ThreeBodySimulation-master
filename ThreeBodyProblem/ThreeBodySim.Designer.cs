namespace ThreeBodyProblem
{
    partial class ThreeBodySim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThreeBodySim));
            this.startBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yVelPlanet3 = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.xVelPlanet3 = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.yVelPlanet2 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.xVelPlanet2 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.yVelPlanet1 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.xVelPlanet1 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sampleDropBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.sample1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sample2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeLbl = new System.Windows.Forms.Label();
            this.displayPanel = new ThreeBodyProblem.DisplayPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yVelPlanet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xVelPlanet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yVelPlanet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xVelPlanet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yVelPlanet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xVelPlanet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(577, 538);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(126, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.yVelPlanet3);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.xVelPlanet3);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.yVelPlanet2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.xVelPlanet2);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.yVelPlanet1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.xVelPlanet1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Location = new System.Drawing.Point(12, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 158);
            this.panel2.TabIndex = 3;
            // 
            // yVelPlanet3
            // 
            this.yVelPlanet3.Location = new System.Drawing.Point(440, 103);
            this.yVelPlanet3.Maximum = 200;
            this.yVelPlanet3.Minimum = -200;
            this.yVelPlanet3.Name = "yVelPlanet3";
            this.yVelPlanet3.Size = new System.Drawing.Size(112, 45);
            this.yVelPlanet3.TabIndex = 25;
            this.yVelPlanet3.Scroll += new System.EventHandler(this.yVelPlanet3_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(383, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Y Velocity:";
            // 
            // xVelPlanet3
            // 
            this.xVelPlanet3.Location = new System.Drawing.Point(440, 73);
            this.xVelPlanet3.Maximum = 200;
            this.xVelPlanet3.Minimum = -200;
            this.xVelPlanet3.Name = "xVelPlanet3";
            this.xVelPlanet3.Size = new System.Drawing.Size(112, 45);
            this.xVelPlanet3.TabIndex = 23;
            this.xVelPlanet3.Scroll += new System.EventHandler(this.xVelPlanet3_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(383, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "X Velocity:";
            // 
            // yVelPlanet2
            // 
            this.yVelPlanet2.Location = new System.Drawing.Point(251, 103);
            this.yVelPlanet2.Maximum = 200;
            this.yVelPlanet2.Minimum = -200;
            this.yVelPlanet2.Name = "yVelPlanet2";
            this.yVelPlanet2.Size = new System.Drawing.Size(112, 45);
            this.yVelPlanet2.TabIndex = 21;
            this.yVelPlanet2.Scroll += new System.EventHandler(this.yVelPlanet2_Scroll);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Y Velocity:";
            // 
            // xVelPlanet2
            // 
            this.xVelPlanet2.Location = new System.Drawing.Point(251, 73);
            this.xVelPlanet2.Maximum = 200;
            this.xVelPlanet2.Minimum = -200;
            this.xVelPlanet2.Name = "xVelPlanet2";
            this.xVelPlanet2.Size = new System.Drawing.Size(112, 45);
            this.xVelPlanet2.TabIndex = 19;
            this.xVelPlanet2.Scroll += new System.EventHandler(this.xVelPlanet2_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "X Velocity:";
            // 
            // yVelPlanet1
            // 
            this.yVelPlanet1.Location = new System.Drawing.Point(67, 108);
            this.yVelPlanet1.Maximum = 200;
            this.yVelPlanet1.Minimum = -200;
            this.yVelPlanet1.Name = "yVelPlanet1";
            this.yVelPlanet1.Size = new System.Drawing.Size(104, 45);
            this.yVelPlanet1.TabIndex = 17;
            this.yVelPlanet1.Scroll += new System.EventHandler(this.yVelPlanet1_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Y Velocity:";
            // 
            // xVelPlanet1
            // 
            this.xVelPlanet1.Location = new System.Drawing.Point(67, 73);
            this.xVelPlanet1.Maximum = 200;
            this.xVelPlanet1.Minimum = -200;
            this.xVelPlanet1.Name = "xVelPlanet1";
            this.xVelPlanet1.Size = new System.Drawing.Size(104, 45);
            this.xVelPlanet1.TabIndex = 15;
            this.xVelPlanet1.Scroll += new System.EventHandler(this.xVelPlanet1_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "X Velocity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label3.Location = new System.Drawing.Point(436, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Planet 3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(247, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Planet 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(63, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Planet 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(182, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(195, 158);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(182, 158);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(580, 599);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Created by:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(647, 599);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Jon Martin";
            // 
            // resetBtn
            // 
            this.resetBtn.Enabled = false;
            this.resetBtn.Location = new System.Drawing.Point(577, 567);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(126, 23);
            this.resetBtn.TabIndex = 8;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleDropBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(715, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sampleDropBtn
            // 
            this.sampleDropBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sampleDropBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sample1ToolStripMenuItem,
            this.sample2ToolStripMenuItem});
            this.sampleDropBtn.Image = ((System.Drawing.Image)(resources.GetObject("sampleDropBtn.Image")));
            this.sampleDropBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sampleDropBtn.Name = "sampleDropBtn";
            this.sampleDropBtn.Size = new System.Drawing.Size(96, 22);
            this.sampleDropBtn.Text = "Preset Orbits...";
            this.sampleDropBtn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sampleDropBtn_DropDownItemClicked);
            // 
            // sample1ToolStripMenuItem
            // 
            this.sample1ToolStripMenuItem.Name = "sample1ToolStripMenuItem";
            this.sample1ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.sample1ToolStripMenuItem.Text = "Orbit 1";
            // 
            // sample2ToolStripMenuItem
            // 
            this.sample2ToolStripMenuItem.Name = "sample2ToolStripMenuItem";
            this.sample2ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.sample2ToolStripMenuItem.Text = "Orbit 2";
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(590, 510);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(104, 13);
            this.timeLbl.TabIndex = 10;
            this.timeLbl.Text = "Time Elapsed: 00:00";
            // 
            // displayPanel
            // 
            this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.displayPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.displayPanel.Location = new System.Drawing.Point(13, 13);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(690, 477);
            this.displayPanel.TabIndex = 2;
            this.displayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.displayPanel_Paint);
            this.displayPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.displayPanel_MouseDown);
            this.displayPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.displayPanel_MouseMove);
            this.displayPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.displayPanel_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ThreeBodySim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 661);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.startBtn);
            this.MaximizeBox = false;
            this.Name = "ThreeBodySim";
            this.Text = "Three Body Simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreeBodySim_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yVelPlanet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xVelPlanet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yVelPlanet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xVelPlanet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yVelPlanet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xVelPlanet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private DisplayPanel displayPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar yVelPlanet3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar xVelPlanet3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar yVelPlanet2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar xVelPlanet2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar yVelPlanet1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar xVelPlanet1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton sampleDropBtn;
        private System.Windows.Forms.ToolStripMenuItem sample1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sample2ToolStripMenuItem;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Timer timer1;
    }
}

