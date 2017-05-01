using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeSelectionColorCS
{
    public partial class ShapeSelectionColor : Form
    {
        
        public ShapeSelectionColor()
        {
            InitializeComponent();
            

        }

        // <Snippet1>
        private void rectangleShape1_GotFocus(object sender, System.EventArgs e)
        {
            // If SelectionColor is the same as the form's BackColor.
            if (rectangleShape1.SelectionColor == this.BackColor)
            // Change the SelectionColor.
            {
                rectangleShape1.SelectionColor = Color.Red;
            }
            else
            {
                // Use the default SelectionColor.
                rectangleShape1.SelectionColor = SystemColors.Highlight;
            }
        }
        // </Snippet1>
    }
}
