using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class PathGeometryExample : Page
    {
        public PathGeometryExample()
        {
            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(SimpleLine());
            mainPanel.Children.Add(SimpleBezierLine());
            mainPanel.Children.Add(SimpleQuadraticBezierLine());
            mainPanel.Children.Add(ArcSegmentLine());
            mainPanel.Children.Add(TwoLineSegments());
            mainPanel.Children.Add(TwoPathFigures());
            this.Content = mainPanel;
        }

        private Path SimpleLine()
        {
            // <SnippetPathGeometryLineSegmentInline>
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 50);

            LineSegment myLineSegment = new LineSegment();
            myLineSegment.Point = new Point(200, 70);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myLineSegment);

            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </SnippetPathGeometryLineSegmentInline>
            return myPath;
        }

        private Path SimpleBezierLine()
        {
            // <Snippet33>
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 100);

            BezierSegment myBezierSegment = new BezierSegment();
            myBezierSegment.Point1 = new Point(100, 0);
            myBezierSegment.Point2 = new Point(200, 200);
            myBezierSegment.Point3 = new Point(300, 100);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myBezierSegment);

            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </Snippet33>
            return myPath;
        }

        private Path SimpleQuadraticBezierLine()
        {
            // <Snippet34>
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 100);

            QuadraticBezierSegment myQuadraticBezierSegment = new QuadraticBezierSegment();
            myQuadraticBezierSegment.Point1 = new Point(200, 200);
            myQuadraticBezierSegment.Point2 = new Point(300, 100);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myQuadraticBezierSegment);

            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </Snippet34>
            return myPath;
        }

        private Path ArcSegmentLine()
        {
            // <Snippet36>
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 100);

            ArcSegment myArcSegment = new ArcSegment();
            myArcSegment.Size = new Size(100, 50);
            myArcSegment.RotationAngle = 45;
            myArcSegment.IsLargeArc = true;
            myArcSegment.SweepDirection = SweepDirection.Counterclockwise;
            myArcSegment.Point = new Point(200, 100);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myArcSegment);

            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </Snippet36>
            return myPath;
        }

        private Path TwoLineSegments()
        {
            // <Snippet49>
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 100);
            myPathFigure.IsClosed = true;

            LineSegment myLineSegment1 = new LineSegment();
            myLineSegment1.Point = new Point(100, 100);
            LineSegment myLineSegment2 = new LineSegment();
            myLineSegment2.Point = new Point(100, 50);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myLineSegment1);
            myPathSegmentCollection.Add(myLineSegment2);
            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </Snippet49>
            return myPath;
        }

        private Path TwoPathFigures()
        {
            // <Snippet38>
            PathFigure myPathFigure1 = new PathFigure();
            myPathFigure1.StartPoint = new Point(10, 100);
            myPathFigure1.IsClosed = true;

            LineSegment myLineSegment1 = new LineSegment();
            myLineSegment1.Point = new Point(100, 100);
            LineSegment myLineSegment2 = new LineSegment();
            myLineSegment2.Point = new Point(100, 50);

            PathFigure myPathFigure2 = new PathFigure();
            myPathFigure2.StartPoint = new Point(10, 10);
            myPathFigure2.IsClosed = true;

            LineSegment myLineSegment3 = new LineSegment();
            myLineSegment3.Point = new Point(100, 10);
            LineSegment myLineSegment4 = new LineSegment();
            myLineSegment4.Point = new Point(100, 40);

            PathSegmentCollection myPathSegmentCollection1 = new PathSegmentCollection();
            myPathSegmentCollection1.Add(myLineSegment1);
            myPathSegmentCollection1.Add(myLineSegment2);
            myPathFigure1.Segments = myPathSegmentCollection1;

            PathSegmentCollection myPathSegmentCollection2 = new PathSegmentCollection();
            myPathSegmentCollection2.Add(myLineSegment3);
            myPathSegmentCollection2.Add(myLineSegment4);
            myPathFigure2.Segments = myPathSegmentCollection2;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure1);
            myPathFigureCollection.Add(myPathFigure2);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </Snippet38>
            return myPath;
        }
    }
}