using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeToBackCS
{
    public partial class ShapeToBack : Form
    {
        public ShapeToBack()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Shapes_Click(System.Object sender, System.EventArgs e)
        {
            // Send the control that was clicked to the bottom of the z-order.
            ((Shape)sender).SendToBack();
        }
        // </Snippet1>
    }
}
