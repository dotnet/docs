using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeCollectionItemCS
{
    public partial class ShapeCollectionItem : Form
    {
        public ShapeCollectionItem()
        {
            InitializeComponent();
        }

        // <Snippet1>
    private void button1_Click(System.Object sender, System.EventArgs e)
    {
        // Set the focus to the first shape (index 0).
        Shape selectedShape = ((Shape) shapeContainer1.Shapes.get_Item(0));
        selectedShape.Focus();
    }
    // </Snippet1>
    }
}
