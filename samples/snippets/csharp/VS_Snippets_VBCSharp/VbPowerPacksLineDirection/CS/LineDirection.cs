using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksLineDirectionCS
{
    public partial class LineDirection : Form
    {
        public LineDirection()
        {
            InitializeComponent();
        }

        // <Snippet1>
        Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
            new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
        Microsoft.VisualBasic.PowerPacks.LineShape line1 = 
            new Microsoft.VisualBasic.PowerPacks.LineShape(10, 10, 200, 10);
        private void LineDirection_Load(System.Object sender, System.EventArgs e)
        {
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            line1.Parent = canvas;
        }
        private void LineDirection_Click(object sender, System.EventArgs e)
        {
            ChangeDirection();
        }
        private void ChangeDirection()
        {
            if (line1.X1 == line1.Y2)
            {
                line1.X2 = 10;
                line1.Y2 = 200;
            }
            else
            {
                line1.X2 = 200;
                line1.Y2 = 10;
            }
        }
        // </Snippet1>
    }
}
