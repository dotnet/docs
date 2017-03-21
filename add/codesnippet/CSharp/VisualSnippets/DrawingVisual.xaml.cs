using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class DrawingVisualWindow : Window
    {
        private void WindowLoaded(object sender, EventArgs e)
        {
             MyVisualHost2 visualHost = new MyVisualHost2();
             MyCanvas.Children.Add(visualHost);

             RetrieveDrawings(visualHost);
        }

        //<SnippetDrawingVisualSnippet1>
        // Enumerate the DrawingVisual children of a host visual.
        public void RetrieveDrawings(Visual visualHost)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visualHost); i++)
            {
                // Retrieve child visual at specified index value.
                DependencyObject dependencyObject = VisualTreeHelper.GetChild(visualHost, i);

                // Determine if the child object is a DrawingVisual.
                if (dependencyObject.GetType() == typeof(DrawingVisual))
                {
                    DrawingVisual drawingVisual = (DrawingVisual)dependencyObject;

                    if (drawingVisual.Drawing != null)
                    {
                        if (drawingVisual.Drawing.GetType() == typeof(DrawingGroup))
                        {
                            // Enumerate the drawings in the DrawingGroup.
                            EnumDrawingGroup(drawingVisual.Drawing);
                        }
                    }
                }
             }
         }

         // Enumerate the drawings in the DrawingGroup.
         public void EnumDrawingGroup(DrawingGroup drawingGroup)
         {
             DrawingCollection dc = drawingGroup.Children;

             // Enumerate the drawings in the DrawingCollection.
             foreach (Drawing drawing in dc)
             {
                 // If the drawing is a DrawingGroup, call the function recursively.
                 if (drawing.GetType() == typeof(DrawingGroup))
                 {
                     EnumDrawingGroup((DrawingGroup)drawing);
                 }

                 if (drawing.GetType() == typeof(GeometryDrawing))
                 {
                     // Perform action based on drawing type.
                 }
             }
         }
         //</SnippetDrawingVisualSnippet1>
     }

    // Create a host visual derived from the FrameworkElement class.
    // This class provides layout, event handling, and container support for
    // the child visual objects.
    public class MyVisualHost2 : FrameworkElement
    {
        // Create a collection of child visual objects.
        private VisualCollection _children;

        public MyVisualHost2()
        {
            _children = new VisualCollection(this);
            _children.Add(CreateDrawingVisualRectangle());
            _children.Add(CreateDrawingVisualText());
            _children.Add(CreateDrawingVisualEllipses());
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
        }

        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retreive the coordinates of the mouse button event.
            Point pt = e.GetPosition((UIElement)sender);

            HitTestResult result = this.HitTestCore(new PointHitTestParameters(pt));

            if ((result != null) && (result.VisualHit.GetType() == typeof(DrawingVisual)))
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

        // Create a DrawingVisual that contains a rectangle.
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
            drawingContext.DrawRectangle(Brushes.LightBlue, (Pen)null, rect);
            drawingContext.Close();

            return drawingVisual;
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
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            drawingContext.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
            drawingContext.Close();

            return drawingVisual;
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