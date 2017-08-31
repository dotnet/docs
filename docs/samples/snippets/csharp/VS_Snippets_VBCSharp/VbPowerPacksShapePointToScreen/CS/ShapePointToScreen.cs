using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapePointToScreenCS
{
    public partial class ShapePointToScreen : Form
    {
        public ShapePointToScreen()
        {
            InitializeComponent();
        }

        // <Snippet1>
        public bool isDrag = true;
        public System.Drawing.Rectangle theRectangle;

        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            // If the mouse is being dragged, undraw and redraw the rectangle
            // while the mouse moves.
            if (isDrag)

            // Hide the previous rectangle by calling the
            // DrawReversibleFrame method, using the same parameters.
            {
                ControlPaint.DrawReversibleFrame(theRectangle, this.BackColor, FrameStyle.Dashed);

                // Calculate the endpoint and dimensions for the new rectangle, 
                // again by using the PointToScreen method.
                Point startPoint = new Point(rectangleShape1.Width, rectangleShape1.Height);
                Point endPoint = rectangleShape1.PointToScreen(new Point(e.X, e.Y));
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                theRectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);

                // Draw the new rectangle by calling DrawReversibleFrame again.  
                ControlPaint.DrawReversibleFrame(theRectangle, this.BackColor, FrameStyle.Dashed);
            }
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            // If the MouseUp event occurs, the user is not dragging.
            isDrag = false;
            // Draw the rectangle to be evaluated. Set a dashed frame style 
            // by using the FrameStyle enumeration.
            ControlPaint.DrawReversibleFrame(theRectangle, this.BackColor, FrameStyle.Dashed);
            // Find out which controls intersect the rectangle, and change
            // their colors.
            // The method uses the RectangleToScreen method to convert the 
            // control's client coordinates to screen coordinates.
            Rectangle controlRectangle;

            controlRectangle = rectangleShape1.RectangleToScreen(rectangleShape1.ClientRectangle);
            if (controlRectangle.IntersectsWith(theRectangle))
            {
                rectangleShape1.BackColor = Color.BurlyWood;
            }

            // Reset the rectangle.
            theRectangle = new Rectangle(0, 0, 0, 0);
        }
        // </Snippet1>
    }
}
