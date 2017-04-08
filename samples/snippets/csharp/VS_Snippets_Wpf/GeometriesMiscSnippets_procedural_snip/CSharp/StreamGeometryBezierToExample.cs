// <SnippetStreamGeometryBezierToExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class StreamGeometryBezierToExample : Page
    {
        public StreamGeometryBezierToExample()
        {

            // Create a StreamGeometry to use to specify myPath.
            StreamGeometry geometry = new StreamGeometry();
            geometry.FillRule = FillRule.EvenOdd;

            // Open a StreamGeometryContext that can be used to describe this StreamGeometry 
            // object's contents.
            using (StreamGeometryContext ctx = geometry.Open())
            {
                // Set the begin point of the shape.
                ctx.BeginFigure(new Point(10, 100), true /* is filled */, false /* is closed */);

                // Create a Bezier curve using the 3 specifed points where the first two points
                // are control points and the last point is the destination point for the curve.
                ctx.BezierTo(new Point(100, 0), new Point(200,200), new Point(300,100), 
                             true /* is stroked */, false /* is smooth join */);

            }

            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();

            // specify the shape (Bezier Curve) of the path using the StreamGeometry.
            myPath.Data = geometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetStreamGeometryBezierToExampleWholePage>