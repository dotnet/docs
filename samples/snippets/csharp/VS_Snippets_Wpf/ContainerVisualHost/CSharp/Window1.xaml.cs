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
             MyContainerVisualHost vh = new MyContainerVisualHost(CreateDrawingVisualRectangle(), CreateDrawingVisualText());
             MyCanvas.Children.Add(vh);
         }

         private void OnClick(object sender, EventArgs e)
         {
         }

         // Create a DrawingVisual that contains a rectangle.
         public DrawingVisual CreateDrawingVisualRectangle()
         {
             DrawingVisual dv = new DrawingVisual();
             DrawingContext dc = dv.RenderOpen();

             Rect r = new Rect(new Point(160, 100), new Size(320, 80));
             dc.DrawRectangle(Brushes.LightBlue, (Pen)null, r);
             dc.Close();

             return dv;
         }

         // Create a DrawingVisual that contains text.
        public DrawingVisual CreateDrawingVisualText()
         {
             // Create an instance of a DrawingVisual.
             DrawingVisual drawingVisual = new DrawingVisual();

             // Retrieve the DrawingContext from the DrawingVisual.
             DrawingContext drawingContext = drawingVisual.RenderOpen();

             // Draw a formatted text string into the DrawingContext.
             drawingContext.DrawText(
                new FormattedText("Hello, world!",
                   CultureInfo.GetCultureInfo("en-us"),
                   FlowDirection.LeftToRight,
                   new Typeface("Verdana"),
                   36, Brushes.Black),
                   new Point(200, 116));

             // Close the DrawingContext to persist changes to the DrawingVisual.
             drawingContext.Close();

             return drawingVisual;
         }

     }

    // <SnippetContainerVisualHost01>
    // Create a host visual derived from the FrameworkElement class.
    // This class provides layout, event handling, and container support for
    // the child visual objects.
    public class MyContainerVisualHost : FrameworkElement
    {
        private ContainerVisual _containerVisual;

        public MyContainerVisualHost(DrawingVisual border, DrawingVisual text)
        {
            // Create a ContainerVisual to hold DrawingVisual children.
            _containerVisual = new ContainerVisual();

            // Add children to ContainerVisual in reverse z-order (bottom to top).
            _containerVisual.Children.Add(border);
            _containerVisual.Children.Add(text);

            // Create parent-child relationship with host visual and ContainerVisual.
            this.AddVisualChild(_containerVisual);
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _containerVisual == null ? 0 : 1; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (_containerVisual == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _containerVisual;
        }
    }
    // </SnippetContainerVisualHost01>
}