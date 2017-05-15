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
             MyVisualHost vh = new MyVisualHost();
             MyCanvas.Children.Add(vh);
         }
     }

    // Create a host visual derived from the FrameworkElement class.
    // This class provides layout, event handling, and container support for
    // the child visual objects.
    public class MyVisualHost : FrameworkElement
    {
        // Create a collection of child visual objects.
        private VisualCollection _children;
        private ContainerVisual _containerVisual;

        public MyVisualHost()
        {
            _children = new VisualCollection(this);

            // <SnippetContainerVisualSnippet1>
            // Create a ContainerVisual and add children to it.
            ContainerVisual containerVisual = new ContainerVisual();
            containerVisual.Children.Add(CreateDrawingVisualRectangle());
            containerVisual.Children.Add(CreateDrawingVisualText());
            containerVisual.Children.Add(CreateDrawingVisualEllipses());
            // </SnippetContainerVisualSnippet1>

            // <SnippetContainerVisualSnippet3>
            if (containerVisual.Children.Count > 0)
            {
                VisualCollection collection = containerVisual.Children;
            }
            // </SnippetContainerVisualSnippet3>

            _containerVisual = containerVisual;
            _children.Add(_containerVisual);
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);

            // <SnippetContainerVisualSnippet4>
            // Return the bounding rectangle for the ContainerVisual.
            Rect rectBounds = containerVisual.ContentBounds;

            // Expand the rectangle to include the bounding rectangle
            // of the all of the ContainerVisual's descendants.
            rectBounds.Union(containerVisual.DescendantBounds);
            // </SnippetContainerVisualSnippet4>
        }

        // <SnippetContainerVisualSnippet2>
        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retrieve the coordinates of the mouse button event.
            Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test on the ContainerVisual's visual tree.
            HitTestResult result = _containerVisual.HitTest(pt);

            // Perform the action on the hit visual.
            if (result.VisualHit != null)
            {
                ProcessHitVisual((Visual)result.VisualHit);
            }
        }
        // </SnippetContainerVisualSnippet2>

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public static void ProcessHitVisual(Visual visual)
        {
            if (visual.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)visual).Opacity == 1.0)
                {
                    ((DrawingVisual)visual).Opacity = 0.4;
                }
                else
                {
                    ((DrawingVisual)visual).Opacity = 1.0;
                }
            }
        }

        // Create a DrawingVisual that contains a rectangle.
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();

            Rect r = new Rect(new Point(160, 100), new Size(320, 80));
            dc.DrawRectangle(Brushes.LightBlue, (Pen)null, r);
            dc.Close();

            return dv;
        }

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
                  36, Brushes.Black),
                  new Point(200, 116));

            // Close the DrawingContext to persist changes to the DrawingVisual.
            drawingContext.Close();

            return drawingVisual;
        }

        // Create a DrawingVisual that contains an ellipse.
        private DrawingVisual CreateDrawingVisualEllipses()
        {
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();

            dc.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
            dc.Close();

            return dv;
        }

        // Provide a required override for the VisualChildCount property.
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index > _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (Visual)_children[index];
        }

        // Provide a required override for the MeasureOverride method.
        protected override Size MeasureOverride(Size availableSize)
        {
            // Return the value of the parameter.
            return base.MeasureOverride(availableSize);
        }

        // Provide a required override for the ArrangeOverride method.
        protected override Size ArrangeOverride(Size finalSize)
        {
            // Return the value of the parameter.
            return base.ArrangeOverride(finalSize);
        }
    }
}