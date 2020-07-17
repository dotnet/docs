//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using System.Threading;
namespace GeoOvwSample
{
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>

    public class GeometryExamples : Page
    {
        public GeometryExamples()
        {

            ScrollViewer scroller = new ScrollViewer();
            StackPanel mainPanel = new StackPanel();

            Border graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 200;
            graphBorder.Height = 150;
            graphBorder.Child = CreateLineGeometryExample();
            mainPanel.Children.Add(graphBorder);

            graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 200;
            graphBorder.Height = 150;
            graphBorder.Child = CreateEllipseGeometryExample();
            mainPanel.Children.Add(graphBorder);

            graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 200;
            graphBorder.Height = 150;
            graphBorder.Child = CreateRectangleGeometryExample();
            mainPanel.Children.Add(graphBorder);

            graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 200;
            graphBorder.Height = 150;
            graphBorder.Child = CreateImageClipGeometryExample();
            mainPanel.Children.Add(graphBorder);

            graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 200;
            graphBorder.Height = 150;
            graphBorder.Child = CreatePathGeometryLineExample();
            mainPanel.Children.Add(graphBorder);

            graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 450;
            graphBorder.Height = 250;
            graphBorder.Child = CreatePathGeometryComplexExample();
            mainPanel.Children.Add(graphBorder);

            graphBorder = new Border();
            graphBorder.Style = (Style)Application.Current.Resources["GraphBorderStyle"];
            graphBorder.Width = 450;
            graphBorder.Height = 250;
            graphBorder.Child = CreatePathGeometryComplexMultiExample();
            mainPanel.Children.Add(graphBorder);

            scroller.Content = mainPanel;
            this.Content = scroller;
        }

        public FrameworkElement CreateLineGeometryExample()
        {

            // <SnippetGraphicsMMLineGeometryExample>
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new Point(10,20);
            myLineGeometry.EndPoint = new Point(100,130);

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;
            // </SnippetGraphicsMMLineGeometryExample>

            return myPath;
        }

        public FrameworkElement CreateEllipseGeometryExample()
        {

            // <SnippetGraphicsMMEllipseGeometryExample>
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(50, 50);
            myEllipseGeometry.RadiusX = 50;
            myEllipseGeometry.RadiusY = 50;

            Path myPath = new Path();
            myPath.Fill = Brushes.Gold;
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myEllipseGeometry;
            // </SnippetGraphicsMMEllipseGeometryExample>

            return myPath;
        }

        public FrameworkElement CreateRectangleGeometryExample()
        {

            // <SnippetGraphicsMMRectangleGeometryExample>
            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = new Rect(50,50,25,25);

            Path myPath = new Path();
            myPath.Fill = Brushes.LemonChiffon;
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myRectangleGeometry;
            // </SnippetGraphicsMMRectangleGeometryExample>

            return myPath;
        }

        public FrameworkElement CreateImageClipGeometryExample()
        {

            // <SnippetGraphicsMMImageClipGeometryExample>

            // Create the image to clip.
            Image myImage = new Image();
            Uri imageUri =
                new Uri(@"C:\\Documents and Settings\\All Users\\Documents\My Pictures\\Sample Pictures\\Water lilies.jpg", UriKind.Relative);
            myImage.Source = new BitmapImage(imageUri);
            myImage.Width = 200;
            myImage.Height = 150;
            myImage.HorizontalAlignment = HorizontalAlignment.Left;

            // Use an EllipseGeometry to define the clip region.
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(100, 75);
            myEllipseGeometry.RadiusX = 100;
            myEllipseGeometry.RadiusY = 75;
            myImage.Clip = myEllipseGeometry;

            // </SnippetGraphicsMMImageClipGeometryExample>

            return myImage;
        }

        public FrameworkElement CreatePathGeometryLineExample()
        {

            // <SnippetGraphicsMMPathGeometryLineExample>

            // Create a figure that describes a
            // line from (10,20) to (100,130).
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10,20);
            myPathFigure.Segments.Add(
                new LineSegment(new Point(100,130),
                true /* IsStroked */ ));

            /// Create a PathGeometry to contain the figure.
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            // Display the PathGeometry.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </SnippetGraphicsMMPathGeometryLineExample>

            return myPath;
        }

        public FrameworkElement CreatePathGeometryComplexExample()
        {

            // <SnippetGraphicsMMPathGeometryComplexExample>

            // Create a figure.
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10,50);
            myPathFigure.Segments.Add(
                new BezierSegment(
                    new Point(100,0),
                    new Point(200,200),
                    new Point(300,100),
                    true /* IsStroked */  ));
            myPathFigure.Segments.Add(
                new LineSegment(
                    new Point(400,100),
                    true /* IsStroked */ ));
            myPathFigure.Segments.Add(
                new ArcSegment(
                    new Point(200,100),
                    new Size(50,50),
                    45,
                    true, /* IsLargeArc */
                    SweepDirection.Clockwise,
                    true /* IsStroked */ ));

            /// Create a PathGeometry to contain the figure.
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            // Display the PathGeometry.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </SnippetGraphicsMMPathGeometryComplexExample>

            return myPath;
        }

        public FrameworkElement CreatePathGeometryComplexMultiExample()
        {

            // <SnippetGraphicsMMPathGeometryComplexMultiExample>

            PathGeometry myPathGeometry = new PathGeometry();

            // Create a figure.
            PathFigure pathFigure1 = new PathFigure();
            pathFigure1.StartPoint = new Point(10,50);
            pathFigure1.Segments.Add(
                new BezierSegment(
                    new Point(100,0),
                    new Point(200,200),
                    new Point(300,100),
                    true /* IsStroked */ ));
            pathFigure1.Segments.Add(
                new LineSegment(
                    new Point(400,100),
                    true /* IsStroked */ ));
            pathFigure1.Segments.Add(
                new ArcSegment(
                    new Point(200,100),
                    new Size(50,50),
                    45,
                    true, /* IsLargeArc */
                    SweepDirection.Clockwise,
                    true /* IsStroked */ ));
            myPathGeometry.Figures.Add(pathFigure1);

            // Create another figure.
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(10,100);
            Point[] polyLinePointArray =
                new Point[]{ new Point(50, 100), new Point(50, 150)};
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);
            pathFigure2.Segments.Add(
                new QuadraticBezierSegment(
                    new Point(200,200),
                    new Point(300,100),
                    true /* IsStroked */ ));
            myPathGeometry.Figures.Add(pathFigure2);

            // Display the PathGeometry.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            // </SnippetGraphicsMMPathGeometryComplexMultiExample>

            return myPath;
        }
     }
}