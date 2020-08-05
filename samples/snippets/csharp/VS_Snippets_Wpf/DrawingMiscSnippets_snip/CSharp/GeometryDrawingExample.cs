// <SnippetGeometryDrawingExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SDKSample
{
    public class GeometryDrawingExample : Page
    {
        public GeometryDrawingExample()
        {

            // <SnippetGeometryDrawingExampleInline>
            //
            // Create the Geometry to draw.
            //
            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(
                new EllipseGeometry(new Point(50,50), 45, 20)
                );
            ellipses.Children.Add(
                new EllipseGeometry(new Point(50, 50), 20, 45)
                );

            //
            // Create a GeometryDrawing.
            //
            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            aGeometryDrawing.Geometry = ellipses;

            // Paint the drawing with a gradient.
            aGeometryDrawing.Brush =
                new LinearGradientBrush(
                    Colors.Blue,
                    Color.FromRgb(204,204,255),
                    new Point(0,0),
                    new Point(1,1));

            // Outline the drawing with a solid color.
            aGeometryDrawing.Pen = new Pen(Brushes.Black, 10);
            // </SnippetGeometryDrawingExampleInline>

            //
            // Use a DrawingImage and an Image control
            // to display the drawing.
            //
            DrawingImage geometryImage = new DrawingImage(aGeometryDrawing);

            // Freeze the DrawingImage for performance benefits.
            geometryImage.Freeze();

            Image anImage = new Image();
            anImage.Source = geometryImage;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            //
            // Place the image inside a border and
            // add it to the page.
            //
            Border exampleBorder = new Border();
            exampleBorder.Child = anImage;
            exampleBorder.BorderBrush = Brushes.Gray;
            exampleBorder.BorderThickness = new Thickness(1);
            exampleBorder.HorizontalAlignment = HorizontalAlignment.Left;
            exampleBorder.VerticalAlignment = VerticalAlignment.Top;
            exampleBorder.Margin = new Thickness(10);

            this.Margin = new Thickness(20);
            this.Background = Brushes.White;
            this.Content = exampleBorder;
        }
    }
}
// </SnippetGeometryDrawingExampleWholePage>
