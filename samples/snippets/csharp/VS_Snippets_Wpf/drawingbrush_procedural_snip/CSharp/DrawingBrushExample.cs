// <SnippetDrawingBrushExampleWholePage>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Microsoft.Samples.DrawingBrushExamples
{
    /// <summary>
    /// Paints a Rectangle element with a DrawingBrush.
    /// </summary>
    public class DrawingBrushExample : Page
    {
        public DrawingBrushExample()
        {
            Background = Brushes.White;
            StackPanel mainPanel = new StackPanel();

            // Create a drawing of two ellipses.
            GeometryDrawing aDrawing = new GeometryDrawing();

            // Use geometries to describe two overlapping ellipses.
            EllipseGeometry ellipse1 = new EllipseGeometry();
            ellipse1.RadiusX = 20;
            ellipse1.RadiusY = 45;
            ellipse1.Center = new Point(50, 50);
            EllipseGeometry ellipse2 = new EllipseGeometry();
            ellipse2.RadiusX = 45;
            ellipse2.RadiusY = 20;
            ellipse2.Center = new Point(50, 50);
            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(ellipse1);
            ellipses.Children.Add(ellipse2);

            // Add the geometry to the drawing.
            aDrawing.Geometry = ellipses;

            // Specify the drawing's fill.
            aDrawing.Brush = Brushes.Blue;

            // Specify the drawing's stroke.
            Pen stroke = new Pen();
            stroke.Thickness = 10.0;
            stroke.Brush = new LinearGradientBrush(
                Colors.Black, Colors.Gray, new Point(0, 0), new Point(1, 1));
            aDrawing.Pen = stroke;

            // Create a DrawingBrush
            DrawingBrush myDrawingBrush = new DrawingBrush();
            myDrawingBrush.Drawing = aDrawing;

            // Create a Rectangle element.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 150;
            aRectangle.Height = 150;
            aRectangle.Stroke = Brushes.Black;
            aRectangle.StrokeThickness = 1.0;

            // Use the DrawingBrush to paint the rectangle's
            // background.
            aRectangle.Fill = myDrawingBrush;

            mainPanel.Children.Add(aRectangle);

            this.Content = mainPanel;
        }
    }
}
// </SnippetDrawingBrushExampleWholePage>
