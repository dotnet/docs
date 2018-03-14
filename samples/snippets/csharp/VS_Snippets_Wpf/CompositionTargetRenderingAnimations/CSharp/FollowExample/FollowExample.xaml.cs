using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft.Samples.PerFrameAnimations
{
    /// <summary>
    /// Interaction logic for FollowExample.xaml
    /// </summary>

    public partial class FollowExample : Page
    {
        private Vector _rectangleVelocity = new Vector(0,0);
        private Point _lastMousePosition = new Point(0, 0);

        public FollowExample()
            : base()
        {
            CompositionTarget.Rendering += UpdateRectangle;
            this.PreviewMouseMove += UpdateLastMousePosition;
        }

        private void UpdateRectangle(object sender, EventArgs e)
        {
            Point location = new Point(Canvas.GetLeft(followRectangle), Canvas.GetTop(followRectangle));
            
            //find vector toward mouse location
            Vector toMouse = _lastMousePosition - location;

            //add a force toward the mouse to the rectangles velocity
            double followForce = 0.01;
            _rectangleVelocity += toMouse * followForce;

            //dampen the velocity to add stability
            double drag = 0.8;
            _rectangleVelocity *= drag;

            //update the new location from the velocity
            location += _rectangleVelocity;
            
            //set new position
            Canvas.SetLeft(followRectangle, location.X);
            Canvas.SetTop(followRectangle, location.Y);
        }

        void UpdateLastMousePosition(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _lastMousePosition = e.GetPosition(containerCanvas);
        }
    }
}