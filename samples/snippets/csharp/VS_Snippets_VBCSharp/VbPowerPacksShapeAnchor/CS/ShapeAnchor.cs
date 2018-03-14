using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeAnchorCS
{
    public partial class ShapeAnchor : Form
    {
        public ShapeAnchor()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ResizeShapes()
        {
            // Loop through the ShapeCollection.
            foreach (Shape shape in shapeContainer1.Shapes)
            {
                // Set the Anchor property.
                shape.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | 
                    AnchorStyles.Right | AnchorStyles.Top;
            }
        }
        // </Snippet1>
        private void ShapeAnchor_Resize(object sender, System.EventArgs e)
        {
            // Call the ResizeShapes function when the form is resized.
            ResizeShapes();
        }
    }
}
