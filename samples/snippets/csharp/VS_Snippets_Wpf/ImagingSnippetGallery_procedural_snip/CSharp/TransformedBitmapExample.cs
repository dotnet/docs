// <SnippetTransformedBitmapCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public partial class TransformedBitmapExample : Page
    {
        public TransformedBitmapExample()
        {
			//<SnippetTransformedBitmapInline1>
            ///// Create a BitmapImage and set it's DecodePixelWidth to 200. Use  /////
            ///// this BitmapImage as a source for other BitmapSource objects.    /////

            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapSource objects like BitmapImage can only have their properties
            // changed within a BeginInit/EndInit block.
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Water Lilies.jpg");

            // To save significant application memory, set the DecodePixelWidth or
            // DecodePixelHeight of the BitmapImage value of the image source to the desired
            // height or width of the rendered image. If you don't do this, the application will
            // cache the image as though it were rendered as its normal size rather then just
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();

            /////////////////// Create a BitmapSource that Rotates the image //////////////////////
            // Use the BitmapImage created above as the source for a new BitmapSource object
            // that will be scaled to a different size. Create a new BitmapSource by
            // scaling the original one.
            // Note: New BitmapSource does not cache. It is always pulled when required.

            //<SnippetTransformedBitmapPropInit>
            // Create the new BitmapSource that will be used to scale the size of the source.
            TransformedBitmap myRotatedBitmapSource = new TransformedBitmap();

            // BitmapSource objects like TransformedBitmap can only have their properties
            // changed within a BeginInit/EndInit block.
            myRotatedBitmapSource.BeginInit();

            // Use the BitmapSource object defined above as the source for this BitmapSource.
            // This creates a "chain" of BitmapSource objects which essentially inherit from each other.
            myRotatedBitmapSource.Source = myBitmapImage;

            // Flip the source 90 degrees.
            myRotatedBitmapSource.Transform = new RotateTransform(90);
            myRotatedBitmapSource.EndInit();
            //</SnippetTransformedBitmapPropInit>
			//</SnippetTransformedBitmapInline1>

            // Create Image element
            Image myImage = new Image();
            myImage.Width = 200;

            //set image source
            myImage.Source = myRotatedBitmapSource;

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myImage);
            this.Content = myStackPanel;
        }
    }
}
// </SnippetTransformedBitmapCodeExampleWholePage>