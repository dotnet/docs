using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeOnEnabledChangedCS
{
    public partial class ShapeOnEnabled : Form
    {
        public ShapeOnEnabled()
        {
            InitializeComponent();
        }

        public ShapeContainer canvas = new ShapeContainer();
        public DisabledLine theLine = new DisabledLine();
        private void OvalShape1_Click(System.Object sender, System.EventArgs e)
        {
            theLine.Enabled = !theLine.Enabled;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            theLine.Parent = canvas;
            // Set the starting and ending coordinates for the line.
            theLine.StartPoint = new System.Drawing.Point(0, 0);
            theLine.EndPoint = new System.Drawing.Point(640, 480);
        }
    }
    // <Snippet1>
    public class DisabledLine :
        LineShape
    {
        protected override void OnEnabledChanged(EventArgs e)
        {
            // Change the color of the line when selected.
            if (this.BorderColor == SystemColors.InactiveBorder)
            {
                this.BorderColor = Color.Black;
            }
            else
            {
                this.BorderColor = SystemColors.InactiveBorder;
            }
            base.OnEnabledChanged(e);
        }
    }
    // </Snippet1>
}
