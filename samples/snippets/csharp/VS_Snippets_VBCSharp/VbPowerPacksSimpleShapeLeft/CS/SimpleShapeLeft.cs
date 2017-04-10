using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeLeftCS
{
    public partial class SimpleShapeLeft : Form
    {
        public SimpleShapeLeft()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void rectangleShape1_Click_1(System.Object sender, System.EventArgs e)
        {
            // Set the left edge.
            rectangleShape1.Left = 10;
            // Set the top edge.
            rectangleShape1.Top = 10;
        }
        // </Snippet1>
    }
}
