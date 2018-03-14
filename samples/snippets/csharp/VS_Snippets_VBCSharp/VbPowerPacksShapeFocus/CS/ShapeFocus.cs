using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeFocusCS
{
    public partial class ShapeFocus : Form
    {
        public ShapeFocus()
        {
            InitializeComponent();
        }

        // <Snippet1>
        public void ShapeSetFocus(Microsoft.VisualBasic.PowerPacks.Shape shape)
        {
            // Set focus to the control, if it can receive focus.
            if (shape.CanFocus)
            {
                shape.Focus();
            }
        }
        // </Snippet1>

        private void ShapeFocus_Click(object sender, EventArgs e)
        {
            ShapeSetFocus(ovalShape2);
        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {

        }
        
    }
}
