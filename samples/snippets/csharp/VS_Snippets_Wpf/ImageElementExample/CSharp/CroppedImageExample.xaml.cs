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
   public partial class CroppedImageExample : Page
   {
      public CroppedImageExample()
      {
      }

      private void PageLoaded(object sender, RoutedEventArgs args)
      {
         //<SnippetCroppedCSharp1>
         // Create an Image element.
         Image croppedImage = new Image();
         croppedImage.Width = 200;
         croppedImage.Margin = new Thickness(5);

         // Create a CroppedBitmap based off of a xaml defined resource.
         CroppedBitmap cb = new CroppedBitmap(
            (BitmapSource)this.Resources["masterImage"],
            new Int32Rect(30, 20, 105, 50));       //select region rect
         croppedImage.Source = cb;                 //set image source to cropped
         //</SnippetCroppedCSharp1>

         // Add Image to the UI
         Grid.SetColumn(croppedImage, 1);
         Grid.SetRow(croppedImage, 1);
         croppedGrid.Children.Add(croppedImage);

         //<SnippetCroppedCSharp2>
         // Create an Image element.
         Image chainImage = new Image();
         chainImage.Width = 200;
         chainImage.Margin = new Thickness(5);

         // Create the cropped image based on previous CroppedBitmap.
         CroppedBitmap chained = new CroppedBitmap(cb,
            new Int32Rect(30, 0, (int)cb.Width-30, (int)cb.Height));
         // Set the image's source.
         chainImage.Source = chained;
         //</SnippetCroppedCSharp2>

         // Add Image to the UI.
         Grid.SetColumn(chainImage, 1);
         Grid.SetRow(chainImage, 3);
         croppedGrid.Children.Add(chainImage);
      }
   }
}