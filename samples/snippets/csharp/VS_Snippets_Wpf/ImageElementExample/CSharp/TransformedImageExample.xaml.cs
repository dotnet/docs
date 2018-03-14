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
         // Create Image element.
         Image rotated90 = new Image();
         rotated90.Width = 150;

         // Create the TransformedBitmap to use as the Image source.
         TransformedBitmap tb = new TransformedBitmap();

         // Create the source to use as the tb source.
         BitmapImage bi = new BitmapImage();
         bi.BeginInit();
         bi.UriSource = new Uri(@"sampleImages/watermelon.jpg", UriKind.RelativeOrAbsolute);
         bi.EndInit();

         // Properties must be set between BeginInit and EndInit calls.
         tb.BeginInit();
         tb.Source = bi;
         // Set image rotation.
         RotateTransform transform = new RotateTransform(90);
         tb.Transform = transform;
         tb.EndInit();
         // Set the Image source.
         rotated90.Source = tb;
         //</SnippetTransformedCSharp1>

         //Add Image to the UI
         Grid.SetColumn(rotated90, 1);
         Grid.SetRow(rotated90, 1);
         transformedGrid.Children.Add(rotated90);

      }

   }
}