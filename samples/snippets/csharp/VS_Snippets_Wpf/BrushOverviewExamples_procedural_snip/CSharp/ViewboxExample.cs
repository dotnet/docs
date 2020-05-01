using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{

    public class ViewboxExample : Page
    {

        public ViewboxExample()
        {

            // Create the main panel.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Horizontal;
            createViewboxExample(mainPanel);
            this.Content = mainPanel;
        }

        private void createViewboxExample(Panel mainPanel)
        {

            Border rectangleBorder = new Border();
            rectangleBorder.BorderBrush = Brushes.Black;
            rectangleBorder.BorderThickness = new Thickness(1);
            rectangleBorder.VerticalAlignment = VerticalAlignment.Top;
            rectangleBorder.Margin = new Thickness(0,0,10,0);

            // <SnippetGraphicsMMTileBrushViewboxWithStretchTiling>
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 100;

            // Load the image.
            BitmapImage theImage =
                new BitmapImage(
                    new Uri("sampleImages\\testImage.gif", UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);

            myImageBrush.Viewbox = new Rect(0.5, 0.25, 0.25, 0.5);
            myImageBrush.ViewboxUnits = BrushMappingMode.RelativeToBoundingBox;
            myImageBrush.Viewport = new Rect(0,0,0.25,0.25);
            myImageBrush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            myImageBrush.TileMode = TileMode.Tile;
            myImageBrush.Stretch = Stretch.Fill;
            myImageBrush.AlignmentX = AlignmentX.Center;
            myImageBrush.AlignmentY = AlignmentY.Center;

            // Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush;
            // </SnippetGraphicsMMTileBrushViewboxWithStretchTiling>

            rectangleBorder.Child = myRectangle;
            mainPanel.Children.Add(rectangleBorder);
        }
    }
}