// <SnippetCompositeShapeCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class CompositeShapeExample : Page
    {
        public CompositeShapeExample()
        {
            // <SnippetCompositeShapeCodeExampleInline1>
            // Create a Path to be drawn to the screen.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath.Fill = mySolidColorBrush;

            // Create the line geometry to add to the Path
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new Point(10, 10);
            myLineGeometry.EndPoint = new Point(50, 30);

            // Create the ellipse geometry to add to the Path
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(40, 70);
            myEllipseGeometry.RadiusX = 30;
            myEllipseGeometry.RadiusY = 30;

            // Create a rectangle geometry to add to the Path
            RectangleGeometry myRectGeometry = new RectangleGeometry();
            myRectGeometry.Rect = new Rect(30, 55, 100, 30);

            // Add all the geometries to a GeometryGroup.
            GeometryGroup myGeometryGroup = new GeometryGroup();
            myGeometryGroup.Children.Add(myLineGeometry);
            myGeometryGroup.Children.Add(myEllipseGeometry);
            myGeometryGroup.Children.Add(myRectGeometry);

            myPath.Data = myGeometryGroup;

            // Add path shape to the UI.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(myPath);
            this.Content = mainPanel;
            // </SnippetCompositeShapeCodeExampleInline1>
            
        }
    }

}
// </SnippetCompositeShapeCodeExampleWholePage>
