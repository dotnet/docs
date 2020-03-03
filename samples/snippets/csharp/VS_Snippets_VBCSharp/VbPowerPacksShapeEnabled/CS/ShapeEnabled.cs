using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeEnabledCS
{
    public partial class ShapeEnabled : Form
    {
        public ShapeEnabled()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            // If the TextBox contains text, enable the RectangleShape.
            if (textBox1.Text != "")
            // Enable the RectangleShape.
            {
                rectangleShape1.Enabled = true;
                // Change the BorderColor to the default.
                rectangleShape1.BorderColor = Microsoft.VisualBasic.PowerPacks.Shape.DefaultBorderColor;
            }
            else
            {
                // Disable the RectangleShape control.
                rectangleShape1.Enabled = false;
                // Change the BorderColor to show that the control is disabled
                rectangleShape1.BorderColor = Color.FromKnownColor(KnownColor.InactiveBorder);
            }
        }
        // </Snippet1>
    }
}
