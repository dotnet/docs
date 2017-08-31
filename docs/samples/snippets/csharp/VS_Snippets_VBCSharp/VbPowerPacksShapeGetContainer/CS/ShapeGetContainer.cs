using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeGetContainerCS
{
    public partial class ShapeGetContainer : Form
    {
        public ShapeGetContainer()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Declare a Control.
            Control ctl;
            // Find the container for the OvalShape.
            ctl = ((Control)ovalShape1.GetContainerControl());
            // Change the color of the container.
            ctl.BackColor = Color.Blue;
        }
        // </Snippet1>
    }
}
