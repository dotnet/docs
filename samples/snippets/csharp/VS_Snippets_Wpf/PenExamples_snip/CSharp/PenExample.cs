// <SnippetPenExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace SDKSample
{
    public partial class PenExample : Page
    {
        public PenExample()
        {
            // Create several geometries.
            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = new Rect(0, 0, 50, 50);
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(75, 75);
            myEllipseGeometry.RadiusX = 50;
            myEllipseGeometry.RadiusY = 50;
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new Point(75, 75);
            myLineGeometry.EndPoint = new Point(75, 0);

            // Create a GeometryGroup and add the geometries to it.
            GeometryGroup myGeometryGroup = new GeometryGroup();
            myGeometryGroup.Children.Add(myRectangleGeometry);
            myGeometryGroup.Children.Add(myEllipseGeometry);
            myGeometryGroup.Children.Add(myLineGeometry);

            // Create a GeometryDrawing and use the GeometryGroup to specify
            // its geometry.
            GeometryDrawing myGeometryDrawing = new GeometryDrawing();
            myGeometryDrawing.Geometry = myGeometryGroup;

            // Add the GeometryDrawing to a DrawingGroup.
            DrawingGroup myDrawingGroup = new DrawingGroup();
            myDrawingGroup.Children.Add(myGeometryDrawing);

            // Create a Pen to add to the GeometryDrawing created above.
            Pen myPen = new Pen();
            myPen.Thickness = 10;
            myPen.LineJoin = PenLineJoin.Round;
            myPen.EndLineCap = PenLineCap.Round;

            // Create a gradient to use as a value for the Pen's Brush property.
            GradientStop firstStop = new GradientStop();
            firstStop.Offset = 0.0;
            Color c1 = new Color();
            c1.A = 255;
            c1.R = 204;
            c1.G = 204;
            c1.B = 255;
            firstStop.Color = c1;
            GradientStop secondStop = new GradientStop();
            secondStop.Offset = 1.0;
            secondStop.Color = Colors.Purple;
            
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.GradientStops.Add(firstStop);
            myLinearGradientBrush.GradientStops.Add(secondStop);

            myPen.Brush = myLinearGradientBrush;
            myGeometryDrawing.Pen = myPen;

            // Create an Image and set its DrawingImage to the Geometry created above.
            Image myImage = new Image();
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(10);

            DrawingImage myDrawingImage = new DrawingImage();
            myDrawingImage.Drawing = myDrawingGroup;
            myImage.Source = myDrawingImage;

            this.Content = myImage;

        }      
    }
}
// </SnippetPenExampleWholePage>