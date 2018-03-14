// <SnippetDrawingBrushExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SDKSample
{
    public class DrawingBrushExample : Page
    {

        public DrawingBrushExample()
        {

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

            DrawingBrush patternBrush = new DrawingBrush(aGeometryDrawing);
            patternBrush.Viewport = new Rect(0, 0, 0.25, 0.25);
            patternBrush.TileMode = TileMode.Tile;
            patternBrush.Freeze();

            //
            // Create an object to paint.
            //
            Rectangle paintedRectangle = new Rectangle();
            paintedRectangle.Width = 100;
            paintedRectangle.Height = 100;
            paintedRectangle.Fill = patternBrush;

            //
            // Place the image inside a border and
            // add it to the page.
            //
            Border exampleBorder = new Border();
            exampleBorder.Child = paintedRectangle;
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
// </SnippetDrawingBrushExampleWholePage>