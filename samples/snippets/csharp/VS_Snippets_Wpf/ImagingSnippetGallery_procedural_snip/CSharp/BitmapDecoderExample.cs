//<SnippetBitmapDecoderFullPage>
using System;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SDKSample
{
   public partial class BitmapDecoderExample : Page
   {
      public BitmapDecoderExample()
      {
         //<SnippetBitmapDecoderCreate>
         BitmapDecoder uriBitmap = BitmapDecoder.Create(
            new Uri("sampleImages/waterlilies.jpg", UriKind.Relative),
            BitmapCreateOptions.None,
            BitmapCacheOption.Default);

         // Create an image element;
         Image uriImage = new Image();
         uriImage.Width = 200;
         // Set image source.
         uriImage.Source = uriBitmap.Frames[0];
         //</SnippetBitmapDecoderCreate>

         //<SnippetBitmapDecoderCreateStream>
         Stream imageStream = new FileStream("sampleImages/waterlilies.jpg",
            FileMode.Open, FileAccess.Read, FileShare.Read);

         BitmapDecoder streamBitmap = BitmapDecoder.Create(
            imageStream, BitmapCreateOptions.None,
            BitmapCacheOption.Default);

         // Create an image element;
         Image streamImage = new Image();
         streamImage.Width = 200;
         // Set image source using the first frame.
         streamImage.Source = streamBitmap.Frames[0];
         //</SnippetBitmapDecoderCreateStream>

         // Add the Image to the UI.
         StackPanel myStackPanel = new StackPanel();
         myStackPanel.Children.Add(uriImage);
         myStackPanel.Children.Add(streamImage);
         this.Content = myStackPanel;
      }
   }
}
//</SnippetBitmapDecoderFullPage>
