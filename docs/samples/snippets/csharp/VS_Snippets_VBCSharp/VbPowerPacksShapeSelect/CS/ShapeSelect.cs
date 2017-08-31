using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeSelectCS
{
    public partial class ShapeSelect : Form
    {
        public ShapeSelect()
        {
            InitializeComponent();
        }

        private void ShapeSelect_Click(object sender, System.EventArgs e)
        {
            SelectShape(ovalShape3);
        }
        // <Snippet1>
        public void SelectShape(Microsoft.VisualBasic.PowerPacks.Shape shape)
        {
            // Select the control, if it can be selected.
            if (shape.CanSelect)
            {
                shape.Select();
            }
        }
        // </Snippet1>
    }
}
