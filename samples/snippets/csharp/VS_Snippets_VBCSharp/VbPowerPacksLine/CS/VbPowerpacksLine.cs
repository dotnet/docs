using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerpacksLineCS
{
    public partial class VbPowerpacksLine : Form
    {
        public VbPowerpacksLine()
        {
            InitializeComponent();
        }

        private void VbPowerpacksLine_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            ShapeContainer canvas = new ShapeContainer();
            LineShape theLine = new LineShape();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            theLine.Parent = canvas;
            // Set the starting and ending coordinates for the line.
            theLine.StartPoint = new System.Drawing.Point(0, 0);
            theLine.EndPoint = new System.Drawing.Point(640, 480);
            // </Snippet1>
        }
    }
}
