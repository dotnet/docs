using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeCollectionAddRangeCS
{
    public partial class ShapeCollectionAddRange : Form
    {
        public ShapeCollectionAddRange()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Create two oval shapes to add to the form.
            OvalShape oval1 = new OvalShape();
            OvalShape oval2 = new OvalShape();

            // Set the size of the ovals.
            oval1.Size = new Size(100, 200);
            oval2.Size = oval1.Size;

            // Set the appropriate location of ovals.
            oval1.Location = new Point(10, 10);
            oval2.Location = new Point(oval1.Left + 10, oval1.Top + 10);

            // Add the controls to the form by using the AddRange method.
            rectangleShape1.Parent.Shapes.AddRange(new Shape[] { oval1, oval2 });
        }
        // </Snippet1>
    }
}
