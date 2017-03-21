// <snippet100>
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfTouchFrameSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // <snippet110>
    public partial class MainWindow : Window
    {
        // Variables for tracking the position of two points.
        Point pt1, pt2 = new Point();
        
        public MainWindow()
        {
            InitializeComponent();
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            if (this.canvas1 != null)
            {
                // <snippet120>
                foreach (TouchPoint _touchPoint in e.GetTouchPoints(this.canvas1))
                {
                    if (_touchPoint.Action == TouchAction.Down)
                    {
                        // Clear the canvas and capture the touch to it.
                        this.canvas1.Children.Clear();
                        _touchPoint.TouchDevice.Capture(this.canvas1);
                    }

                    else if (_touchPoint.Action == TouchAction.Move && e.GetPrimaryTouchPoint(this.canvas1) != null)
                    {   
                        // This is the first (primary) touch point. Just record its position.
                        if (_touchPoint.TouchDevice.Id == e.GetPrimaryTouchPoint(this.canvas1).TouchDevice.Id)
                        {
                            pt1.X = _touchPoint.Position.X;
                            pt1.Y = _touchPoint.Position.Y;
                        }

                        // This is not the first touch point. Draw a line from the first point to this one.
                        else if (_touchPoint.TouchDevice.Id != e.GetPrimaryTouchPoint(this.canvas1).TouchDevice.Id)
                        {
                            pt2.X = _touchPoint.Position.X;
                            pt2.Y = _touchPoint.Position.Y;

                            Line _line = new Line();
                            _line.Stroke = new RadialGradientBrush(Colors.White, Colors.Black);
                            _line.X1 = pt1.X;
                            _line.X2 = pt2.X;
                            _line.Y1 = pt1.Y;
                            _line.Y2 = pt2.Y;
                            _line.StrokeThickness = 2;
                            this.canvas1.Children.Add(_line);
                        }
                    }

                    else if (_touchPoint.Action == TouchAction.Up)
                    {
                        // If this touch is captured to the canvas, release it.
                        if (_touchPoint.TouchDevice.Captured == this.canvas1)
                        {
                            this.canvas1.ReleaseTouchCapture(_touchPoint.TouchDevice);
                        }
                    }
                }                        
                // </snippet120>
            }
        }
    }
    // </snippet110>
}
// </snippet100>
