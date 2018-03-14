using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Shapes;


namespace SDKSample
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>

  public partial class Window1 : Page
  {
      private void WindowLoaded(object sender, EventArgs e)
      {
          //Create Bullet Panel and add to aStackPanel4You
          //<Snippet1>
          BulletDecorator myBulletDecorator = new BulletDecorator();
          Image myImage = new Image();
          BitmapImage myBitmapImage = new BitmapImage();
          myBitmapImage.BeginInit();
          myBitmapImage.UriSource = new Uri(@"pack://application:,,/images/apple.jpg");
          myBitmapImage.EndInit();
          myImage.Source = myBitmapImage;
          myImage.Width = 10;
          myBulletDecorator.Bullet = myImage;
          myBulletDecorator.Margin = new Thickness(0, 10, 0, 0);
          myBulletDecorator.VerticalAlignment = VerticalAlignment.Center;
          myBulletDecorator.Background = Brushes.Yellow;
          TextBlock myTextBlock = new TextBlock();
          myTextBlock.Text = "This BulletDecorator created by using code";
          myTextBlock.TextWrapping = TextWrapping.Wrap;
          myTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
          myTextBlock.Width = 100;
          myTextBlock.Foreground = Brushes.Purple;
          myBulletDecorator.Child = myTextBlock;
          //</Snippet1>
          aStackPanel4You.Children.Add(myBulletDecorator);
      }

      private void ChangeFontSize(object sender, RoutedEventArgs e)
      {
          if ((Boolean)FontSize12.IsChecked)
          {
              FontSizeExample.FontSize = 12;
              FontSizeExample.Text = "FontSize 12";
          }
          else if ((Boolean)FontSize24.IsChecked)
          {
              FontSizeExample.FontSize = 24;
              FontSizeExample.Text = "FontSize=24";
          }
          else if ((Boolean)FontSize48.IsChecked)
          {

              FontSizeExample.FontSize = 48;
              FontSizeExample.Text = "FontSize=48";
          }
      }
  }
}