using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeContainsFocusCS
{
    public partial class ShapeContainsFocus : Form
    {
        public ShapeContainsFocus()
        {
            InitializeComponent();
        }

        private void ShapeContainsFocus_Click(object sender, System.EventArgs e)
        {
            ReportFocus(ovalShape1);
        }
        // <Snippet1>
        public void ReportFocus(Microsoft.VisualBasic.PowerPacks.Shape shape)
        {
            // Determine whether the Shape has focus.
            if (shape.ContainsFocus)
            {
                MessageBox.Show(shape.Name + " has focus.");
            }
        }
        // </Snippet1>
    }
}
