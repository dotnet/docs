// <SnippetStreamGeometryTriangleExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    // Use StreamGeometry with StreamGeometryContext to define a triangle shape.
    public partial class StreamGeometryTriangleExample : Page
    {
        public StreamGeometryTriangleExample()
        {
            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // Create a StreamGeometry to use to specify myPath.
            StreamGeometry geometry = new StreamGeometry();
            geometry.FillRule = FillRule.EvenOdd;

            // Open a StreamGeometryContext that can be used to describe this StreamGeometry
            // object's contents.
            using (StreamGeometryContext ctx = geometry.Open())
            {

                // Begin the triangle at the point specified. Notice that the shape is set to
                // be closed so only two lines need to be specified below to make the triangle.
                ctx.BeginFigure(new Point(10, 100), true /* is filled */, true /* is closed */);

                // Draw a line to the next specified point.
                ctx.LineTo(new Point(100, 100), true /* is stroked */, false /* is smooth join */);

                // Draw another line to the next specified point.
                ctx.LineTo(new Point(100, 50), true /* is stroked */, false /* is smooth join */);
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();

            // Specify the shape (triangle) of the Path using the StreamGeometry.
            myPath.Data = geometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetStreamGeometryTriangleExampleWholePage>