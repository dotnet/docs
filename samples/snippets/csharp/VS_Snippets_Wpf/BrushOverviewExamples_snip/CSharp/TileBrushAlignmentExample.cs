using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.BrushExamples
{
    public class TileBrushAlignmentExample : Page
    {

        public TileBrushAlignmentExample()
        {
            // <SnippetTileBrushTopLeftAlignmentInline>
            //
            // Create a TileBrush and align its
            // content to the top-left of its tile.
            //
            DrawingBrush topLeftAlignedTileBrush = new DrawingBrush();
            topLeftAlignedTileBrush.AlignmentX = AlignmentX.Left;
            topLeftAlignedTileBrush.AlignmentY = AlignmentY.Top;

            // Set Stretch to None so that the brush's
            // content doesn't automatically expand to
            // fill the entire tile.
            topLeftAlignedTileBrush.Stretch = Stretch.None;

            // Define the brush's content.
            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(new EllipseGeometry(new Point(50, 50), 20, 45));
            ellipses.Children.Add(new EllipseGeometry(new Point(50, 50), 45, 20));
            Pen drawingPen = new Pen(Brushes.Gray, 10);
            GeometryDrawing ellipseDrawing = new GeometryDrawing(Brushes.Blue, drawingPen, ellipses);
            topLeftAlignedTileBrush.Drawing = ellipseDrawing;

            // Use the brush to paint a rectangle.
            Rectangle rectangle1 = new Rectangle();
            rectangle1.Width = 150;
            rectangle1.Height = 150;
            rectangle1.Stroke = Brushes.Red;
            rectangle1.StrokeThickness = 2;
            rectangle1.Margin = new Thickness(20);
            rectangle1.Fill = topLeftAlignedTileBrush;

            // </SnippetTileBrushTopLeftAlignmentInline>

            // <SnippetTileBrushBottomRightAlignmentInline>
            //
            // Create a TileBrush and align its
            // content to the bottom-right of its tile.
            //
            DrawingBrush bottomRightAlignedTileBrush = new DrawingBrush();
            bottomRightAlignedTileBrush.AlignmentX = AlignmentX.Right;
            bottomRightAlignedTileBrush.AlignmentY = AlignmentY.Bottom;
            bottomRightAlignedTileBrush.Stretch = Stretch.None;

            // Define the brush's content.
            bottomRightAlignedTileBrush.Drawing = ellipseDrawing;

            // Use the brush to paint a rectangle.
            Rectangle rectangle2 = new Rectangle();
            rectangle2.Width = 150;
            rectangle2.Height = 150;
            rectangle2.Stroke = Brushes.Red;
            rectangle2.StrokeThickness = 2;
            rectangle2.Margin = new Thickness(20);
            rectangle2.Fill = bottomRightAlignedTileBrush;

            // </SnippetTileBrushBottomRightAlignmentInline>

            // <SnippetTileBrushTopLeftAlignmentTiledInline>
            //
            // Create a TileBrush that generates a
            // tiled pattern and align its
            // content to the top-left of its tile.
            //
            DrawingBrush tiledTopLeftAlignedTileBrush = new DrawingBrush();
            tiledTopLeftAlignedTileBrush.AlignmentX = AlignmentX.Left;
            tiledTopLeftAlignedTileBrush.AlignmentY = AlignmentY.Top;
            tiledTopLeftAlignedTileBrush.Stretch = Stretch.Uniform;

            // Set the brush's Viewport and TileMode to produce a
            // tiled pattern.
            tiledTopLeftAlignedTileBrush.Viewport = new Rect(0, 0, 0.25, 0.5);
            tiledTopLeftAlignedTileBrush.TileMode = TileMode.Tile;

            // Define the brush's content.
            tiledTopLeftAlignedTileBrush.Drawing = ellipseDrawing;

            // Use the brush to paint a rectangle.
            Rectangle rectangle3 = new Rectangle();
            rectangle3.Width = 150;
            rectangle3.Height = 150;
            rectangle3.Stroke = Brushes.Black;
            rectangle3.StrokeThickness = 2;
            rectangle3.Margin = new Thickness(20);
            rectangle3.Fill = tiledTopLeftAlignedTileBrush;

            // </SnippetTileBrushTopLeftAlignmentTiledInline>

            // <SnippetTileBrushBottomRightAlignmentTiledInline>
            //
            // Create a TileBrush that generates a
            // tiled pattern and align its
            // content to the bottom-right of its tile.
            //
            DrawingBrush tiledBottomRightAlignedTileBrush = new DrawingBrush();
            tiledBottomRightAlignedTileBrush.AlignmentX = AlignmentX.Right;
            tiledBottomRightAlignedTileBrush.AlignmentY = AlignmentY.Bottom;
            tiledBottomRightAlignedTileBrush.Stretch = Stretch.Uniform;

            // Set the brush's Viewport and TileMode to produce a
            // tiled pattern.
            tiledBottomRightAlignedTileBrush.Viewport = new Rect(0, 0, 0.25, 0.5);
            tiledBottomRightAlignedTileBrush.TileMode = TileMode.Tile;

            // Define the brush's content.
            tiledBottomRightAlignedTileBrush.Drawing = ellipseDrawing;

            // Use the brush to paint a rectangle.
            Rectangle rectangle4 = new Rectangle();
            rectangle4.Width = 150;
            rectangle4.Height = 150;
            rectangle4.Stroke = Brushes.Black;
            rectangle4.StrokeThickness = 2;
            rectangle4.Margin = new Thickness(20);
            rectangle4.Fill = tiledBottomRightAlignedTileBrush;

            // </SnippetTileBrushBottomRightAlignmentTiledInline>

            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(rectangle1);
            mainPanel.Children.Add(rectangle2);
            mainPanel.Children.Add(rectangle3);
            mainPanel.Children.Add(rectangle4);
            Content = mainPanel;
            Background = Brushes.White;
            Margin = new Thickness(20);
            Title = "Alignment Example";
        }
    }
}
