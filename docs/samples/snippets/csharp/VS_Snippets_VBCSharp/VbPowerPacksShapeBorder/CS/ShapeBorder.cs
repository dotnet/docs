using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeBorderCS
{
    public partial class ShapeBorder : Form
    {
        public ShapeBorder()
        {
            InitializeComponent();
        }

        private void ShapeBorder_Load(System.Object sender, System.EventArgs e)
        {
            // <Snippet1>
            OvalShape ovalShape1 = new OvalShape();
            ShapeContainer canvas = new ShapeContainer();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the OvalShape.
            ovalShape1.Parent = canvas;
            // Change the color of the border to red.
            ovalShape1.BorderColor = Color.Red;
            // Change the style of the border to dotted.
            ovalShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            // Change the thickness of the border to 3 pixels.
            ovalShape1.BorderWidth = 3;
            ovalShape1.Size = new Size(300, 200);
            // </Snippet1>
        }
    }
}
