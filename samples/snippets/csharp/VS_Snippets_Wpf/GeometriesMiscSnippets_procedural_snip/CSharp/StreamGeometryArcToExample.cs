// <SnippetStreamGeometryArcToExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class StreamGeometryArcToExample : Page
    {
        public StreamGeometryArcToExample()
        {
            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // Create a StreamGeometry to use to specify myPath.
            StreamGeometry geometry = new StreamGeometry();
            geometry.FillRule = FillRule.EvenOdd;

            // Open a StreamGeometryContext that can be used to describe this StreamGeometry object's contents.
            using (StreamGeometryContext ctx = geometry.Open())
            {
                // Set the begin point of the shape.
                ctx.BeginFigure(new Point(10, 100), true /* is filled */, false /* is closed */);

                // Create an arc. Draw the arc from the begin point to 200,100 with the specified parameters.
                ctx.ArcTo(new Point(200, 100), new Size(100, 50), 45 /* rotation angle */, true /* is large arc */,
                          SweepDirection.Counterclockwise, true /* is stroked */, false /* is smooth join */);
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();

            // specify the shape (arc) of the path using the StreamGeometry.
            myPath.Data = geometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetStreamGeometryArcToExampleWholePage>