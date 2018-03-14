// <SnippetChainedBitmapSourcesCodeExampleWholePage>
//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace SDKSample
{
    public partial class ChainedBitmapSourcesExample : Page
    {
        public ChainedBitmapSourcesExample()
        {
            ///// Create a BitmapImage and set it's DecodePixelWidth to 200. Use  /////
            ///// this BitmapImage as a source for other BitmapSource objects.    /////

            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapSource objects like BitmapImage can only have their properties
            // changed within a BeginInit/EndInit block.
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri("sampleImages/WaterLilies.jpg",UriKind.Relative);

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

            // Create the new BitmapSource that will be used to scale the size of the source.
            TransformedBitmap myRotatedBitmapSource = new TransformedBitmap();

            // BitmapSource objects like TransformedBitmap can only have their properties
            // changed within a BeginInit/EndInit block.
            myRotatedBitmapSource.BeginInit();

            // Use the BitmapSource object defined above as the source for this BitmapSource.
            // This creates a "chain" of BitmapSource objects which essentially inherit from each other.
            myRotatedBitmapSource.Source = myBitmapImage;
            // Multiply the size of the X and Y axis of the source by 3.
            myRotatedBitmapSource.Transform = new RotateTransform(90);
            myRotatedBitmapSource.EndInit();

            // Create a new BitmapSource using a different format than the original one.
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();

            // BitmapSource objects like FormatConvertedBitmap can only have their properties
            // changed within a BeginInit/EndInit block.
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = myRotatedBitmapSource;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            newFormatedBitmapSource.EndInit();

            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 200;
            //set image source
            myImage.Source = newFormatedBitmapSource;

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myImage);
            this.Content = myStackPanel;
        }

        public void PageLoaded(object sender, RoutedEventArgs args)
        {


        }

    }
}
// </SnippetChainedBitmapSourcesCodeExampleWholePage>