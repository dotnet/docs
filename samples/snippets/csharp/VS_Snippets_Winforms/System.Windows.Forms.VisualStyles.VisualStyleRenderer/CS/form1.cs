// This sample might go in a VisualStyleRenderer conceptual topic, or the VisualStyleRenderer
// class itself. The sample defines a custom control that imitates a window using VisualStyleElements
// for the window parts. It handles resizing and moving the window. 

// This sample uses the following VisualStyleRenderer members:
//  Snippet10: VisualStyleRenderer.GetPartSize (with ThemeSizeType.True)
//  Snippet10: VisualStyleRenderer.GetPoint (with PointProperty.Offset)
//  Snippet20: VisualStyleRenderer.DrawBackground
//  Snippet30: VisualStyleRenderer.GetBackgroundRegion
//  Snippet40: VisualStyleRenderer.IsElementDefined
//  Snippet40: VisualStyleRenderer(VisualStyleElement) constructor
//  Snippet40: VisualStyleRenderer.SetParameters

// Work Items: - Try to make HitTestBackground method work in MouseDown event handler.
//             - Why does the offset value obtained for the close button make it draw a bit 
//               too far to the right?
//             - Right now I'm hard-coding the height of the status bar rect to 22, which
//               visual matches the standard Windows version. Doing GetPartSize on this
//               part only returns a height of 15, which is way to short; is this a bug?


// <Snippet0>
using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace VisualStyleRendererSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            this.Size = new Size(800, 600);
            this.Location = new Point(20, 20);
            this.BackColor = Color.DarkGray;
            WindowSimulation Window1 = new WindowSimulation();
            Controls.Add(Window1);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class WindowSimulation : Control
    {
        private Dictionary<string, VisualStyleElement> windowElements =
            new Dictionary<string, VisualStyleElement>();
        private Dictionary<string, Rectangle> elementRectangles =
            new Dictionary<string, Rectangle>();
        private VisualStyleRenderer renderer = null;

        private Point closeButtonOffset;
        private Size gripperSize;
        private Size closeButtonSize;
        private bool isResizing = false;
        private bool isMoving = false;
        private bool isClosing = false;
        private int captionHeight;
        private int frameThickness;
        private int statusHeight = 22;
        private Point originalClick = new Point();
        private Point resizeOffset = new Point();

        public WindowSimulation()
            : base()
        {
            this.Location = new Point(50, 50);
            this.Size = new Size(350, 300);
            this.BackColor = Color.Azure;
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(300, 200);
            this.Font = SystemFonts.CaptionFont;
            this.Text = "Simulated Window";

            // Insert the VisualStyleElement objects into the Dictionary.
            windowElements.Add("windowCaption",
                VisualStyleElement.Window.Caption.Active);
            windowElements.Add("windowBottom",
                VisualStyleElement.Window.FrameBottom.Active);
            windowElements.Add("windowLeft",
                VisualStyleElement.Window.FrameLeft.Active);
            windowElements.Add("windowRight",
                VisualStyleElement.Window.FrameRight.Active);
            windowElements.Add("windowClose",
                VisualStyleElement.Window.CloseButton.Normal);
            windowElements.Add("statusBar",
                VisualStyleElement.Status.Bar.Normal);
            windowElements.Add("statusGripper",
                VisualStyleElement.Status.Gripper.Normal);

            // Get the sizes and location offsets for the window parts  
            // as specified by the visual style, and then use this 
            // information to calcualate the rectangles for each part.
            GetPartDetails();
            CalculateRectangles();

            this.MouseDown +=
                new MouseEventHandler(ImitationWindow_MouseDown);
            this.MouseUp +=
                new MouseEventHandler(ImitationWindow_MouseUp);
            this.MouseMove +=
                new MouseEventHandler(ImitationWindow_MouseMove);
        }

        // <Snippet10>
        // Get the sizes and offsets for the window parts as specified  
        // by the visual style.
        private void GetPartDetails()
        {
            // Do nothing further if visual styles are not enabled.
            if (!Application.RenderWithVisualStyles)
            {
                return;
            }

            using (Graphics g = this.CreateGraphics())
            {
                // Get the size and offset of the close button.
                if (SetRenderer(windowElements["windowClose"]))
                {
                    closeButtonSize =
                        renderer.GetPartSize(g, ThemeSizeType.True);
                    closeButtonOffset =
                        renderer.GetPoint(PointProperty.Offset);
                }

                // Get the height of the window caption.
                if (SetRenderer(windowElements["windowCaption"]))
                {
                    captionHeight = renderer.GetPartSize(g,
                        ThemeSizeType.True).Height;
                }

                // Get the thickness of the left, bottom, 
                // and right window frame.
                if (SetRenderer(windowElements["windowLeft"]))
                {
                    frameThickness = renderer.GetPartSize(g,
                        ThemeSizeType.True).Width;
                }

                // Get the size of the resizing gripper.
                if (SetRenderer(windowElements["statusGripper"]))
                {
                    gripperSize = renderer.GetPartSize(g,
                        ThemeSizeType.True);
                }
            }
        }
        // </Snippet10>

        // Use the part metrics to determine the current size 
        // of the rectangles for all of the window parts.
        private void CalculateRectangles()
        {
            int heightMinusFrame =
                ClientRectangle.Height - frameThickness;

            // Calculate the window frame rectangles and add them
            // to the Dictionary of rectangles.
            elementRectangles["windowCaption"] =
                new Rectangle(0, 0,
                ClientRectangle.Width, captionHeight);
            elementRectangles["windowBottom"] =
                new Rectangle(0, heightMinusFrame,
                ClientRectangle.Width, frameThickness);
            elementRectangles["windowLeft"] =
                new Rectangle(0, captionHeight, frameThickness,
                heightMinusFrame - captionHeight);
            elementRectangles["windowRight"] =
                new Rectangle(ClientRectangle.Width - frameThickness,
                captionHeight, frameThickness,
                heightMinusFrame - captionHeight);

            // Calculate the window button rectangle and add it
            // to the Dictionary of rectangles.
            elementRectangles["windowClose"] =
                new Rectangle(ClientRectangle.Right +
                closeButtonOffset.X, closeButtonOffset.Y,
                closeButtonSize.Width, closeButtonSize.Height);

            // Calculate the status bar rectangles and add them
            // to the Dictionary of rectangles.
            elementRectangles["statusBar"] =
                new Rectangle(frameThickness,
                heightMinusFrame - statusHeight,
                ClientRectangle.Width - (2 * frameThickness),
                statusHeight);
            elementRectangles["statusGripper"] =
                new Rectangle(ClientRectangle.Right -
                gripperSize.Width - frameThickness,
                heightMinusFrame - gripperSize.Height,
                gripperSize.Width, gripperSize.Height);
        }

        // <Snippet20>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Ensure that visual styles are supported.
            if (!Application.RenderWithVisualStyles)
            {
                this.Text = "Visual styles are not enabled.";
                TextRenderer.DrawText(e.Graphics, this.Text,
                    this.Font, this.Location, this.ForeColor);
                return;
            }

            // Set the clip region to define the curved corners 
            // of the caption.
            SetClipRegion();

            // Draw each part of the window.
            foreach (KeyValuePair<string, VisualStyleElement> entry
                in windowElements)
            {
                if (SetRenderer(entry.Value))
                {
                    renderer.DrawBackground(e.Graphics,
                        elementRectangles[entry.Key]);
                }
            }

            // Draw the caption text.
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                elementRectangles["windowCaption"], Color.White,
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.HorizontalCenter);
        }
        // </Snippet20>

        // Initiate dragging, resizing, or closing the imitation window.
        void ImitationWindow_MouseDown(object sender, MouseEventArgs e)
        {
            // The user clicked the close button.
            if (elementRectangles["windowClose"].Contains(e.Location))
            {
                windowElements["windowClose"] =
                    VisualStyleElement.Window.CloseButton.Pressed;
                isClosing = true;
            }

            // The user clicked the status grip.
            else if (elementRectangles["statusGripper"].
                Contains(e.Location))
            {
                isResizing = true;
                this.Cursor = Cursors.SizeNWSE;
                resizeOffset.X = this.Right - this.Left - e.X;
                resizeOffset.Y = this.Bottom - this.Top - e.Y;
            }

            // The user clicked the window caption.
            else if (elementRectangles["windowCaption"].
                Contains(e.Location))
            {
                isMoving = true;
                originalClick.X = e.X;
                originalClick.Y = e.Y;
            }

            Invalidate();
        }

        // Stop any current resizing or moving actions.
        void ImitationWindow_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop moving the location of the window rectangles.
            if (isMoving)
            {
                isMoving = false;
            }

            // Change the cursor back to the default if the user 
            // stops resizing.
            else if (isResizing)
            {
                isResizing = false;
            }

            // Close the application if the user clicks the 
            // close button.
            else if (elementRectangles["windowClose"].
                Contains(e.Location) && isClosing)
            {
                Application.Exit();
            }
        }

        // Handle resizing or moving actions.
        void ImitationWindow_MouseMove(object sender,
            MouseEventArgs e)
        {
            // The left mouse button is down.
            if ((MouseButtons.Left & e.Button) == MouseButtons.Left)
            {
                // Calculate the new control size if the user is 
                // dragging the resizing grip.
                if (isResizing)
                {
                    this.Width = e.X + resizeOffset.X;
                    this.Height = e.Y + resizeOffset.Y;
                    CalculateRectangles();
                }

                // Calculate the new location of the control if the  
                // user is dragging the window caption.
                else if (isMoving)
                {
                    int XChange = this.Location.X +
                        (e.X - originalClick.X);
                    int YChange = this.Location.Y +
                        (e.Y - originalClick.Y);
                    this.Location = new Point(XChange, YChange);
                }

                // Cancel the closing action if the user clicked  
                // and held down on the close button, and has dragged   
                // the pointer outside the button.
                else if (!elementRectangles["windowClose"].
                    Contains(e.Location) && isClosing)
                {
                    isClosing = false;
                    windowElements["windowClose"] =
                        VisualStyleElement.Window.CloseButton.Normal;
                }
            }

            // The left mouse button is not down.
            else
            {
                // Paint the close button hot if the cursor is on it.
                Rectangle closeRectangle =
                    elementRectangles["windowClose"];
                windowElements["windowClose"] =
                    closeRectangle.Contains(e.Location) ?
                    VisualStyleElement.Window.CloseButton.Hot :
                    VisualStyleElement.Window.CloseButton.Normal;

                // Use a resizing cursor if the cursor is on the 
                // status grip.
                Rectangle gripRectangle =
                    elementRectangles["statusGripper"];
                this.Cursor = gripRectangle.Contains(e.Location) ?
                    Cursors.SizeNWSE : Cursors.Default;
            }

            Invalidate();
        }

        // <Snippet30>
        // Calculate and set the clipping region for the control  
        // so that the corners of the title bar are rounded.
        private void SetClipRegion()
        {
            if (!Application.RenderWithVisualStyles)
            {
                return;
            }

            using (Graphics g = this.CreateGraphics())
            {
                // Get the current region for the window caption.
                if (SetRenderer(windowElements["windowCaption"]))
                {
                    Region clipRegion = renderer.GetBackgroundRegion(
                        g, elementRectangles["windowCaption"]);

                    // Get the client rectangle, but exclude the region 
                    // of the window caption.
                    int height = (int)clipRegion.GetBounds(g).Height;
                    Rectangle nonCaptionRect = new Rectangle(
                        ClientRectangle.X,
                        ClientRectangle.Y + height,
                        ClientRectangle.Width,
                        ClientRectangle.Height - height);

                    // Add the rectangle to the caption region, and  
                    // make this region the form's clipping region.
                    clipRegion.Union(nonCaptionRect);
                    this.Region = clipRegion;
                }
            }
        }
        // </Snippet30>

        // <Snippet40>
        // Set the VisualStyleRenderer to a new element.
        private bool SetRenderer(VisualStyleElement element)
        {
            if (!VisualStyleRenderer.IsElementDefined(element))
            {
                return false;
            }

            if (renderer == null)
            {
                renderer = new VisualStyleRenderer(element);
            }
            else
            {
                renderer.SetParameters(element);
            }

            return true;
        }
        // </Snippet40>
    }
}
// </Snippet0>