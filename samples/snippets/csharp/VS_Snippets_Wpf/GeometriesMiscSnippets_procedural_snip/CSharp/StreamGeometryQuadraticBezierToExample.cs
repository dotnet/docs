// <SnippetStreamGeometryQuadraticBezierToExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class StreamGeometryQuadraticBezierToExample : Page
    {
        public StreamGeometryQuadraticBezierToExample()
        {
            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // Create a StreamGeometry to use to specify myPath.
            StreamGeometry geometry = new StreamGeometry();

            // Open a StreamGeometryContext that can be used to describe this StreamGeometry
            // object's contents.
            using (StreamGeometryContext ctx = geometry.Open())
            {
                // Set the begin point of the shape.
                ctx.BeginFigure(new Point(10, 100), true /* is filled */, false /* is closed */);

                // Create a Quadratic Bezier curve using the 2 specifed points. The first point
                // specifies the control point while the second point specifies the end point
                // of the curve.
                ctx.QuadraticBezierTo(new Point(100, 0), new Point(200, 200), true /* is stroked */,
                                      false /* is smooth join */);
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();

            // specify the shape (quadratic Bezier curve) of the path using the StreamGeometry.
            myPath.Data = geometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetStreamGeometryQuadraticBezierToExampleWholePage>