using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation; 

namespace Microsoft.Samples.PerFrameAnimations
{
    /// <summary>
    /// Interaction logic for FrameIndependentFollowExample.xaml
    /// </summary>

    public partial class FrameIndependentFollowExample : Page
    {
        private Vector _rectangleVelocity = new Vector(0, 0);
        private Point _lastMousePosition = new Point(0, 0);

        //timing variables
        private TimeSpan _lastRender;
        
        
        public FrameIndependentFollowExample()
            : base()
        {
            InitializeComponent();
            _lastRender = TimeSpan.FromTicks(DateTime.Now.Ticks);
            CompositionTarget.Rendering += UpdateRectangle;
            this.PreviewMouseMove += UpdateLastMousePosition;
            
        }

        private void UpdateRectangle(object sender, EventArgs e)
        {


            RenderingEventArgs renderArgs = (RenderingEventArgs)e;
            Double deltaTime = (renderArgs.RenderingTime - _lastRender).TotalSeconds;
            _lastRender = renderArgs.RenderingTime;
            
            
            Point location = new Point(Canvas.GetLeft(followRectangle), Canvas.GetTop(followRectangle));           
            
            //find vector toward mouse location
            Vector toMouse = _lastMousePosition - location;

            //add a force toward the mouse to the rectangles velocity
            double followForce = 1.00;
            _rectangleVelocity += toMouse * followForce;

            //dampen the velocity to add stability
            double drag = 0.9;
            _rectangleVelocity *= drag;

            //update the new location from the velocity
            location += _rectangleVelocity * deltaTime;

            //set new position
            Canvas.SetLeft(followRectangle, location.X);
            Canvas.SetTop(followRectangle, location.Y);
        }
        

        private void UpdateLastMousePosition(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _lastMousePosition = e.GetPosition(containerCanvas);
        }
        
       
    }
}