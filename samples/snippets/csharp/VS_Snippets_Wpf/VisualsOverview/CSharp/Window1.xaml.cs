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

        // Handle the Click event for the button.
        private void OnClick(object sender, EventArgs e)
        {
        }
     }

    //<Snippet100>
    // Create a visual object derived from DrawingVisual.
    class MyRectangle : DrawingVisual
    {
        public MyRectangle(Color myColor, Rect myRect, string caption)
        {
            // Return a drawing context to draw into.
            DrawingContext dc = RenderOpen();

            // Draw a rectangle into the drawing context.
            dc.DrawRectangle(new SolidColorBrush(myColor), null, myRect);

            // Create a text string and draw it in the drawing context.
            FormattedText formattedText = new FormattedText(caption, CultureInfo.CurrentCulture,
                 FlowDirection.LeftToRight,
                 new Typeface("Verdana"), 36, Brushes.Black);
            dc.DrawText(formattedText, new Point(myRect.Left + 10, myRect.Top + 5));

            // Close the drawing context to persist the changes.
            dc.Close();
        }
    }
    //</Snippet100>

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
            MyRectangle myRect = new MyRectangle(
                        Brushes.LightBlue.Color,
                        new Rect(new Point(160, 100), new Size(320, 80)),
                        "Hello, world!");
            _children.Add(myRect);
            _children.Add(CreateDrawingVisualEllipses());
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
        }

        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Enumerate all the descendants of the visual host object.
            EnumVisual(this);

            // Get bounding rectangle of parent and descendants.
            Rect r = GetBoundingRectangle(this);

            // Find a DrawingVisual in the hit object.
            FindDrawingVisual(this, e.GetPosition(this));
        }

        //<Snippet101>
        // Enumerate all the descendants of the visual object.
        static public void EnumVisual(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                // Do processing of the child visual object.

                // Enumerate children of the child visual object.
                EnumVisual(childVisual);
            }
        }
        //</Snippet101>

        // Get the combined bounding rectangle of the parent visual and its descendants.
        static public Rect GetBoundingRectangle(Visual parentVisual)
        {
            //<Snippet102>
            // Return the bounding rectangle of the parent visual object and all of its descendants.
            Rect rectBounds = VisualTreeHelper.GetDescendantBounds(parentVisual);
            //</Snippet102>

            return rectBounds;
        }

        //<SnippetVisualsOverviewSnippet4>
        // Determine if a geometry within the visual was hit.
        static public void HitTestGeometryInVisual(Visual visual, Point pt)
        {
            // Retrieve the group of drawings for the visual.
            DrawingGroup drawingGroup = VisualTreeHelper.GetDrawing(visual);
            EnumDrawingGroup(drawingGroup, pt);
        }

        // Enumerate the drawings in the DrawingGroup.
        static public void EnumDrawingGroup(DrawingGroup drawingGroup, Point pt)
        {
            DrawingCollection drawingCollection = drawingGroup.Children;

            // Enumerate the drawings in the DrawingCollection.
            foreach (Drawing drawing in drawingCollection)
            {
                // If the drawing is a DrawingGroup, call the function recursively.
                if (drawing.GetType() == typeof(DrawingGroup))
                {
                    EnumDrawingGroup((DrawingGroup)drawing, pt);
                }
                else if (drawing.GetType() == typeof(GeometryDrawing))
                {
                    // Determine whether the hit test point falls within the geometry.
                    if (((GeometryDrawing)drawing).Geometry.FillContains(pt))
                    {
                        // Perform action based on hit test on geometry.
                    }
                }
            }
        }
        //</SnippetVisualsOverviewSnippet4>

        // Find a DrawingVisual in the hit object.
        static public void FindDrawingVisual(Visual myVisual, Point pt)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                DrawingVisual dv = new DrawingVisual();
                if (childVisual.GetType() == dv.GetType())
                {
                    DrawingGroup dg = VisualTreeHelper.GetDrawing(childVisual);

                    // Hit test geometry of drawing.
                    HitTestGeometryInVisual(childVisual, pt);
                }
                // Do processing of the child visual object.

                // Enumerate children of the child visual object.
                FindDrawingVisual(childVisual, pt);
            }
        }

        // Create a DrawingVisual that contains an ellipse.
        private DrawingVisual CreateDrawingVisualEllipses()
        {
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();

            dc.DrawEllipse(Brushes.Gray, null, new Point(430, 136), 20, 20);
            dc.DrawEllipse(Brushes.SteelBlue, null, new Point(480, 136), 20, 20);
            dc.DrawEllipse(Brushes.Maroon, null, new Point(530, 136), 20, 20);
            // Create a text string and draw it in the drawing context.
            FormattedText formattedText = new FormattedText("Hi", CultureInfo.CurrentCulture,
                 FlowDirection.LeftToRight,
                 new Typeface("Verdana"), 24, Brushes.Black);
            dc.DrawText(formattedText, new Point(430-12, 136-12));
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