// <SnippetStreamGeometryPolyLineToExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace SDKSample
{
    public partial class StreamGeometryPolyLineToExample : Page
    {
        public StreamGeometryPolyLineToExample()
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
                // Begin the triangle at the point specified.
                ctx.BeginFigure(new Point(10, 100), true /* is filled */, true /* is closed */);

                // Create a collection of Point structures that will be used with the PolyLineTo
                // Method to create a triangle.
                List<Point> pointList = new List<Point>();

                // Two Points are added to the collection. The PolyLineTo method will draw lines
                // between the Points of the collection.
                pointList.Add(new Point(100, 100));
                pointList.Add(new Point(100, 50));

                // Create a triangle using the collection of Point Structures.
                ctx.PolyLineTo(pointList, true /* is stroked */, false /* is smooth join */);
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();

            // specify the shape (triangle) of the path using the StreamGeometry.
            myPath.Data = geometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetStreamGeometryPolyLineToExampleWholePage>