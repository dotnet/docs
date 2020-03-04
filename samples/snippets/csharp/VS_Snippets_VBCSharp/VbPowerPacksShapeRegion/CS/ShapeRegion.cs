using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeRegionCS
{
    public partial class ShapeRegion : Form
    {
        public ShapeRegion()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void rectangleShape1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            System.Drawing.Drawing2D.GraphicsPath shapePath = new System.Drawing.Drawing2D.GraphicsPath();

            // Set a new rectangle to the same size as the RectangleShape's 
            // ClientRectangle property.
            Rectangle newRectangle = rectangleShape1.ClientRectangle;

            // Decrease the size of the rectangle.
            newRectangle.Inflate(-10, -10);

            // Draw the new rectangle's border.
            e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);

            // Create a semi-transparent brush.
            SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255));

            // Fill the new rectangle.
            e.Graphics.FillEllipse(br, newRectangle);
            //Increase the size of the rectangle to include the border.
            newRectangle.Inflate(1, 1);

            // Create an oval region within the new rectangle.
            shapePath.AddEllipse(newRectangle);
            e.Graphics.DrawPath(Pens.Black, shapePath);

            // Set the RectangleShape's Region property to the newly created 
            // oval region.
            rectangleShape1.Region = new System.Drawing.Region(shapePath);
        }
        // </Snippet1>
    }
}
