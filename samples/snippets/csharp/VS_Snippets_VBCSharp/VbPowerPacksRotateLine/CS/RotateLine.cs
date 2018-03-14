using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksRotateLineCS
{
    public partial class RotateLine : Form
    {
        public RotateLine()
        {
            InitializeComponent();
        }

        // <Snippet1>
        Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
            new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
        Microsoft.VisualBasic.PowerPacks.LineShape line1 = 
            new Microsoft.VisualBasic.PowerPacks.LineShape(10, 10, 200, 10);
        string direction;
        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            line1.Parent = canvas;
            direction = "horizontal";
        }
        private void Form1_Click(object sender, System.EventArgs e)
        {
            ChangeOrientation();
        }

        private void ChangeOrientation()
        {

            if (direction == "horizontal")
            // Change the orientation to diagonal.
            {
                line1.EndPoint = new System.Drawing.Point(200, 200);
                direction = "diagonal";
            }
            else if (direction == "diagonal")
            {
                line1.EndPoint = new System.Drawing.Point(line1.X1, 200);
                direction = "vertical";
            }
            else
            {
                // Change the orientation to horizontal.
                line1.EndPoint = new System.Drawing.Point(200, line1.Y1);
                direction = "horizontal";
            }
        }

        // </Snippet1>
    }
}
