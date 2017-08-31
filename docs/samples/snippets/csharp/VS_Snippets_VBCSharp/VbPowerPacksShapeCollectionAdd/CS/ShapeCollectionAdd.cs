using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;


namespace VbPowerPacksShapeCollectionAddCS
{
    public partial class ShapeCollectionAdd : Form
    {
        public ShapeCollectionAdd()
        {
            InitializeComponent();
        }
        
        // <Snippet1>
        private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Declare a new oval shape to add to the form.
            OvalShape oval = new OvalShape();
            // Add the oval shape to the form.
            rectangleShape1.Parent.Shapes.Add(oval);
            oval.Location = new Point(50, 50);
            oval.Size = new Size(200, 100);
        }
        // </Snippet1>
    }
}
