using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{

    public class TilingExample : Page
    {

        public TilingExample()
        {

            // Create the main panel.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Horizontal;
            createTilingExample(mainPanel);
            this.Content = mainPanel;
        }

        private void createTilingExample(Panel mainPanel)
        {

            Border rectangleBorder = new Border();
            rectangleBorder.BorderBrush = Brushes.Black;
            rectangleBorder.BorderThickness = new Thickness(1);
            rectangleBorder.VerticalAlignment = VerticalAlignment.Top;
            rectangleBorder.Margin = new Thickness(0,0,10,0);

            // <SnippetGraphicsMMFlipXYExample>
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 100;

            // Load the image.
            BitmapImage theImage =
                new BitmapImage(
                    new Uri("sampleImages\\triangle.jpg", UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);

            // Create tiles that are 1/4 the size of
            // the output area.
            myImageBrush.Viewport = new Rect(0,0,0.25,0.25);

            // Set the tile mode to FlipXY.
            myImageBrush.TileMode = TileMode.FlipXY;

            // Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush;
            // </SnippetGraphicsMMFlipXYExample>

            rectangleBorder.Child = myRectangle;
            mainPanel.Children.Add(rectangleBorder);
        }
    }
}