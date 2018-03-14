using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeIsAccessibleCS
{
    public partial class ShapeIsAccessible : Form
    {
        public ShapeIsAccessible()
        {
            InitializeComponent();
        }

        private void ShapeIsAccessible_Load(System.Object sender, System.EventArgs e)
        {
            SetAccessibility();
            string isacc;
            if (ovalShape2.IsAccessible)
                isacc = "true";
            else
                isacc = "false";

            MessageBox.Show(isacc);
        }
        // <Snippet1>
        private void SetAccessibility()
        {
            // Loop through the Shapes collection of the form.
            foreach (Shape s in shapeContainer1.Shapes)
            {
                // If the shape is disabled, set IsAccessible to false.
                if (s.Enabled == false)
                {
                    s.IsAccessible = false;
                }
            }
        }
        // </Snippet1>
    }
}

