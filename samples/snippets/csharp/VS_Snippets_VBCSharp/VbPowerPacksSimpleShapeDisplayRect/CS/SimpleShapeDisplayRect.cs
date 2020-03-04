using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeDisplayRectCS
{
    public partial class SimpleShapeDisplayRect : Form
    {
        public SimpleShapeDisplayRect()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Get the DisplayRectangle for each OvalShape.
            Rectangle rect1 = ovalShape1.DisplayRectangle;
            Rectangle rect2 = ovalShape2.DisplayRectangle;
            // If the DisplayRectangles intersect, move OvalShape2.
            if (rect1.IntersectsWith(rect2))
            {
                ovalShape2.SetBounds(rect1.Right, rect1.Bottom, rect2.Width, rect2.Height);
            }
        }
        // </Snippet1>
    }
}
