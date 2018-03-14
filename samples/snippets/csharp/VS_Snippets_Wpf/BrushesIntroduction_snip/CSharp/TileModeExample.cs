// <SnippetGraphicsMMDrawingBrushTileModeExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BrushesIntroduction
{
    public class TileModeExample : Page
    {

        public TileModeExample()
        {
            Background = Brushes.White;
            Margin = new Thickness(20);
            StackPanel mainPanel = new StackPanel();
            mainPanel.HorizontalAlignment = HorizontalAlignment.Left;

            //
            // Create a Drawing. This will be the DrawingBrushes' content.
            //
            PolyLineSegment triangleLinesSegment = new PolyLineSegment();
            triangleLinesSegment.Points.Add(new Point(50, 0));
            triangleLinesSegment.Points.Add(new Point(0, 50));
            PathFigure triangleFigure = new PathFigure();
            triangleFigure.IsClosed = true;
            triangleFigure.StartPoint = new Point(0, 0);
            triangleFigure.Segments.Add(triangleLinesSegment);
            PathGeometry triangleGeometry = new PathGeometry();
            triangleGeometry.Figures.Add(triangleFigure);

            GeometryDrawing triangleDrawing = new GeometryDrawing();
            triangleDrawing.Geometry = triangleGeometry;
            triangleDrawing.Brush = new SolidColorBrush(Color.FromArgb(255, 204, 204, 255));
            Pen trianglePen = new Pen(Brushes.Black, 2);
            triangleDrawing.Pen = trianglePen;
            trianglePen.MiterLimit = 0;
            triangleDrawing.Freeze();

            //
            // Create the first TileBrush. Its content is not tiled.
            //
            DrawingBrush tileBrushWithoutTiling = new DrawingBrush();
            tileBrushWithoutTiling.Drawing = triangleDrawing;
            tileBrushWithoutTiling.TileMode = TileMode.None;
            
            // Create a rectangle and paint it with the DrawingBrush.
            Rectangle noTileExampleRectangle = createExampleRectangle();
            noTileExampleRectangle.Fill = tileBrushWithoutTiling;

            // Add a header and the rectangle to the main panel.
            mainPanel.Children.Add(createExampleHeader("None"));
            mainPanel.Children.Add(noTileExampleRectangle);

            //
            // Create another TileBrush, this time with tiling.
            //
            DrawingBrush tileBrushWithTiling = new DrawingBrush();
            tileBrushWithTiling.Drawing = triangleDrawing;
            tileBrushWithTiling.TileMode = TileMode.Tile;

            // Specify the brush's Viewport. Otherwise,
            // a single tile will be produced that fills
            // the entire output area and its TileMode will
            // have no effect.
            // This setting uses realtive values to
            // creates four tiles. 
            tileBrushWithTiling.Viewport = new Rect(0, 0, 0.5, 0.5);

            // Create a rectangle and paint it with the DrawingBrush.
            Rectangle tilingExampleRectangle = createExampleRectangle();
            tilingExampleRectangle.Fill = tileBrushWithTiling;
            mainPanel.Children.Add(createExampleHeader("Tile"));
            mainPanel.Children.Add(tilingExampleRectangle);

            //
            // Create a TileBrush with FlipX tiling.
            // The brush's content is flipped horizontally as it is
            // tiled in this example
            //
            DrawingBrush tileBrushWithFlipXTiling = new DrawingBrush();
            tileBrushWithFlipXTiling.Drawing = triangleDrawing;
            tileBrushWithFlipXTiling.TileMode = TileMode.FlipX;

            // Specify the brush's Viewport.
            tileBrushWithFlipXTiling.Viewport = new Rect(0, 0, 0.5, 0.5);

            // Create a rectangle and paint it with the DrawingBrush.
            Rectangle flipXTilingExampleRectangle = createExampleRectangle();
            flipXTilingExampleRectangle.Fill = tileBrushWithFlipXTiling;
            mainPanel.Children.Add(createExampleHeader("FlipX"));
            mainPanel.Children.Add(flipXTilingExampleRectangle);

            //
            // Create a TileBrush with FlipY tiling.
            // The brush's content is flipped vertically as it is
            // tiled in this example
            //
            DrawingBrush tileBrushWithFlipYTiling = new DrawingBrush();
            tileBrushWithFlipYTiling.Drawing = triangleDrawing;
            tileBrushWithFlipYTiling.TileMode = TileMode.FlipX;

            // Specify the brush's Viewport.
            tileBrushWithFlipYTiling.Viewport = new Rect(0, 0, 0.5, 0.5);

            // Create a rectangle and paint it with the DrawingBrush.
            Rectangle flipYTilingExampleRectangle = createExampleRectangle();
            flipYTilingExampleRectangle.Fill = tileBrushWithFlipYTiling;
            mainPanel.Children.Add(createExampleHeader("FlipY"));
            mainPanel.Children.Add(flipYTilingExampleRectangle);

            //
            // Create a TileBrush with FlipXY tiling.
            // The brush's content is flipped vertically as it is
            // tiled in this example
            //
            DrawingBrush tileBrushWithFlipXYTiling = new DrawingBrush();
            tileBrushWithFlipXYTiling.Drawing = triangleDrawing;
            tileBrushWithFlipXYTiling.TileMode = TileMode.FlipXY;

            // Specify the brush's Viewport.
            tileBrushWithFlipXYTiling.Viewport = new Rect(0, 0, 0.5, 0.5);

            // Create a rectangle and paint it with the DrawingBrush.
            Rectangle flipXYTilingExampleRectangle = createExampleRectangle();
            flipXYTilingExampleRectangle.Fill = tileBrushWithFlipXYTiling;
            mainPanel.Children.Add(createExampleHeader("FlipXY"));
            mainPanel.Children.Add(flipXYTilingExampleRectangle);

            Content = mainPanel;
        }

        //
        // Helper method that creates rectangle elements.
        //
        private static Rectangle createExampleRectangle()
        {
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 50;
            exampleRectangle.Height = 50;
            exampleRectangle.Stroke = Brushes.Black;
            exampleRectangle.StrokeThickness = 1;
            return exampleRectangle;
        }

        //
        // Helper method that creates headers for the examples. 
        //
        private static TextBlock createExampleHeader(String text)
        {
            TextBlock header = new TextBlock();
            header.Margin = new Thickness(0, 10, 0, 0);
            header.Text = text;
            return header;
        }
    }
}
// </SnippetGraphicsMMDrawingBrushTileModeExample>

