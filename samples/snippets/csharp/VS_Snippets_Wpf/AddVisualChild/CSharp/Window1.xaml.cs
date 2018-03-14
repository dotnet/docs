using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        MyVisualHost _visualHost;

         private void WindowLoaded(object sender, EventArgs e)
         {
             _visualHost = new MyVisualHost(CreateDrawingVisualRectangle(Brushes.LightBlue));
             MyCanvas.Children.Add(_visualHost);
         }

         private void OnClick(object sender, EventArgs e)
         {
             _visualHost.Child = CreateDrawingVisualRectangle(Brushes.Maroon);
         }

         // Create a DrawingVisual that contains a rectangle.
        public DrawingVisual CreateDrawingVisualRectangle(SolidColorBrush brush)
         {
             DrawingVisual drawingVisual = new DrawingVisual();

             // Retrieve the DrawingContext in order to create new drawing content.
             DrawingContext drawingContext = drawingVisual.RenderOpen();

             // Create a rectangle and draw it in the DrawingContext.
             Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
             drawingContext.DrawRectangle(null, new Pen(brush, 2.0), rect);

             // Persist the drawing content.
             drawingContext.Close();

             return drawingVisual;
         }
     }

    // <SnippetAddVisualChild01> 
    // Create a host visual derived from the FrameworkElement class.
    // This class provides layout, event handling, and container support for
    // the child visual object.
    public class MyVisualHost : FrameworkElement
    {
        private DrawingVisual _child;

        public MyVisualHost(DrawingVisual drawingVisual)
        {
            _child = drawingVisual;
            this.AddVisualChild(_child);
        }

        public DrawingVisual Child
        {
            get
            {
                return _child;
            }

            set
            {
                if (_child != value)
                {
                    this.RemoveVisualChild(_child);
                    _child = value;
                    this.AddVisualChild(_child);
                }
            }
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _child == null ? 0 : 1; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (_child == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _child;
        }
        // </SnippetAddVisualChild01>
    }
}