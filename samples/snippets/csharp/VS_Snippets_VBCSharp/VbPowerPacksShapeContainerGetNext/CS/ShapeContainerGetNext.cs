using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeContainerGetNextCS
{
    public partial class ShapeContainerGetNext : Form
    {
        public ShapeContainerGetNext()
        {
            InitializeComponent();
        }
        // <Snippet1>
    private void Shapes_PreviewKeyDown(object sender, 
        System.Windows.Forms.PreviewKeyDownEventArgs e)
    {
        Shape sh;
        // Check for the TAB key.
        if (e.KeyCode==Keys.Tab)
            // Find the next shape in the order.
        {
            sh = shapeContainer1.GetNextShape((Shape) sender, true);
            // Select the next shape.
            shapeContainer1.SelectNextShape((Shape) sender, true, true);
        }
    }
    // </Snippet1>
    }
}
