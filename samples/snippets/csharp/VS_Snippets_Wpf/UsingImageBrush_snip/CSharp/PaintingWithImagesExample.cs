// <SnippetImageBrushExampleWholePage>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Microsoft.Samples.Graphics.UsingImageBrush
{

    public class PaintingWithImagesExample : Page
    {

        public PaintingWithImagesExample()
        {
            Background = Brushes.White;
            StackPanel mainPanel = new StackPanel();
            mainPanel.Margin = new Thickness(20.0);

            // Create a button.
            Button berriesButton = new Button();
            berriesButton.Foreground = Brushes.White;
            berriesButton.FontWeight = FontWeights.Bold;
            FontSizeConverter sizeConverter = new FontSizeConverter();
            berriesButton.FontSize = (Double)sizeConverter.ConvertFromString("16pt");
            berriesButton.FontFamily = new FontFamily("Verdana");
            berriesButton.Content = "Berries";
            berriesButton.Padding = new Thickness(20.0);
            berriesButton.HorizontalAlignment = HorizontalAlignment.Left;

            // Create an ImageBrush.
            ImageBrush berriesBrush = new ImageBrush();
            berriesBrush.ImageSource =
                new BitmapImage(
                    new Uri(@"sampleImages\berries.jpg", UriKind.Relative)
                );

            // Use the brush to paint the button's background.
            berriesButton.Background = berriesBrush;

            mainPanel.Children.Add(berriesButton);
            this.Content = mainPanel;
        }
    }
}

// </SnippetImageBrushExampleWholePage>