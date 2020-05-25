using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{

    public class StretchExample : Page
    {

        public StretchExample()
        {

            // Create the main panel.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Horizontal;
            createNoStretchExample(mainPanel);
            this.Content = mainPanel;
        }

        private void createNoStretchExample(Panel mainPanel)
        {

            // <SnippetGraphicsMMNoStretchExample>
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 125;
            myRectangle.Height = 175;
            myRectangle.Stroke = Brushes.Black;
            myRectangle.StrokeThickness = 1;
            myRectangle.Margin = new Thickness(0,5,0,0);

            // Load the image.
            BitmapImage theImage =
                new BitmapImage(
                    new Uri("sampleImages\\testImage.gif", UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);

            // Configure the brush so that it
            // doesn't stretch its image to fill
            // the rectangle.
            myImageBrush.Stretch = Stretch.None;

            // Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush;
            // </SnippetGraphicsMMNoStretchExample>

            mainPanel.Children.Add(myRectangle);
        }
    }
}