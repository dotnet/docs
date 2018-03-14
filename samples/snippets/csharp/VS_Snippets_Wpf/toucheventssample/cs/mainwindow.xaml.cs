// <snippet100>
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace WpfTouchEventsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variables to track the first two touch points 
        // and the ID of the first touch point.
        private Point pt1, pt2 = new Point();
        private int firstTouchId = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        // <snippet110>
        private void canvas_TouchDown(object sender, TouchEventArgs e)
        {
            Canvas _canvas = (Canvas)sender as Canvas;
            if (_canvas != null)
            {
                _canvas.Children.Clear();
                e.TouchDevice.Capture(_canvas);

                // Record the ID of the first touch point if it hasn't been recorded.
                if (firstTouchId == -1)
                    firstTouchId = e.TouchDevice.Id;
            }
        }
        // </snippet110>

        // <snippet120>
        private void canvas_TouchMove(object sender, TouchEventArgs e)
        {
            Canvas _canvas = (Canvas)sender as Canvas;
            if (_canvas != null)
            {
                TouchPoint tp = e.GetTouchPoint(_canvas);
                // This is the first touch point; just record its position.
                if (e.TouchDevice.Id == firstTouchId)
                {
                    pt1.X = tp.Position.X;
                    pt1.Y = tp.Position.Y;
                }
                // This is not the first touch point; draw a line from the first point to this one.
                else if (e.TouchDevice.Id != firstTouchId)
                {
                    pt2.X = tp.Position.X;
                    pt2.Y = tp.Position.Y;

                    Line _line = new Line();
                    _line.Stroke = new RadialGradientBrush(Colors.White, Colors.Black);
                    _line.X1 = pt1.X;
                    _line.X2 = pt2.X;
                    _line.Y1 = pt1.Y;
                    _line.Y2 = pt2.Y;

                    _line.StrokeThickness = 2;
                    _canvas.Children.Add(_line);
                }
            }
        }
        // </snippet120>

        // <snippet130>
        private void canvas_TouchUp(object sender, TouchEventArgs e)
        {
            Canvas _canvas = (Canvas)sender as Canvas;
            if (_canvas != null && e.TouchDevice.Captured == _canvas)
            {
                _canvas.ReleaseTouchCapture(e.TouchDevice);
            }
        }
        // </snippet130>
    }
}
// </snippet100>
