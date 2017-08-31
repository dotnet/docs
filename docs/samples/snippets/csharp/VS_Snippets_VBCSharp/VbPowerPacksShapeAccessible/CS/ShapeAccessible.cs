using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeAccessibleCS
{
    public partial class ShapeAccessible : Form
    {
        public ShapeAccessible()
        {
            InitializeComponent();
        }

        private void ShapeAccessible_Load(System.Object sender, System.EventArgs e)
        {
            // <Snippet1>
            OvalShape OvalShape1 = new OvalShape();
            ShapeContainer canvas = new ShapeContainer();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the OvalShape.
            OvalShape1.Parent = canvas;
            // Assign an image resource to the BackgroundImage property.
            OvalShape1.BackgroundImage = VbPowerPacksShapeAccessibleCS.Properties.Resources.cactus;
            OvalShape1.Size = new Size(VbPowerPacksShapeAccessibleCS.Properties.Resources.cactus.Height, 
                VbPowerPacksShapeAccessibleCS.Properties.Resources.cactus.Width);
            // Assign the AccessibleName and AccessibleDescription text.
            OvalShape1.AccessibleName = "Image";
            OvalShape1.AccessibleDescription = "A picture of a cactus";
            // </Snippet1>
            MessageBox.Show(OvalShape1.AccessibleName + " " + OvalShape1.AccessibleDescription);
        }
        // <Snippet2>
        private void ovalShape1_QueryAccessibilityHelp(object sender, 
            System.Windows.Forms.QueryAccessibilityHelpEventArgs e)
        {
            e.HelpString = "Displays an oval representing a network node.";
        }
        // </Snippet2>
    }
}
