namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Shapes;
    using System.Windows.Media;

 
    public partial class FollowMouseCanvas : Canvas
    {
        private Vector _velocity = new Vector(0, 0);
        private Point _parentLastMousePosition = new Point(0, 0);
        private Canvas _parentCanvas = null;
        private TimeSpan _lastRender;
       

        public FollowMouseCanvas()
            : base()
        {
            _lastRender = TimeSpan.FromTicks(DateTime.Now.Ticks);
            CompositionTarget.Rendering += UpdatePosition;
        }

        private void UpdatePosition(object sender, EventArgs e)
        {

            RenderingEventArgs renderingArgs = (RenderingEventArgs)e;

            double deltaTime = (renderingArgs.RenderingTime - _lastRender).TotalSeconds;
            _lastRender = renderingArgs.RenderingTime;
            
            if (_parentCanvas == null)
            {
                _parentCanvas = VisualTreeHelper.GetParent(this) as Canvas;
                if (_parentCanvas == null)
                {
                    //parent isnt canvas so just abort trying to follow mouse
                    CompositionTarget.Rendering -= UpdatePosition;
                }
                else
                {
                    //parent is canvas, so track mouse position and time
                    _parentCanvas.PreviewMouseMove += UpdateLastMousePosition;
                    
                }
            }


            //get location
            Point location = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
            
            //check for NaN's and replace with 0,0
            if (double.IsNaN(location.X) || double.IsNaN(location.Y))
                location = new Point(0, 0);

            //find vector toward mouse location
            Vector toMouse = _parentLastMousePosition - location;

            //add a force toward the mouse to the rectangles velocity
            double followForce = 1.0;
            _velocity += toMouse * followForce;

            //dampen the velocity to add stability
            double drag = 0.95;
            _velocity *= drag;

            //update the new location from the velocity
            location += _velocity * deltaTime;

            //set new position
            Canvas.SetLeft(this, location.X);
            Canvas.SetTop(this, location.Y);
        }

        private void UpdateLastMousePosition(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_parentCanvas == null)
                return;

            _parentLastMousePosition = e.GetPosition(_parentCanvas);
        }
    }
}