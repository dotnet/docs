// <SnippetImageDrawingExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public class ImageDrawingExample : Page
    {
        public ImageDrawingExample()
        {
            // Create a DrawingGroup to combine the ImageDrawing objects.
            DrawingGroup imageDrawings = new DrawingGroup();

            // <SnippetImageDrawing100by100Inline> 
            // Create a 100 by 100 image with an upper-left point of (75,75). 
            ImageDrawing bigKiwi = new ImageDrawing();
            bigKiwi.Rect = new Rect(75, 75, 100, 100);
            bigKiwi.ImageSource = new BitmapImage(
                new Uri(@"sampleImages\kiwi.png", UriKind.Relative));
            // </SnippetImageDrawing100by100Inline> 
            
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
            // Use a DrawingImage and an Image control to
            // display the drawings.
            //
            DrawingImage drawingImageSource = new DrawingImage(imageDrawings);
            
            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();

            Image imageControl = new Image();
            imageControl.Stretch = Stretch.None;
            imageControl.Source = drawingImageSource;

            // Create a border to contain the Image control.
            Border imageBorder = new Border();
            imageBorder.BorderBrush = Brushes.Gray;
            imageBorder.BorderThickness = new Thickness(1);
            imageBorder.HorizontalAlignment = HorizontalAlignment.Left;
            imageBorder.VerticalAlignment = VerticalAlignment.Top;
            imageBorder.Margin = new Thickness(20);
            imageBorder.Child = imageControl;

            this.Background = Brushes.White;
            this.Margin = new Thickness(20);
            this.Content = imageBorder;
        }

    }
}
// </SnippetImageDrawingExample>

