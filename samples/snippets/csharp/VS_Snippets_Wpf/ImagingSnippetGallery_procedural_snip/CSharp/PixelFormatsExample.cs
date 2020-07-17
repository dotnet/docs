using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace SDKSample
{
    public partial class PixelFormatsExample : Page
    {
        public PixelFormatsExample()
        {
			//<SnippetPixelFormatConversion>

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

            ////////// Convert the BitmapSource to a new format ////////////
            // Use the BitmapImage created above as the source for a new BitmapSource object
            // which is set to a gray scale format using the FormatConvertedBitmap BitmapSource.
            // Note: New BitmapSource does not cache. It is always pulled when required.

            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();

            // BitmapSource objects like FormatConvertedBitmap can only have their properties
            // changed within a BeginInit/EndInit block.
            newFormatedBitmapSource.BeginInit();

            // Use the BitmapSource object defined above as the source for this new
            // BitmapSource (chain the BitmapSource objects together).
            newFormatedBitmapSource.Source = myBitmapImage;

            // Set the new format to Gray32Float (grayscale).
            newFormatedBitmapSource.DestinationFormat = createPixelFormat();
            newFormatedBitmapSource.EndInit();
			//</SnippetPixelFormatConversion>

            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 200;
            //set image source
            myImage.Source = newFormatedBitmapSource;

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myImage);

            // Add TextBox
            // TextBlock myTextBlock = new TextBlock();
            // myTextBlock.Text = "Mask Value: " + stringOfValues + " bpp: " + bpp.ToString();
            // myStackPanel.Children.Add(myTextBlock);
            this.Content = myStackPanel;
        }
        // <SnippetPixelFormatExample1>
        public PixelFormat createPixelFormat()
        {
            // Create a PixelFormat object.
            PixelFormat myPixelFormat = new PixelFormat();

            // Make this PixelFormat a Gray32Float pixel format.
            myPixelFormat = PixelFormats.Gray32Float;

            // Get the number of bits-per-pixel for this format. Because
            // the format is "Gray32Float", the float value returned will be 32.
            int bpp = myPixelFormat.BitsPerPixel;

            // Get the collection of masks associated with this format.
            IList<PixelFormatChannelMask> myChannelMaskCollection = myPixelFormat.Masks;

            // Capture the mask info in a string.
            String stringOfValues = " ";
            foreach (PixelFormatChannelMask myMask in myChannelMaskCollection)
            {
                IList<byte> myBytesCollection = myMask.Mask;
                foreach (byte myByte in myBytesCollection)
                {
                    stringOfValues = stringOfValues + myByte.ToString();
                }
            }

            // Return the PixelFormat which, for example, could be
            // used to set the pixel format of a bitmap by using it to set
            // the DestinationFormat of a FormatConvertedBitmap.
            return myPixelFormat;
        }
        // </SnippetPixelFormatExample1>
    }
}
