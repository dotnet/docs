// This sample can go in TrackBarRenderer class overview.
// - Snippet2 can go in GetTopPointingThumbSize, and possibly other Gets
// - Snippet4 can go in IsSupported, DrawHorizontalTrack, and DrawTopPointingThumb
// - Snippet6 can go in DrawVerticalTick; see below about bug in the meantime, though


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TrackBarRendererSample
{
    class Form1 : Form
    {
        public Form1()
        {
            CustomTrackBar TrackBar1 = new CustomTrackBar(19,
                new Size(300, 50));
            this.Width = 500;
            this.Controls.Add(TrackBar1);
        }

        [STAThread]
        static void Main()
        {
            // Note that the call to EnableVisualStyles below does
            // not affect whether TrackBarRenderer.IsSupported is true; 
            // as long as visual styles are enabled by the operating system, 
            // IsSupported is true.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    class CustomTrackBar : Control
    {
        private int numberTicks = 10;
        private Rectangle trackRectangle = new Rectangle();
        private Rectangle ticksRectangle = new Rectangle();
        private Rectangle thumbRectangle = new Rectangle();
        private int currentTickPosition = 0;
        private float tickSpace = 0;
        private bool thumbClicked = false;
        private TrackBarThumbState thumbState =
            TrackBarThumbState.Normal;

        public CustomTrackBar(int ticks, Size trackBarSize)
        {
            this.Location = new Point(10, 10);
            this.Size = trackBarSize;
            this.numberTicks = ticks;
            this.BackColor = Color.DarkCyan;
            this.DoubleBuffered = true;

            // Calculate the initial sizes of the bar, 
            // thumb and ticks.
            SetupTrackBar();
        }

        //<Snippet2>
        //<Snippet6>
        // Calculate the sizes of the bar, thumb, and ticks rectangle.
        private void SetupTrackBar()
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            using (Graphics g = this.CreateGraphics())
            {
                // Calculate the size of the track bar.
                trackRectangle.X = ClientRectangle.X + 2;
                trackRectangle.Y = ClientRectangle.Y + 28;
                trackRectangle.Width = ClientRectangle.Width - 4;
                trackRectangle.Height = 4;

                // Calculate the size of the rectangle in which to 
                // draw the ticks.
                ticksRectangle.X = trackRectangle.X + 4;
                ticksRectangle.Y = trackRectangle.Y - 8;
                ticksRectangle.Width = trackRectangle.Width - 8;
                ticksRectangle.Height = 4;

                tickSpace = ((float)ticksRectangle.Width - 1) /
                    ((float)numberTicks - 1);

                // Calculate the size of the thumb.
                thumbRectangle.Size =
                    TrackBarRenderer.GetTopPointingThumbSize(g,
                    TrackBarThumbState.Normal);

                thumbRectangle.X = CurrentTickXCoordinate();
                thumbRectangle.Y = trackRectangle.Y - 8;
            }
        }
        //</Snippet2>

        private int CurrentTickXCoordinate()
        {
            if (tickSpace == 0)
            {
                return 0;
            }
            else
            {
                return ((int)Math.Round(tickSpace) *
                    currentTickPosition);
            }
        }

        //<Snippet4>
        // Draw the track bar.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                this.Parent.Text = "CustomTrackBar Disabled";
                return;
            }

            this.Parent.Text = "CustomTrackBar Enabled";
            TrackBarRenderer.DrawHorizontalTrack(e.Graphics,
                trackRectangle);
            TrackBarRenderer.DrawTopPointingThumb(e.Graphics,
                thumbRectangle, thumbState);
            TrackBarRenderer.DrawHorizontalTicks(e.Graphics,
                ticksRectangle, numberTicks, EdgeStyle.Raised);
        }
        //</Snippet6>

        // Determine whether the user has clicked the track bar thumb.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            if (this.thumbRectangle.Contains(e.Location))
            {
                thumbClicked = true;
                thumbState = TrackBarThumbState.Pressed;
            }

            this.Invalidate();
        }
        //</Snippet4>

        // Redraw the track bar thumb if the user has moved it.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            if (thumbClicked == true)
            {
                if (e.Location.X > trackRectangle.X &&
                    e.Location.X < (trackRectangle.X +
                    trackRectangle.Width - thumbRectangle.Width))
                {
                    thumbClicked = false;
                    thumbState = TrackBarThumbState.Hot;
                    this.Invalidate();
                }

                thumbClicked = false;
            }
        }

        // Track cursor movements.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            // The user is moving the thumb.
            if (thumbClicked == true)
            {
                // Track movements to the next tick to the right, if 
                // the cursor has moved halfway to the next tick.
                if (currentTickPosition < numberTicks - 1 &&
                    e.Location.X > CurrentTickXCoordinate() +
                    (int)(tickSpace))
                {
                    currentTickPosition++;
                }

                // Track movements to the next tick to the left, if 
                // cursor has moved halfway to the next tick.
                else if (currentTickPosition > 0 &&
                    e.Location.X < CurrentTickXCoordinate() -
                    (int)(tickSpace / 2))
                {
                    currentTickPosition--;
                }

                thumbRectangle.X = CurrentTickXCoordinate();
            }

            // The cursor is passing over the track.
            else
            {
                thumbState = thumbRectangle.Contains(e.Location) ?
                    TrackBarThumbState.Hot : TrackBarThumbState.Normal;
            }

            Invalidate();
        }
    }
}
//</Snippet0>