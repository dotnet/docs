using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeCollectionClearCS
{
    public partial class ShapeCollectionClear : Form
    {
        public ShapeCollectionClear()
        {
            InitializeComponent();
        }

    // <Snippet1>
    private void form1_Click(object sender, System.EventArgs e)
    {
        // Call the method to remove the shapes.
        RemoveShapes(ovalShape1);
    }

    private void RemoveShapes(Shape shape)
    {
        ShapeContainer canvas;

        // Find the ShapeContainer in which the shape is located.
        canvas = shape.Parent;
        // Call the Clear method to remove all shapes.
        canvas.Shapes.Clear();
    }
    // </Snippet1>
    }
}
