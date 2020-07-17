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
   public partial class SimpleImageExample : Page
   {
      public SimpleImageExample()
      {
      }

      private void PageLoaded(object sender, RoutedEventArgs args)
      {
         //<SnippetSimpleCSharp1>
         // Create the image element.
         Image simpleImage = new Image();
         simpleImage.Width = 200;
         simpleImage.Margin = new Thickness(5);

         // Create source.
         BitmapImage bi = new BitmapImage();
         // BitmapImage.UriSource must be in a BeginInit/EndInit block.
         bi.BeginInit();
         bi.UriSource = new Uri(@"/sampleImages/cherries_larger.jpg",UriKind.RelativeOrAbsolute);
         bi.EndInit();
         // Set the image source.
         simpleImage.Source = bi;
         //</SnippetSimpleCSharp1>

         //Add Image to the UI
         Grid.SetColumn(simpleImage, 2);
         Grid.SetRow(simpleImage, 1);
         simpleGrid.Children.Add(simpleImage);
      }
   }
}