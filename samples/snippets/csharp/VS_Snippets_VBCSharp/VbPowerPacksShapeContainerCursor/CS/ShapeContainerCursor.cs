using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeContainerCursorCS
{
    public partial class ShapeContainerCursor : Form
    {
        public ShapeContainerCursor()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void form1_Load(System.Object sender, System.EventArgs e)
        {
            // Display the hand cursor when mouse is over the ShapeContainer.
            shapeContainer1.Cursor = Cursors.Hand;
            // Display the default cursor when mouse is over the RectangleShape.
            rectangleShape1.Cursor = Cursors.Default;
        }
        // </Snippet1>
    }
}
