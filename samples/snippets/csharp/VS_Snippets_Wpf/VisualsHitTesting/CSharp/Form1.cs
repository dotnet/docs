namespace SDKSample
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyWindow.CreateShape(this.Handle);
        }

        private void FillWithCirclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyWindow.FillWithCircles(this.Handle);
        }

        private void SmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.radius = 30.0d;
            SmallToolStripMenuItem.Checked = true;
            MediumToolStripMenuItem.Checked = false;
            LargeToolStripMenuItem.Checked = false;
            RandomToolStripMenuItem.Checked = false;
        }

        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.radius = 50.0d;
            SmallToolStripMenuItem.Checked = false;
            MediumToolStripMenuItem.Checked = true;
            LargeToolStripMenuItem.Checked = false;
            RandomToolStripMenuItem.Checked = false;
        }

        private void LargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.radius = 100.0d;
            SmallToolStripMenuItem.Checked = false;
            MediumToolStripMenuItem.Checked = false;
            LargeToolStripMenuItem.Checked = true;
            RandomToolStripMenuItem.Checked = false;
        }

        private void RandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.radius = 0.0d;
            SmallToolStripMenuItem.Checked = false;
            MediumToolStripMenuItem.Checked = false;
            LargeToolStripMenuItem.Checked = false;
            RandomToolStripMenuItem.Checked = true;
        }

        private void ThreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.numberCircles = 3;
            ThreeToolStripMenuItem.Checked = true;
            FiveToolStripMenuItem.Checked = false;
            EightToolStripMenuItem.Checked = false;
        }

        private void FiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.numberCircles = 5;
            ThreeToolStripMenuItem.Checked = false;
            FiveToolStripMenuItem.Checked = true;
            EightToolStripMenuItem.Checked = false;
        }

        private void EightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyShape.numberCircles = 8;
            ThreeToolStripMenuItem.Checked = false;
            FiveToolStripMenuItem.Checked = false;
            EightToolStripMenuItem.Checked = true;
        }

        private void TopmostLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyWindow.topmostLayer = true;
            TopmostLayerToolStripMenuItem.Checked = true;
            AllLayersToolStripMenuItem.Checked = false;
        }

        private void AllLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyWindow.topmostLayer = false;
            AllLayersToolStripMenuItem.Checked = true;
            TopmostLayerToolStripMenuItem.Checked = false;
        }
    }
}