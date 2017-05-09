// <SnippetCroppedBitmapCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public partial class CroppedBitmapExample : Page
    {
        public CroppedBitmapExample()
        {

            ///// Create a BitmapImage and set it's DecodePixelWidth to 200. Use  /////
            ///// this BitmapImage as a source for other BitmapSource objects.    /////

            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapSource objects like BitmapImage can only have their properties
            // changed within a BeginInit/EndInit block.
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"sampleImages/WaterLilies.jpg",UriKind.Relative);

            // To save significant application memory, set the DecodePixelWidth or  
            // DecodePixelHeight of the BitmapImage value of the image source to the desired 
            // height or width of the rendered image. If you don't do this, the application will 
            // cache the image as though it were rendered as its normal size rather then just 
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();

            ////////// Crop the BitmapSource ////////////
            // Use the BitmapImage created above as the source for a new BitmapSource object
            // which is cropped.                                               
            // Note: New BitmapSource does not cache. It is always pulled when required.

            CroppedBitmap myCroppedBitmap = new CroppedBitmap();

            // BitmapSource objects like CroppedBitmap can only have their properties
            // changed within a BeginInit/EndInit block.
            myCroppedBitmap.BeginInit();

            // Use the BitmapSource object defined above as the source for this new 
            // BitmapSource (chain the BitmapSource objects together).
            myCroppedBitmap.Source = myBitmapImage;

            // Crop the image to the rectangular area defined below. 
            // The image is cropped to 80 pixels less in width and 60 less 
            // in height then the original source.
            myCroppedBitmap.SourceRect = new Int32Rect(0,0,(int)myBitmapImage.Width-80, (int)myBitmapImage.Height-60);
            myCroppedBitmap.EndInit();

            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 200;
            //set image source
            myImage.Source = myCroppedBitmap;

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myImage);
            this.Content = myStackPanel;
        }
    }
}
// </SnippetCroppedBitmapCodeExampleWholePage>