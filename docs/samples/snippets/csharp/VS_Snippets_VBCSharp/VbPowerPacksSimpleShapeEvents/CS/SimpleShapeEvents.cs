using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksSimpleShapeEventsCS
{
    public partial class SimpleShapeEvents : Form
    {
        public SimpleShapeEvents()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void rectangleShape1_BackColorChanged(object sender, System.EventArgs e)
        {
            // The BackStyle must be Opaque or the BackColor has no effect.
            if (rectangleShape1.BackStyle == BackStyle.Transparent)
            {
                rectangleShape1.BackStyle = BackStyle.Opaque;
            }
        }
        // </Snippet1>

        // <Snippet2>
        private void rectangleShape1_BackgroundImageChanged(object sender, System.EventArgs e)
        {
            // Display a message in the Label.
            label1.Text = "The picture has changed.";
        }
        // </Snippet2>

        // <Snippet3>
        private void rectangleShape1_BackgroundImageLayoutChanged(object sender, 
            System.EventArgs e)
        {
            // If the image is centered, check its size.
            if (rectangleShape1.BackgroundImageLayout == ImageLayout.Center)
            {
                SizeF imageSize;
                imageSize = rectangleShape1.BackgroundImage.PhysicalDimension;
                // If the image is smaller than the shape, change the BackColor.
                if (imageSize.Height < rectangleShape1.ClientSize.Height || 
                    imageSize.Width < rectangleShape1.ClientSize.Width)
                {
                    rectangleShape1.BackColor = Color.Black;
                }
            }
        }
        // </Snippet3>

        // <Snippet4>
        private void rectangleShape1_ClientSizeChanged(object sender, System.EventArgs e)
        {
            // Restrict the shape to a certain width range.
            if (rectangleShape1.Width > 300)
            {
                rectangleShape1.Width = 300;
            }
            else if (rectangleShape1.Width < 50)
            {
                rectangleShape1.Width = 50;
            }
        }
        // </Snippet4>

        // <Snippet5>
        private void rectangleShape1_LocationChanged(object sender, System.EventArgs e)
        {
            // If the second rectangle intersects with the first, move it.
            if (rectangleShape1.ClientRectangle.IntersectsWith(rectangleShape2.ClientRectangle))
            {
                rectangleShape2.Location = new Point(rectangleShape1.Right, 
                    rectangleShape1.Bottom);
            }
        }
        // </Snippet5>

        // <Snippet6>
        private void rectangleShape1_Resize(object sender, System.EventArgs e)
        {
            // If the second rectangle intersects with the first, move it.
            if (rectangleShape1.ClientRectangle.IntersectsWith(rectangleShape2.ClientRectangle))
            {
                rectangleShape2.Location = new Point(rectangleShape1.Right, 
                    rectangleShape1.Bottom);
            }
        }
        // </Snippet6>

        // <Snippet7>
        private void rectangleShape1_SizeChanged(object sender, System.EventArgs e)
        {
            // If the second rectangle intersects with the first, move it.
            if (rectangleShape1.ClientRectangle.IntersectsWith(rectangleShape2.ClientRectangle))
            {
                rectangleShape2.Location = new Point(rectangleShape1.Right, 
                    rectangleShape1.Bottom);
            }
        }
        // </Snippet7>
    }
}
