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
   public partial class TransformedImageExample : Page
   {
      public TransformedImageExample()
      {
      }

      private void PageLoaded(object sender, RoutedEventArgs args)
      {
         //<SnippetTransformedCSharp1>
         //Create Image element
         Image rotated270 = new Image();
         rotated270.Width = 150;

         //Create source
         BitmapImage bi = new BitmapImage();
         //BitmapImage properties must be in a BeginInit/EndInit block
         bi.BeginInit();
         bi.UriSource = new Uri(@"pack://application:,,/sampleImages/watermelon.jpg");
         //Set image rotation
         bi.Rotation = Rotation.Rotate270;
         bi.EndInit();
         //set image source
         rotated270.Source = bi;
         //</SnippetTransformedCSharp1>

         //Add Image to the UI
         Grid.SetColumn(rotated270, 1);
         Grid.SetRow(rotated270, 1);
         transformedGrid.Children.Add(rotated270);
      }
   }
}