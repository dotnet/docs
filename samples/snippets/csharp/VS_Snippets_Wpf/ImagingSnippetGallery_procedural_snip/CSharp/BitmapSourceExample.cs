//<SnippetBitmapSourceFullPage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public partial class BitmapSourceExample : Page
    {
        public BitmapSourceExample()
        {
            //<SnippetBitmapSourceCreate>
            // Define parameters used to create the BitmapSource.
            PixelFormat pf = PixelFormats.Bgr32;
            int width = 200;
            int height = 200;
            int rawStride = (width * pf.BitsPerPixel + 7) / 8;
            byte[] rawImage = new byte[rawStride * height];

            // Initialize the image with data.
            Random value = new Random();
            value.NextBytes(rawImage);

            // Create a BitmapSource.
            BitmapSource bitmap = BitmapSource.Create(width, height,
                96, 96, pf, null,
                rawImage, rawStride);

            // Create an image element;
            Image myImage = new Image();
            myImage.Width = 200;
            // Set image source.
            myImage.Source = bitmap;
            //</SnippetBitmapSourceCreate>

            // Add the Image to the UI.
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myImage);
            this.Content = myStackPanel;
        }
    }
}
//</SnippetBitmapSourceFullPage>
