﻿// <SnippetStreamGeometryExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class StreamGeometryExample : Page
    {
        public StreamGeometryExample()
        {
            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // Create a StreamGeometry to use to specify myPath.
            StreamGeometry theGeometry = BuildRegularPolygon(new Point(200, 200), 200, 8, 0);
            theGeometry.FillRule = FillRule.EvenOdd;

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            theGeometry.Freeze();

            // Use the StreamGeometry returned by the BuildRegularPolygon to
            // specify the shape of the path.
            myPath.Data = theGeometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }

        StreamGeometry BuildRegularPolygon(Point c, double r, int numSides, double offsetDegree)
        {
            // c is the center, r is the radius,
            // numSides the number of sides, offsetDegree the offset in Degrees.
            // Do not add the last point.

            StreamGeometry geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(new Point(), true /* is filled */, true /* is closed */);

                double step = 2 * Math.PI / Math.Max(numSides, 3);
                Point cur = c;

                double a = Math.PI * offsetDegree / 180.0;
                for (int i = 0; i < numSides; i++, a += step)
                {
                    cur.X = c.X + r * Math.Cos(a);
                    cur.Y = c.Y + r * Math.Sin(a);
                    ctx.LineTo(cur, true /* is stroked */, false /* is smooth join */);
                }
            }

            return geometry;
        }
    }
}
// </SnippetStreamGeometryExampleWholePage>