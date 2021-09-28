//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageElementExample
{
   public partial class ImageSimpleExample : Page
   {
       public ImageSimpleExample()
      {
      }

       private void PageLoaded(object sender, RoutedEventArgs args)
      {
          //<SnippetImageSimpleExampleInlineCode1>
          // Create Image Element
          Image myImage = new Image();
          myImage.Width = 200;

          // Create source
          BitmapImage myBitmapImage = new BitmapImage();

          // BitmapImage.UriSource must be in a BeginInit/EndInit block
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
          //set image source
          myImage.Source = myBitmapImage;
          //</SnippetImageSimpleExampleInlineCode1>

          // Add Image to the UI
          myStackPanel.Children.Add(myImage);

///////////////////////// Next Snippet //////////////////////
          //<SnippetImageSimpleExampleInlineCode2>
          Image myImage1 = new Image();

          // Set the stretch property.
          myImage1.Stretch = Stretch.Fill;

          // Set the StretchDirection property.
          myImage1.StretchDirection = StretchDirection.Both;

          // Create source
          BitmapImage myBitmapImage1 = new BitmapImage();

          // BitmapImage.UriSource must be in a BeginInit/EndInit block
          myBitmapImage1.BeginInit();
          myBitmapImage1.UriSource = new Uri(@"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Winter.jpg");
          myBitmapImage1.EndInit();

          //set image source
          myImage1.Source = myBitmapImage1;
          //</SnippetImageSimpleExampleInlineCode2>

          // Add Image to the UI
          myStackPanel.Children.Add(myImage1);
      }
   }
}