using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeEventsCS
{
    public partial class ShapeEvents : Form
    {
        public ShapeEvents()
        {
            InitializeComponent();
        }

        private void ShapeEvents_Load(System.Object sender, System.EventArgs e)
        {
            rectangleShape1.ContextMenu = contextMenu1;
        }

        // <Snippet1>
        private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Set properties to display a gradient fill.
            rectangleShape1.FillColor = Color.Blue;
            rectangleShape1.FillGradientColor = Color.Red;
            rectangleShape1.FillGradientStyle = FillGradientStyle.Horizontal;
            rectangleShape1.FillStyle = FillStyle.Solid;
        }
        // </Snippet1>

        // <Snippet2>
        private void rectangleShape1_ContextMenuChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("A new shortcut menu is available");
        }
        // </Snippet2>

        // <Snippet3>
        private void rectangleShape1_ContextMenuStripChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("A new shortcut menu is available");
        }
        // </Snippet3>

        // <Snippet4>
        private void rectangleShape1_CursorChanged(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "This shape is currently disabled.";
        }
        // </Snippet4>

        // <Snippet5>
        private void rectangleShape1_DoubleClick(object sender, System.EventArgs e)
        {
            if (rectangleShape1.BackColor == Color.Blue)
            {
                rectangleShape1.BackColor = Color.Red;
            }
            else
            {
                rectangleShape1.BackColor = Color.Blue;
            }
        }
        // </Snippet5>

        // <Snippet6>
        private void rectangleShape1_EnabledChanged(object sender, System.EventArgs e)
        {
            if (rectangleShape1.Enabled == true)
            // Display a crosshair cursor.
            {
                rectangleShape1.Cursor = Cursors.Cross;
            }
        }
        // </Snippet6>

        // <Snippet7>
        private void rectangleShape1_Enter(object sender, System.EventArgs e)
        {
            MessageBox.Show("The rectangle has been selected.");
        }
        // </Snippet7>
        // <Snippet8>
        private void rectangleShape1_GotFocus(object sender, System.EventArgs e)
        {
            rectangleShape1.SelectionColor = Color.Red;
        }
        // </Snippet8>

        // <Snippet9>
        private void Shapes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Check to see whether the TAB key was pressed.
            if (e.KeyCode == Keys.Tab)
            // Call the Tab procedure
            {
                Tab((Shape) sender);
            }
        }
        private void Tab(Shape sender)
        {
            // Select the next shape.
            sender.Parent.SelectNextShape(sender, true, true);
        }
        // </Snippet9>

        // <Snippet10>
        private void rectangleShape1_KeyPress(object sender, 
            System.Windows.Forms.KeyPressEventArgs e)
        {
            char ch;
            ch = e.KeyChar;
            MessageBox.Show("You pressed the " + ch + " key.");
        }
        // </Snippet10>

        // <Snippet11>
        private void ovalShape1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Determine whether the key entered is the F1 key. 
            // Display Help if it is.
            if (e.KeyCode == Keys.F1)
            // Display a pop-up Help message to assist the user.
            {
                Help.ShowPopup(ovalShape1.Parent, "This represents a router.", 
                    new Point(500, 500));
            }
        }
        // </Snippet11>

        // <Snippet12>
        private void rectangleShape1_Leave(object sender, System.EventArgs e)
        {
            // Restore the default BackColor.
            rectangleShape1.BackColor = SimpleShape.DefaultBackColor;
        }
        // </Snippet12>

        // <Snippet13>
        private void rectangleShape1_LostFocus(object sender, System.EventArgs e)
        {
            // Restore the default BorderColor.
            rectangleShape1.BorderColor = SimpleShape.DefaultBorderColor;
        }

        // </Snippet13>

        // <Snippet14>
        private void ovalShape1_MouseClick(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            // Display a crosshair cursor.
            ovalShape1.Cursor = Cursors.Cross;
        }

        // </Snippet14>

        // <Snippet15>
        private void ovalShape1_MouseDoubleClick(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            ovalShape1.BringToFront();
        }

        // </Snippet15>

        // <Snippet16>
        private System.Drawing.Drawing2D.GraphicsPath mousePath = 
            new System.Drawing.Drawing2D.GraphicsPath();

        private void rectangleShape2_MouseDown(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            Point mouseDownLocation = new Point(e.X + rectangleShape2.Left, 
                e.Y + rectangleShape2.Top);
            // Clear the previous line.
            mousePath.Dispose();
            mousePath = new System.Drawing.Drawing2D.GraphicsPath();
            rectangleShape2.Invalidate();
            // Add a line to the graphics path.
            mousePath.AddLine(mouseDownLocation, mouseDownLocation);
        }

        private void rectangleShape2_MouseMove(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            int mouseX = e.X + rectangleShape2.Left;
            int mouseY = e.Y + rectangleShape2.Top;
            // Add a line to the graphics path.
            mousePath.AddLine(mouseX, mouseY, mouseX, mouseY);
        }

        private void rectangleShape2_MouseUp(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            System.Drawing.Point mouseUpLocation = 
                new System.Drawing.Point(e.X + rectangleShape2.Left, 
                    e.Y + rectangleShape2.Top);
            // Add a line to the graphics path.
            mousePath.AddLine(mouseUpLocation, mouseUpLocation);
            // Force the shape to redraw.
            rectangleShape2.Invalidate();
        }

        private void rectangleShape2_Paint(object sender, 
            System.Windows.Forms.PaintEventArgs e)
        {
            // Draw the line.
            e.Graphics.DrawPath(System.Drawing.Pens.DarkRed, mousePath);
        }
        // </Snippet16>

        // <Snippet17>
        private void rectangleShape1_MouseEnter(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "The mouse has entered the shape.";
        }

        private void rectangleShape1_MouseHover(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "The mouse is paused over the shape.";
        }

        private void rectangleShape1_MouseLeave(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "The mouse has left the shape.";
        }

        private void rectangleShape1_MouseMove(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "The mouse is over the shape.";
        }
        // </Snippet17>

        // <Snippet18>
        private void rectangleShape1_MouseWheel(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            // Move the shape vertically to correspond to the scrolling of the
            // mouse wheel.
            int scale = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            rectangleShape1.Top = rectangleShape1.Top - scale;
        }

        // </Snippet18>

        // <Snippet19>
        private void ovalShape1_Move(object sender, System.EventArgs e)
        {
            Rectangle rect = new Rectangle();
            // Get the bounding rectangle for the rectangle shape.
            rect = rectangleShape1.DisplayRectangle;
            // Determine whether the bounding rectangles overlap.
            if (rect.IntersectsWith(ovalShape1.DisplayRectangle))
            // Bring the oval shape to the front.
            {
                ovalShape1.BringToFront();
            }
        }
        // </Snippet19>

        // <Snippet20>
        private void ovalShape1_ParentChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("The shape has been moved to a new container.");
        }
        // </Snippet20>

        // <Snippet21>
        private void ovalShape1_PreviewKeyDown(object sender, 
            System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            // Display a pop-up Help window to assist the user.
            {
                Help.ShowPopup(ovalShape1.Parent, 
                    "This shape represents a network node.", 
                    PointToScreen(new Point(ovalShape1.Width, ovalShape1.Height)));
            }
        }
        // </Snippet21>

        // <Snippet22>
        private void ovalShape1_RegionChanged(object sender, System.EventArgs e)
        {
            // Force the shape to repaint.
            ovalShape1.Invalidate();
        }
        // </Snippet22>

        // <Snippet23>
        private void ovalShape1_VisibleChanged(object sender, System.EventArgs e)
        {
            // Switch between the oval and rectangle shapes.
            if (ovalShape1.Visible == false)
            {
                rectangleShape1.Visible = true;
            }
            else
            {
                rectangleShape1.Visible = false;
            }
        }

        // </Snippet23>

    }
}
