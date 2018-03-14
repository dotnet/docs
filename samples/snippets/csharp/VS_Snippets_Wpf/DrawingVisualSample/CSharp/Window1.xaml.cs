using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class Window1 : Window
    {
         private void WindowLoaded(object sender, EventArgs e)
         {
             MyVisualHost visualHost = new MyVisualHost();
             MyCanvas.Children.Add(visualHost);
         }
     }

    //<Snippet100> 
    // Create a host visual derived from the FrameworkElement class.
    // This class provides layout, event handling, and container support for
    // the child visual objects.
    public class MyVisualHost : FrameworkElement
    {
        // Create a collection of child visual objects.
        private VisualCollection _children;

        public MyVisualHost()
        {
            _children = new VisualCollection(this);
            _children.Add(CreateDrawingVisualRectangle());
            _children.Add(CreateDrawingVisualText());
            _children.Add(CreateDrawingVisualEllipses());

            // Add the event handler for MouseLeftButtonUp.
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
        }
        //</Snippet100> 

        //<Snippet103> 
        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retreive the coordinates of the mouse button event.
            System.Windows.Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test by setting up a hit test result callback method.
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Opacity == 1.0)
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 0.4;
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 1.0;
                }
            }

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Stop;
        }
        //</Snippet103> 

        //<Snippet101> 
        // Create a DrawingVisual that contains a rectangle.
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
            drawingContext.DrawRectangle(System.Windows.Media.Brushes.LightBlue, (System.Windows.Media.Pen)null, rect);

            // Persist the drawing content.
            drawingContext.Close();

            return drawingVisual;
        }
        //</Snippet101> 

        //<Snippet110> 
        // Create a DrawingVisual that contains text.
        private DrawingVisual CreateDrawingVisualText()
        {
            // Create an instance of a DrawingVisual.
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext from the DrawingVisual.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Draw a formatted text string into the DrawingContext.
            drawingContext.DrawText(
               new FormattedText("Click Me!",
                  CultureInfo.GetCultureInfo("en-us"),
                  FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  36, System.Windows.Media.Brushes.Black),
                  new System.Windows.Point(200, 116));

            // Close the DrawingContext to persist changes to the DrawingVisual.
            drawingContext.Close();

            return drawingVisual;
        }
        //</Snippet110> 

        // Create a DrawingVisual that contains an ellipse.
        private DrawingVisual CreateDrawingVisualEllipses()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            drawingContext.DrawEllipse(System.Windows.Media.Brushes.Maroon, null, new System.Windows.Point(430, 136), 20, 20);
            drawingContext.Close();

            return drawingVisual;
        }

        //<Snippet102>

        //<Snippet102a>
        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }
        //</Snippet102a>

        //<Snippet102b>
        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }
        //</Snippet102b>

        //</Snippet102> 
    }
}