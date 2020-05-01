using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{

    public class AlignmentExample : Page
    {

        public AlignmentExample()
        {

            // Create the main panel.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Horizontal;
            createTopLeftAlignmentExample(mainPanel);
            this.Content = mainPanel;
        }

        private void createTopLeftAlignmentExample(Panel mainPanel)
        {

            // <SnippetGraphicsMMTopLeftAlignmentExample>
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 150;
            myRectangle.Height = 150;
            myRectangle.Stroke = Brushes.LimeGreen;
            myRectangle.StrokeThickness = 1;
            myRectangle.Margin = new Thickness(0,5,0,0);

            // Load the image.
            BitmapImage theImage =
                new BitmapImage(
                    new Uri("sampleImages\\triangle.jpg", UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);

            // Configure the brush so that it
            // doesn't stretch its image to fill
            // the rectangle.
            myImageBrush.Stretch = Stretch.None;

            // Align the tile to the rectangle's
            // top left corner.
            myImageBrush.AlignmentX = AlignmentX.Left;
            myImageBrush.AlignmentY = AlignmentY.Top;

            // Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush;
            // </SnippetGraphicsMMTopLeftAlignmentExample>

            mainPanel.Children.Add(myRectangle);
        }
    }
}