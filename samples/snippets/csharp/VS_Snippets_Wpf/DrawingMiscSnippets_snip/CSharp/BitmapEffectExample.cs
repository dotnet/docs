// <SnippetDrawingGroupBitmapEffectExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;

namespace SDKSample 
{

    /// <summary>
    /// This example creates two DrawingGroup objects,
    /// one with a bitmap effect and one without.
    /// </summary>
	public class BitmapEffectExample : Page
	{
        public BitmapEffectExample()
        {

            //
            // Create a DrawingGroup
            // that has no BitmapEffect
            //
            PathFigure pLineFigure = new PathFigure();
            pLineFigure.StartPoint = new Point(25, 25);
            PolyLineSegment pLineSegment = new PolyLineSegment();
            pLineSegment.Points.Add(new Point(0,50));
            pLineSegment.Points.Add(new Point(25, 75));
            pLineSegment.Points.Add(new Point(50, 50));
            pLineSegment.Points.Add(new Point(25, 25));
            pLineSegment.Points.Add(new Point(25, 0));
            pLineFigure.Segments.Add(pLineSegment);
            PathGeometry pGeometry = new PathGeometry();
            pGeometry.Figures.Add(pLineFigure);
          
            GeometryDrawing drawing1 = new GeometryDrawing(
                    Brushes.Lime, 
                    new Pen(Brushes.Black, 10),
                    pGeometry
                );

            GeometryDrawing drawing2 = new GeometryDrawing(
                    Brushes.Lime,
                    new Pen(Brushes.Black, 2),
                    new EllipseGeometry(new Point(10,10), 5, 5)
                );
            
            // Create a DrawingGroup
            DrawingGroup drawingGroupWithoutBitmapEffect = new DrawingGroup();
            drawingGroupWithoutBitmapEffect.Children.Add(drawing1);
            drawingGroupWithoutBitmapEffect.Children.Add(drawing2);

            // Use an Image control and a DrawingImage to
            // display the drawing.
            DrawingImage drawingImage01 = new DrawingImage(drawingGroupWithoutBitmapEffect);
            
            // Freeze the DrawingImage for performance benefits.
            drawingImage01.Freeze();

            Image image01 = new Image();
            image01.Source = drawingImage01;
            image01.Stretch = Stretch.None;
            image01.HorizontalAlignment = HorizontalAlignment.Left;

            //
            // Create another DrawingGroup and apply 
            // a blur effect to it.
            //

            // Create a clone of the first DrawingGroup.
            DrawingGroup drawingGroupWithBitmapEffect = 
                drawingGroupWithoutBitmapEffect.Clone();

            // Create a blur effect.
            BlurBitmapEffect blurEffect = new BlurBitmapEffect();
            blurEffect.Radius = 3.0;

            // Apply it to the drawing group.
            drawingGroupWithBitmapEffect.BitmapEffect = blurEffect;

            // Use another Image control and DrawingImage
            // to display the drawing.
            DrawingImage drawingImage02 = new DrawingImage(drawingGroupWithBitmapEffect);
            
            // Freeze the DrawingImage for performance benefits.
            drawingImage02.Freeze();

            Image image02 = new Image();
            image02.Source = drawingImage02;
            image02.Stretch = Stretch.None;
            image02.HorizontalAlignment = HorizontalAlignment.Left;

            // Create borders around the images and add them to the
            // page.
            Border border01 = new Border();
            border01.BorderBrush = Brushes.Gray;
            border01.BorderThickness = new Thickness(1);
            border01.VerticalAlignment = VerticalAlignment.Top;
            border01.Margin = new Thickness(10);
            border01.Child = image01;

            Border border02 = new Border();
            border02.BorderBrush = Brushes.Gray;
            border02.BorderThickness = new Thickness(1);
            border02.VerticalAlignment = VerticalAlignment.Top;
            border02.Margin = new Thickness(50,10,10,10);
            border02.Child = image02;

            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Horizontal;
            mainPanel.HorizontalAlignment = HorizontalAlignment.Left;
            mainPanel.VerticalAlignment = VerticalAlignment.Top;
            mainPanel.Children.Add(border01);
            mainPanel.Children.Add(border02);

            //
            // Use a DrawingBrush to create a checkered background for the page.
            //
            GeometryDrawing backgroundSquareDrawing = 
                new GeometryDrawing(
                    Brushes.White,
                    null,
                    new RectangleGeometry(new Rect(0,0,1,1)));
            GeometryGroup twoRectangles = new GeometryGroup();
            twoRectangles.Children.Add(new RectangleGeometry(new Rect(0,0,0.5,0.5)));
            twoRectangles.Children.Add(new RectangleGeometry(new Rect(0.5,0.5,0.5,0.5)));
            SolidColorBrush squaresBrush = 
                new SolidColorBrush(Color.FromArgb(102,204,204,204));
            squaresBrush.Opacity = 0.4;
            GeometryDrawing checkerDrawing = 
                new GeometryDrawing(
                    squaresBrush,
                    null,
                    twoRectangles);
            DrawingGroup checkerDrawings = new DrawingGroup();
            checkerDrawings.Children.Add(backgroundSquareDrawing);
            checkerDrawings.Children.Add(checkerDrawing);
            DrawingBrush checkerBrush = new DrawingBrush(checkerDrawings);
            checkerBrush.Viewport = new Rect(0,0,10,10);
            checkerBrush.ViewportUnits = BrushMappingMode.Absolute;
            checkerBrush.TileMode = TileMode.Tile;
            checkerBrush.Freeze();

            this.Background = checkerBrush;
            this.Content = mainPanel;

        }

	}
}
// </SnippetDrawingGroupBitmapEffectExampleWholePage>
