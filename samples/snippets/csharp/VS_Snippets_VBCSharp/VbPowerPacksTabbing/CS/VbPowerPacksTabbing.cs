using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksTabbingCS
{
    public partial class VbPowerPacksTabbing : Form
    {
        public VbPowerPacksTabbing()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void shapes_PreviewKeyDown(Shape sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            Shape sh;
            // Check for the Control and Tab keys.
            if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Control)
            // Find the next shape in the order.
            {
                sh = shapeContainer1.GetNextShape(sender, true);
                // Select the next shape.
                shapeContainer1.SelectNextShape(sender, false, true);
            }
        }
        // </Snippet1>

        // <Snippet2>
        private void button1_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            // Check for the Control and Tab keys.
            if (e.KeyCode == Keys.Tab & e.Modifiers == Keys.Control)
            // Select the first shape.
            {
                rectangleShape1.Select();
            }
        }
        // </Snippet2>
    }
}