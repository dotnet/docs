using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeToFrontCS
{
    public partial class ShapeToFront : Form
    {
        public ShapeToFront()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Shapes_Click(System.Object sender, System.EventArgs e)
        {
            // Bring the control that was clicked to the top of the z-order.
            ((Shape)sender).BringToFront();
        }
        // </Snippet1>
    }
}
