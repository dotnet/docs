// <SnippetDrawingGroupClipGeometryExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SDKSample
{
    /// <summary>
    /// Shows how to define a clip region for a DrawingGroup.
    /// </summary>
    public class ClipExample : Page
    {
        public ClipExample()
        {

            //
            // Create several GeometryDrawing objects.
            //

            // Create a rectangle.
            GeometryDrawing drawing1 = new GeometryDrawing(
                Brushes.Pink,
                null, 
                new RectangleGeometry(new Rect(0,0,50,85))
                );

            //
            // Create a polygon.
            //
            PathFigure pLineFigure = new PathFigure();
            pLineFigure.StartPoint = new Point(25, 25);
            PolyLineSegment pLineSegment = new PolyLineSegment();
            pLineSegment.Points.Add(new Point(0, 50));
            pLineSegment.Points.Add(new Point(25, 75));
            pLineSegment.Points.Add(new Point(50, 50));
            pLineSegment.Points.Add(new Point(25, 25));
            pLineSegment.Points.Add(new Point(25, 0));
            pLineFigure.Segments.Add(pLineSegment);
            PathGeometry pGeometry = new PathGeometry();
            pGeometry.Figures.Add(pLineFigure);

            GeometryDrawing drawing2 = new GeometryDrawing(
                    Brushes.Lime,
                    new Pen(Brushes.Black, 10),
                    pGeometry
                );

            //
            // Create a circle.
            //
            GeometryDrawing drawing3 = new GeometryDrawing(
                    Brushes.Lime,
                    new Pen(Brushes.Black, 2),
                    new EllipseGeometry(new Point(10, 10), 5, 5)
                );

            // Create the DrawingGroup and add the
            // geometry drawings.
            DrawingGroup aDrawingGroup = new DrawingGroup();
            aDrawingGroup.Children.Add(drawing1);
            aDrawingGroup.Children.Add(drawing2);
            aDrawingGroup.Children.Add(drawing3);

            //
            // Create an EllipseGeometry and use it to
            // clip the DrawingGroup.
            //
            EllipseGeometry clipGeometry = 
                new EllipseGeometry(new Point(25,50), 25, 50);
            aDrawingGroup.ClipGeometry = clipGeometry;


            // Use an Image control and a DrawingImage to
            // display the drawing.
            DrawingImage aDrawingImage = new DrawingImage(aDrawingGroup);

            // Freeze the DrawingImage for performance benefits.
            aDrawingImage.Freeze();

            Image anImage = new Image();
            anImage.Source = aDrawingImage;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            // Create a border around the images and add it to the
            // page.
            Border imageBorder = new Border();
            imageBorder.BorderBrush = Brushes.Gray;
            imageBorder.BorderThickness = new Thickness(1);
            imageBorder.VerticalAlignment = VerticalAlignment.Top;
            imageBorder.HorizontalAlignment = HorizontalAlignment.Left;
            imageBorder.Margin = new Thickness(20);
            imageBorder.Child = anImage;

            this.Background = Brushes.White;
            this.Margin = new Thickness(20);
            this.Content = imageBorder;

        }
    }
}

// </SnippetDrawingGroupClipGeometryExampleWholePage>
