// <SnippetImageDrawingWithDrawingBrushExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public class ImageDrawingWithDrawingBrushExample : Page
    {
        public ImageDrawingWithDrawingBrushExample()
        {
            // Create a DrawingGroup to combine the ImageDrawing objects.
            DrawingGroup imageDrawings = new DrawingGroup();

            // Create a 100 by 100 image with an upper-left point of (75,75).
            ImageDrawing bigKiwi = new ImageDrawing();
            bigKiwi.Rect = new Rect(75, 75, 100, 100);
            bigKiwi.ImageSource = new BitmapImage(
                new Uri(@"sampleImages\kiwi.png", UriKind.Relative));

            imageDrawings.Children.Add(bigKiwi);

            // Create a 25 by 25 image with an upper-left point of (0,150).
            ImageDrawing smallKiwi1 = new ImageDrawing();
            smallKiwi1.Rect = new Rect(0, 150, 25, 25);
            smallKiwi1.ImageSource = new BitmapImage(new Uri(@"sampleImages\kiwi.png", UriKind.Relative));
            imageDrawings.Children.Add(smallKiwi1);

            // Create a 25 by 25 image with an upper-left point of (150,0).
            ImageDrawing smallKiwi2 = new ImageDrawing();
            smallKiwi2.Rect = new Rect(150, 0, 25, 25);
            smallKiwi2.ImageSource = new BitmapImage(new Uri(@"sampleImages\kiwi.png", UriKind.Relative));
            imageDrawings.Children.Add(smallKiwi2);

            // Create a 75 by 75 image with an upper-left point of (0,0).
            ImageDrawing wholeKiwi = new ImageDrawing();
            wholeKiwi.Rect = new Rect(0, 0, 75, 75);
            wholeKiwi.ImageSource = new BitmapImage(new Uri(@"sampleImages\wholekiwi.png", UriKind.Relative));
            imageDrawings.Children.Add(wholeKiwi);

            //
            // Use a DrawingBrush to paint a rectangle with
            // the drawings.
            //
            DrawingBrush dBrush = new DrawingBrush(imageDrawings);
            dBrush.Viewport = new Rect(0, 0, 0.5, 0.5);
            dBrush.TileMode = TileMode.Tile;
            dBrush.Freeze();

            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 175;
            exampleRectangle.Height = 175;
            exampleRectangle.Fill = dBrush;

            // Create a border to contain the rectangle.
            Border exampleBorder = new Border();
            exampleBorder.BorderBrush = Brushes.Gray;
            exampleBorder.BorderThickness = new Thickness(1);
            exampleBorder.HorizontalAlignment = HorizontalAlignment.Left;
            exampleBorder.VerticalAlignment = VerticalAlignment.Top;
            exampleBorder.Margin = new Thickness(20);
            exampleBorder.Child = exampleRectangle;

            this.Background = Brushes.White;
            this.Margin = new Thickness(20);
            this.Content = exampleBorder;
        }
    }
}
// </SnippetImageDrawingWithDrawingBrushExample>
