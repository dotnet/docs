using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CompositionTargetSample
{
    public partial class Window1 : Window
    {
        private System.Windows.Point _pt;
        private Stopwatch _stopwatch = new Stopwatch();
        private double _frameCounter = 0;

        public Window1()
        {
            InitializeComponent();

            //<SnippetCompositionTarget1>
            // Add an event handler to update canvas background color just before it is rendered.
            CompositionTarget.Rendering += UpdateColor;
            //</SnippetCompositionTarget1>
        }

        //<SnippetCompositionTarget2>
        // Called just before frame is rendered to allow custom drawing.
        protected void UpdateColor(object sender, EventArgs e)
        {
            if (_frameCounter++ == 0)
            {
                // Starting timing.
                _stopwatch.Start();
            }

            // Determine frame rate in fps (frames per second).
            long frameRate = (long)(_frameCounter / this._stopwatch.Elapsed.TotalSeconds);
            if (frameRate > 0)
            {
                // Update elapsed time, number of frames, and frame rate.
                myStopwatchLabel.Content = _stopwatch.Elapsed.ToString();
                myFrameCounterLabel.Content = _frameCounter.ToString();
                myFrameRateLabel.Content = frameRate.ToString();
            }

            // Update the background of the canvas by converting MouseMove info to RGB info.
            byte redColor = (byte)(_pt.X / 3.0);
            byte blueColor = (byte)(_pt.Y / 2.0);
            myCanvas.Background = new SolidColorBrush(Color.FromRgb(redColor, 0x0, blueColor));
        }
        //</SnippetCompositionTarget2>

        public void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            // Retrieve the coordinates of the mouse button event.
            _pt = e.GetPosition((UIElement)sender);
        }
    }
}
