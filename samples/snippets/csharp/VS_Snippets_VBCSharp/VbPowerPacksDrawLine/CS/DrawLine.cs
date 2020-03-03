using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDrawLineCS
{
    public partial class DrawLine : Form
    {
        public DrawLine()
        {
            InitializeComponent();
        }

        private void DrawLine_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
                new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            Microsoft.VisualBasic.PowerPacks.LineShape line1 = 
                new Microsoft.VisualBasic.PowerPacks.LineShape();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            line1.Parent = canvas;
            // Set the starting and ending coordinates for the line.
            line1.StartPoint = new System.Drawing.Point(this.Width / 2, 0);
            line1.EndPoint = new System.Drawing.Point(this.Width / 2, this.Height);
            // </Snippet1>
        }
    }
}
