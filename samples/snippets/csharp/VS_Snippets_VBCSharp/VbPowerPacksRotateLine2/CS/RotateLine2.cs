using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksRotateLine2CS
{
    public partial class RotateLine2 : Form
    {
        public RotateLine2()
        {
            InitializeComponent();
        }

        // <Snippet1>
        Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
            new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
        Microsoft.VisualBasic.PowerPacks.LineShape line1 = 
            new Microsoft.VisualBasic.PowerPacks.LineShape(10, 10, 200, 10);
        string direction;
        private void RotateLine2_Load(System.Object sender, System.EventArgs e)
        {
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            line1.Parent = canvas;
            direction = "horizontal";
        }
        private void RotateLine2_Click(object sender, System.EventArgs e)
        {
            ChangeOrientation();
        }

        private void ChangeOrientation()
        {

            if (direction == "horizontal")
            // Change the orientation to diagonal.
            {
                line1.StartPoint = new System.Drawing.Point(line1.X1, 200);
                direction = "diagonal";
            }
            else if (direction == "diagonal")
            {
                line1.StartPoint = new System.Drawing.Point(line1.Y1, 200);
                direction = "vertical";
            }
            else
            {
                // Change the orientation to horizontal.
                line1.StartPoint = new System.Drawing.Point(10, line1.Y2);
                direction = "horizontal";
            }
        }

        // </Snippet1>
    }
}
