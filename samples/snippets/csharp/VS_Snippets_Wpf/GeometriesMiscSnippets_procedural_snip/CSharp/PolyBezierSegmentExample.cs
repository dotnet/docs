// <SnippetPolyBezierSegmentCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class PolyBezierSegmentExample : Page
    {
        public PolyBezierSegmentExample()
        {

            // Create a PathFigure to be used for the PathGeometry of myPath.
            PathFigure myPathFigure = new PathFigure();

            // Set the starting point for the PathFigure specifying that the
            // geometry starts at point 10,100.
            myPathFigure.StartPoint = new Point(10, 100);

            // Create a PointCollection that holds the Points used to specify 
            // the points of the PolyBezierSegment below.
            PointCollection myPointCollection = new PointCollection(6);
            myPointCollection.Add(new Point(0, 0));
            myPointCollection.Add(new Point(200, 0));
            myPointCollection.Add(new Point(300, 100));
            myPointCollection.Add(new Point(300, 0));
            myPointCollection.Add(new Point(400, 0));
            myPointCollection.Add(new Point(600, 100));

            // The PolyBezierSegment specifies two cubic Bezier curves.
            // The first curve is from 10,100 (start point specified by the PathFigure)
            // to 300,100 with a control point of 0,0 and another control point 
            // of 200,0. The second curve is from 300,100 (end of the last curve) to 
            // 600,100 with a control point of 300,0 and another control point of 400,0.
            PolyBezierSegment myBezierSegment = new PolyBezierSegment();
            myBezierSegment.Points = myPointCollection;

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myBezierSegment);

            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // specify the shape (quadratic Bezier curve) of the path using the StreamGeometry.
            myPath.Data = myPathGeometry;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
        }
    }
}
// </SnippetPolyBezierSegmentCodeExampleWholePage>