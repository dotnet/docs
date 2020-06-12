// <SnippetStreamGeometryPolyBezierToExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace SDKSample
{
    public partial class StreamGeometryPolyBezierToExample : Page
    {
        public StreamGeometryPolyBezierToExample()
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
                // Set the begin point of the shape.
                ctx.BeginFigure(new Point(10, 100), true /* is filled */, false /* is closed */);

                // Create a collection of Point structures that will be used with the PolyBezierTo
                // Method to create the Bezier curve.
                List<Point> pointList = new List<Point>();

                // First Bezier curve is specified with these three points.

                // First control point for first Bezier curve.
                pointList.Add(new Point(100,0));

                // Second control point for first Bezier curve.
                pointList.Add(new Point(200, 200));

                // Destination point for first Bezier curve.
                pointList.Add(new Point(300, 100));

                // Second Bezier curve is specified with these three points.

                // First control point for second Bezier curve.
                pointList.Add(new Point(400, 0));

                // Second control point for second Bezier curve.
                pointList.Add(new Point(500, 200));

                // Destination point for second Bezier curve.
                pointList.Add(new Point(600, 100));

                // Create a Bezier curve using the collection of Point Structures.
                ctx.PolyBezierTo(pointList, true /* is stroked */, false /* is smooth join */);
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();

            // specify the shape (Bezier curve) of the path using the StreamGeometry.
            myPath.Data = geometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetStreamGeometryPolyBezierToExampleWholePage>