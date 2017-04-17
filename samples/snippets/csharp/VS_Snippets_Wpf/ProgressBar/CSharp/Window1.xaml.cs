using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace ProgBar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        
        private void MakeOne(object sender, RoutedEventArgs e)
        {
           sbar.Items.Clear();
           Label lbl = new Label();
           lbl.Background = new LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90);
           lbl.Content = "ProgressBar with one iteration.";
           sbar.Items.Add(lbl);
           //<Snippet1>
           ProgressBar progbar = new ProgressBar();
           progbar.IsIndeterminate = false;
           progbar.Orientation = Orientation.Horizontal;
           progbar.Width = 150;
           progbar.Height = 15;
           Duration duration = new Duration(TimeSpan.FromSeconds(10));
           DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
           progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
           //</Snippet1>
           sbar.Items.Add(progbar);
          } 

         private void MakeThree(object sender, RoutedEventArgs e)
         {
           sbar.Items.Clear();
           Label lbl = new Label();
           lbl.Background = new LinearGradientBrush(Colors.Pink, Colors.Red, 90);
           lbl.Content = "ProgressBar with three iterations.";
           sbar.Items.Add(lbl);
           ProgressBar progbar = new ProgressBar();
           progbar.Background = Brushes.Gray;
           progbar.Foreground = Brushes.Red;
           progbar.Width = 150;
           progbar.Height = 15;
           Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
           DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
           doubleanimation.RepeatBehavior = new RepeatBehavior(3);
           progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
           sbar.Items.Add(progbar);
         }
        
        private void MakeFive(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            TextBlock txtb = new TextBlock();
            txtb.Text = "ProgressBar with five iterations.";
            sbar.Items.Add(txtb);
            Image image = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,,/data/sunset.png");
            bi.EndInit();
            image.Source = bi;
            ImageBrush imagebrush = new ImageBrush(bi);

            ProgressBar progbar = new ProgressBar();
            progbar.Background = imagebrush;
            progbar.Width = 150;
            progbar.Height = 15;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            doubleanimation.RepeatBehavior = new RepeatBehavior(5);
            progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
            sbar.Items.Add(progbar);
         }
 
         private void MakeForever(object sender, RoutedEventArgs e)
         {
           sbar.Items.Clear();
           Label lbl = new Label();
           lbl.Background = new LinearGradientBrush(Colors.LightBlue,        
                                                    Colors.SlateBlue, 90);
           lbl.Content = "ProgressBar with infinite iterations.";
           sbar.Items.Add(lbl);
           ProgressBar progbar = new ProgressBar();
           progbar.Width = 150;
           progbar.Height = 15;
           Duration duration = new Duration(TimeSpan.FromSeconds(1));
           DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
           doubleanimation.RepeatBehavior = RepeatBehavior.Forever;
           progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
           sbar.Items.Add(progbar);
          
         }

         private void MakeIndeterminate(object sender, RoutedEventArgs e)
         {
             sbar.Items.Clear();
             Label lbl = new Label();
             lbl.Background = new LinearGradientBrush(Colors.Pink, Colors.Red, 90);
             lbl.Content = "Indeterminate ProgressBar.";
             sbar.Items.Add(lbl);
             //<Snippet3>
             ProgressBar progbar = new ProgressBar();
             progbar.Background = Brushes.Gray;
             progbar.Foreground = Brushes.Red;
             progbar.Width = 150;
             progbar.Height = 15;
             progbar.IsIndeterminate = true;
             //</Snippet3>
             sbar.Items.Add(progbar);
         }

     }
}