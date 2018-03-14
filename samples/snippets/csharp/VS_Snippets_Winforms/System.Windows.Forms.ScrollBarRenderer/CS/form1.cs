// This sample can go in ScrollBarRenderer class overview.
// - Snippet2 can go in IsSupported, DrawRightHorizontalTrack, 
//   DrawHorizontalThumb, DrawHorizontalThumbGrip, DrawArrowButton, 
//   and, if necessary, ScrollBarState and ScrollBarArrowButtonState enums.

// This sample simulates a horizontal scroll bar. 
// For simplicity, this sample does not handle runtime switching of visual styles.


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ScrollBarRendererSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            this.Size = new Size(500, 500);

            CustomScrollBar Bar1 = new CustomScrollBar();
            Bar1.Location = new Point(50, 100);
            Bar1.Size = new Size(200, 20);

            Controls.Add(Bar1);
        }

        [STAThread]
        static void Main()
        {
            // The call to EnableVisualStyles below does not affect whether 
            // ScrollBarRenderer.IsSupported is true; as long as visual styles 
            // are enabled by the operating system, IsSupported is true.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomScrollBar : Control
    {
        private Rectangle clickedBarRectangle;
        private Rectangle thumbRectangle;
        private Rectangle leftArrowRectangle;
        private Rectangle rightArrowRectangle;
        private bool leftArrowClicked = false;
        private bool rightArrowClicked = false;
        private bool leftBarClicked = false;
        private bool rightBarClicked = false;
        private bool thumbClicked = false;
        private ScrollBarState thumbState = ScrollBarState.Normal;
        private ScrollBarArrowButtonState leftButtonState =
            ScrollBarArrowButtonState.LeftNormal;
        private ScrollBarArrowButtonState rightButtonState =
            ScrollBarArrowButtonState.RightNormal;

        // This control does not allow these widths to be altered.
        private int thumbWidth = 15;
        private int arrowWidth = 17;

        // Set the right limit of the thumb's right border.
        private int thumbRightLimitRight = 0;

        // Set the right limit of the thumb's left border.
        private int thumbRightLimitLeft = 0;

        // Set the left limit of thumb's left border.
        private int thumbLeftLimit = 0;

        // Set the distance from the left edge of the thumb to the 
        // cursor tip.
        private int thumbPosition = 0;

        // Set the distance from the left edge of the scroll bar track 
        // to the cursor tip.
        private int trackPosition = 0;

        // This timer draws the moving thumb while the scroll arrows or 
        // track are pressed.
        private Timer progressTimer = new Timer();

        public CustomScrollBar()
            : base()
        {
            this.Location = new Point(10, 10);
            this.Width = 200;
            this.Height = 20;
            this.DoubleBuffered = true;

            SetUpScrollBar();
            progressTimer.Interval = 20;
            progressTimer.Tick += new EventHandler(progressTimer_Tick);
        }

        // Calculate the sizes of the scroll bar elements.
        private void SetUpScrollBar()
        {
            clickedBarRectangle = ClientRectangle;
            thumbRectangle = new Rectangle(
                ClientRectangle.X + ClientRectangle.Width / 2,
                ClientRectangle.Y, thumbWidth,
                ClientRectangle.Height);
            leftArrowRectangle = new Rectangle(
                ClientRectangle.X, ClientRectangle.Y,
                arrowWidth, ClientRectangle.Height);
            rightArrowRectangle = new Rectangle(
                ClientRectangle.Right - arrowWidth,
                ClientRectangle.Y, arrowWidth,
                ClientRectangle.Height);

            // Set the default starting thumb position.
            thumbPosition = thumbWidth / 2;

            // Set the right limit of the thumb's right border.
            thumbRightLimitRight = ClientRectangle.Right - arrowWidth;

            // Set the right limit of the thumb's left border.
            thumbRightLimitLeft = thumbRightLimitRight - thumbWidth;

            // Set the left limit of the thumb's left border.
            thumbLeftLimit = ClientRectangle.X + arrowWidth;
        }

        //<Snippet2>
        // Draw the scroll bar in its normal state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Visual styles are not enabled.
            if (!ScrollBarRenderer.IsSupported)
            {
                this.Parent.Text = "CustomScrollBar Disabled";
                return;
            }

            this.Parent.Text = "CustomScrollBar Enabled";

            // Draw the scroll bar track.
            ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics,
                ClientRectangle, ScrollBarState.Normal);

            // Draw the thumb and thumb grip in the current state.
            ScrollBarRenderer.DrawHorizontalThumb(e.Graphics,
                thumbRectangle, thumbState);
            ScrollBarRenderer.DrawHorizontalThumbGrip(e.Graphics,
                thumbRectangle, thumbState);

            // Draw the scroll arrows in the current state.
            ScrollBarRenderer.DrawArrowButton(e.Graphics,
                    leftArrowRectangle, leftButtonState);
            ScrollBarRenderer.DrawArrowButton(e.Graphics,
                    rightArrowRectangle, rightButtonState);

            // Draw a highlighted rectangle in the left side of the scroll 
            // bar track if the user has clicked between the left arrow 
            // and thumb.
            if (leftBarClicked)
            {
                clickedBarRectangle.X = thumbLeftLimit;
                clickedBarRectangle.Width = thumbRectangle.X - thumbLeftLimit;
                ScrollBarRenderer.DrawLeftHorizontalTrack(e.Graphics,
                    clickedBarRectangle, ScrollBarState.Pressed);
            }

            // Draw a highlighted rectangle in the right side of the scroll 
            // bar track if the user has clicked between the right arrow 
            // and thumb.
            else if (rightBarClicked)
            {
                clickedBarRectangle.X =
                    thumbRectangle.X + thumbRectangle.Width;
                clickedBarRectangle.Width =
                    thumbRightLimitRight - clickedBarRectangle.X;
                ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics,
                    clickedBarRectangle, ScrollBarState.Pressed);
            }
        }
        //</Snippet2>

        // Handle a mouse click in the scroll bar.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!ScrollBarRenderer.IsSupported)
                return;

            // When the thumb is clicked, update the distance from the left
            // edge of the thumb to the cursor tip.
            if (thumbRectangle.Contains(e.Location))
            {
                thumbClicked = true;
                thumbPosition = e.Location.X - thumbRectangle.X;
                thumbState = ScrollBarState.Pressed;
            }

            // When the left arrow is clicked, start the timer to scroll 
            // while the arrow is held down.
            else if (leftArrowRectangle.Contains(e.Location))
            {
                leftArrowClicked = true;
                leftButtonState = ScrollBarArrowButtonState.LeftPressed;
                progressTimer.Start();
            }

            // When the right arrow is clicked, start the timer to scroll 
            // while the arrow is held down.
            else if (rightArrowRectangle.Contains(e.Location))
            {
                rightArrowClicked = true;
                rightButtonState = ScrollBarArrowButtonState.RightPressed;
                progressTimer.Start();
            }

            // When the scroll bar is clicked, start the timer to move the
            // thumb while the mouse is held down.
            else
            {
                trackPosition = e.Location.X;

                if (e.Location.X < this.thumbRectangle.X)
                {
                    leftBarClicked = true;
                }
                else
                {
                    rightBarClicked = true;
                }
                progressTimer.Start();
            }

            Invalidate();
        }

        // Draw the track.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (!ScrollBarRenderer.IsSupported)
                return;

            // Update the thumb position, if the new location is within 
            // the bounds.
            if (thumbClicked)
            {
                thumbClicked = false;
                thumbState = ScrollBarState.Normal;

                if (e.Location.X > (thumbLeftLimit + thumbPosition) &&
                    e.Location.X < (thumbRightLimitLeft + thumbPosition))
                {
                    thumbRectangle.X = e.Location.X - thumbPosition;
                    thumbClicked = false;
                }
            }

            // If one of the four thumb movement areas was clicked, 
            // stop the timer.
            else if (leftArrowClicked)
            {
                leftArrowClicked = false;
                leftButtonState = ScrollBarArrowButtonState.LeftNormal;
                progressTimer.Stop();
            }

            else if (rightArrowClicked)
            {
                rightArrowClicked = false;
                rightButtonState = ScrollBarArrowButtonState.RightNormal;
                progressTimer.Stop();
            }

            else if (leftBarClicked)
            {
                leftBarClicked = false;
                progressTimer.Stop();
            }

            else if (rightBarClicked)
            {
                rightBarClicked = false;
                progressTimer.Stop();
            }

            Invalidate();
        }

        // Track mouse movements if the user clicks on the scroll bar thumb.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!ScrollBarRenderer.IsSupported)
                return;

            // Update the thumb position, if the new location is 
            // within the bounds.
            if (thumbClicked)
            {
                // The thumb is all the way to the left.
                if (e.Location.X <= (thumbLeftLimit + thumbPosition))
                {
                    thumbRectangle.X = thumbLeftLimit;
                }

                // The thumb is all the way to the right.
                else if (e.Location.X >= (thumbRightLimitLeft + thumbPosition))
                {
                    thumbRectangle.X = thumbRightLimitLeft;
                }

                // The thumb is between the ends of the track.
                else
                {
                    thumbRectangle.X = e.Location.X - thumbPosition;
                }

                Invalidate();
            }
        }

        // Recalculate the sizes of the scroll bar elements.
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetUpScrollBar();
        }

        // Handle the timer tick by updating the thumb position.
        private void progressTimer_Tick(object sender, EventArgs myEventArgs)
        {
            if (!ScrollBarRenderer.IsSupported)
                return;

            // If an arrow is clicked, move the thumb in small increments.
            if (rightArrowClicked && thumbRectangle.X < thumbRightLimitLeft)
            {
                thumbRectangle.X++;
            }
            else if (leftArrowClicked && thumbRectangle.X > thumbLeftLimit)
            {
                thumbRectangle.X--;
            }

            // If the track bar to right of the thumb is clicked, move the 
            // thumb to the right in larger increments until the right edge 
            // of the thumb hits the cursor.
            else if (rightBarClicked &&
                thumbRectangle.X < thumbRightLimitLeft &&
                thumbRectangle.X + thumbRectangle.Width < trackPosition)
            {
                thumbRectangle.X += 3;
            }

            // If the track bar to left of the thumb is clicked, move the 
            // thumb to the left in larger increments until the left edge 
            // of the thumb hits the cursor.
            else if (leftBarClicked &&
                thumbRectangle.X > thumbLeftLimit &&
                thumbRectangle.X > trackPosition)
            {
                thumbRectangle.X -= 3;
            }

            Invalidate();
        }
    }
}
//</Snippet0>







