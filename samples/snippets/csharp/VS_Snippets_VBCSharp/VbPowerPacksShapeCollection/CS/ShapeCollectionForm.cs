using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeCollectionCS
{
    public partial class ShapeCollectionForm : Form
    {
        public ShapeCollectionForm()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Shapes_Click(System.Object sender, System.EventArgs e)
        {
            // Determine whether the shape is in the collection.
            if (shapeContainer1.Shapes.Contains((Shape)sender))
            // If the Index is greater than 0, remove the shape.
            {
                if (shapeContainer1.Shapes.IndexOf((Shape)sender) > 0)
                {
                    shapeContainer1.Shapes.Remove((Shape)sender);
                }
            }
        }
        // </Snippet1>

    }
}
