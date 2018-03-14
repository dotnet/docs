using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeBoundsCS
{
    public partial class SimpleShapeBounds : Form
    {
        public SimpleShapeBounds()
        {
            InitializeComponent();
        }

        // <Snippet1>
    private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
    {
        // Change the Bounds property.
        rectangleShape1.SetBounds(0, 0, 100, 100);
    }
    // </Snippet1>
    }
}
