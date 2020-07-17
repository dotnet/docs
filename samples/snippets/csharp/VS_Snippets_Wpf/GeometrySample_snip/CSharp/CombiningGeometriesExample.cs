using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class CombiningGeometriesExample : Page
    {
        public CombiningGeometriesExample()
        {
            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(CompositeShape1());
            mainPanel.Children.Add(CompositeShape2());
            mainPanel.Children.Add(CompositeShape3());
            mainPanel.Children.Add(CompositeShape4());
            mainPanel.Children.Add(CompositeShape5());
            mainPanel.Children.Add(CompositeShape6());
            this.Content = mainPanel;
        }

        private Path CompositeShape1()
        {
            // <Snippet19>
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 50);
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new Point(10, 10);
            myLineGeometry.EndPoint = new Point(50, 30);

            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(40, 70);
            myEllipseGeometry.RadiusX = 30;
            myEllipseGeometry.RadiusY = 30;

            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = new Rect(30,55, 100,30);

            GeometryGroup myGeometryGroup = new GeometryGroup();
            myGeometryGroup.FillRule = FillRule.EvenOdd;
            myGeometryGroup.Children.Add(myLineGeometry);
            myGeometryGroup.Children.Add(myEllipseGeometry);
            myGeometryGroup.Children.Add(myRectangleGeometry);

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;
            myPath.Data = myGeometryGroup;
            // </Snippet19>
            return myPath;
        }

        private Path CompositeShape2()
        {
            // <Snippet20>
            PathFigure myPathFigure = new PathFigure();

            EllipseGeometry myEllipseGeometry1 = new EllipseGeometry();
            myEllipseGeometry1.Center = new Point(75, 75);
            myEllipseGeometry1.RadiusX = 50;
            myEllipseGeometry1.RadiusY = 50;

            EllipseGeometry myEllipseGeometry2 = new EllipseGeometry();
            myEllipseGeometry2.Center = new Point(125, 75);
            myEllipseGeometry2.RadiusX = 50;
            myEllipseGeometry2.RadiusY = 50;

            GeometryGroup myGeometryGroup = new GeometryGroup();
            myGeometryGroup.FillRule = FillRule.Nonzero;
            myGeometryGroup.Children.Add(myEllipseGeometry1);
            myGeometryGroup.Children.Add(myEllipseGeometry2);

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;
            myPath.Data = myGeometryGroup;
            // </Snippet20>
            return myPath;
        }

        private Path CompositeShape3()
        {
            // <Snippet21>
            PathFigure myPathFigure = new PathFigure();

            EllipseGeometry myEllipseGeometry1 = new EllipseGeometry();
            myEllipseGeometry1.Center = new Point(75, 75);
            myEllipseGeometry1.RadiusX = 50;
            myEllipseGeometry1.RadiusY = 50;

            EllipseGeometry myEllipseGeometry2 = new EllipseGeometry();
            myEllipseGeometry2.Center = new Point(125, 75);
            myEllipseGeometry2.RadiusX = 50;
            myEllipseGeometry2.RadiusY = 50;

            CombinedGeometry myCombinedGeometry = new CombinedGeometry();

            // Combines two geometries using the Exclude combine mode.
            myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Exclude;
            myCombinedGeometry.Geometry1 = myEllipseGeometry1;
            myCombinedGeometry.Geometry2 = myEllipseGeometry2;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;
            myPath.Data = myCombinedGeometry;
            // </Snippet21>
            return myPath;
        }

        private Path CompositeShape4()
        {
            // <Snippet22>
            PathFigure myPathFigure = new PathFigure();

            EllipseGeometry myEllipseGeometry1 = new EllipseGeometry();
            myEllipseGeometry1.Center = new Point(75, 75);
            myEllipseGeometry1.RadiusX = 50;
            myEllipseGeometry1.RadiusY = 50;

            EllipseGeometry myEllipseGeometry2 = new EllipseGeometry();
            myEllipseGeometry2.Center = new Point(125, 75);
            myEllipseGeometry2.RadiusX = 50;
            myEllipseGeometry2.RadiusY = 50;

            CombinedGeometry myCombinedGeometry = new CombinedGeometry();

            // Combines two geometries using the Intersect combine mode.
            myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Intersect;
            myCombinedGeometry.Geometry1 = myEllipseGeometry1;
            myCombinedGeometry.Geometry2 = myEllipseGeometry2;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;
            myPath.Data = myCombinedGeometry;
            // </Snippet22>
            return myPath;
        }

        private Path CompositeShape5()
        {
            // <Snippet23>
            PathFigure myPathFigure = new PathFigure();

            EllipseGeometry myEllipseGeometry1 = new EllipseGeometry();
            myEllipseGeometry1.Center = new Point(75, 75);
            myEllipseGeometry1.RadiusX = 50;
            myEllipseGeometry1.RadiusY = 50;

            EllipseGeometry myEllipseGeometry2 = new EllipseGeometry();
            myEllipseGeometry2.Center = new Point(125, 75);
            myEllipseGeometry2.RadiusX = 50;
            myEllipseGeometry2.RadiusY = 50;

            CombinedGeometry myCombinedGeometry = new CombinedGeometry();

            // Combines two geometries using the Union combine mode.
            myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Union;
            myCombinedGeometry.Geometry1 = myEllipseGeometry1;
            myCombinedGeometry.Geometry2 = myEllipseGeometry2;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;
            myPath.Data = myCombinedGeometry;
            // </Snippet23>
            return myPath;
        }

        private Path CompositeShape6()
        {
            // <Snippet24>
            PathFigure myPathFigure = new PathFigure();

            EllipseGeometry myEllipseGeometry1 = new EllipseGeometry();
            myEllipseGeometry1.Center = new Point(75, 75);
            myEllipseGeometry1.RadiusX = 50;
            myEllipseGeometry1.RadiusY = 50;

            EllipseGeometry myEllipseGeometry2 = new EllipseGeometry();
            myEllipseGeometry2.Center = new Point(125, 75);
            myEllipseGeometry2.RadiusX = 50;
            myEllipseGeometry2.RadiusY = 50;

            CombinedGeometry myCombinedGeometry = new CombinedGeometry();

            // Combines two geometries using the XOR combine mode.
            myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Xor;
            myCombinedGeometry.Geometry1 = myEllipseGeometry1;
            myCombinedGeometry.Geometry2 = myEllipseGeometry2;

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;
            myPath.Data = myCombinedGeometry;
            // </Snippet24>
            return myPath;
        }
    }
}