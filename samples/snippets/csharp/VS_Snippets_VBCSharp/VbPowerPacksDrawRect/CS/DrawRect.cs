using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDrawRectCS
{
    public partial class DrawRect : Form
    {
        public DrawRect()
        {
            InitializeComponent();
        }

        private void DrawRect_Load(System.Object sender, System.EventArgs e)
        {
            DrawRectangle();
            DrawRectangle2();
            DrawSquare();
        }

        // <Snippet1>
        private void DrawRectangle()
        {
            Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
                new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            Microsoft.VisualBasic.PowerPacks.RectangleShape rect1 = 
                new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the RectangleShape.
            rect1.Parent = canvas;
            // Set the location and size of the rectangle.
            rect1.Left = 10;
            rect1.Top = 10;
            rect1.Width = 300;
            rect1.Height = 100;
        }
        // </Snippet1>
        // <Snippet2>
        private void DrawRectangle2()
        {
            // Declare a RectangleShape and parent it to 
            // lineShape1's ShapeContainer.
            Microsoft.VisualBasic.PowerPacks.RectangleShape rect1 = 
                new Microsoft.VisualBasic.PowerPacks.RectangleShape(lineShape1.Parent);
            // Set the location and size of the rectangle.
            rect1.Left = 40;
            rect1.Top = 40;
            rect1.Width = 120;
            rect1.Height = 220;
        }
        // </Snippet2>
        // <Snippet3>
        private void DrawSquare()
        {
            Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
                new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            // Declare a RectangleShape and set the location and size.
            Microsoft.VisualBasic.PowerPacks.RectangleShape rect1 = 
                new Microsoft.VisualBasic.PowerPacks.RectangleShape(15, 15, 105, 105);
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the RectangleShape.
            rect1.Parent = canvas;
        }
        // </Snippet3>
        // <Snippet4>
        private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
        {
            int max;
            // Calculate the maximum radius.
            max = Math.Min(rectangleShape1.Height, rectangleShape1.Width) / 2;
            // Check whether the maximum radius has been reached.
            if (rectangleShape1.CornerRadius == max)
            // Reset the radius to 0.
            {
                rectangleShape1.CornerRadius = 0;
            }
            else
            {
                // Increase the radius.
                rectangleShape1.CornerRadius = rectangleShape1.CornerRadius + 15;
            }
        }
        // </Snippet4>
    }
}
