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

namespace StatusBarSimple
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        //<SnippetMakeProgressBar>
        private void MakeProgressBar(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            TextBlock txtb = new TextBlock();
            txtb.Text = "Progress of download.";
            sbar.Items.Add(txtb);
            ProgressBar progressbar = new ProgressBar();
            progressbar.Width = 100;
            progressbar.Height = 20;
            Duration duration = new Duration(TimeSpan.FromSeconds(5));
            DoubleAnimation doubleanimation =
                                       new DoubleAnimation(100.0, duration);
            progressbar.BeginAnimation(ProgressBar.ValueProperty,
                                       doubleanimation);
            ToolTip ttprogbar = new ToolTip();
            ttprogbar.Content = "Shows the progress of a download.";
            progressbar.ToolTip = (ttprogbar);
            sbar.Items.Add(progressbar);
        }
        //</SnippetMakeProgressBar>

        private void MakeTextBlock(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            TextBlock txtb = new TextBlock();
            txtb.Text = "Code compiled successfully.";
            sbar.Items.Add(txtb);
            Rectangle rect = new Rectangle();
            rect.Height = 20;
            rect.Width = 1;
            rect.Fill = Brushes.LightGray;
            sbar.Items.Add(rect);
        }

        private void MakeImage(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            DockPanel dpanel = new DockPanel();
            TextBlock txtb = new TextBlock();
            txtb.Text = "Printing  ";
            dpanel.Children.Add(txtb);
            Image printImage = new Image();
            printImage.Width = 16;
            printImage.Height = 16;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,,/images/print.bmp");
            bi.EndInit();
            printImage.Source = bi;
            dpanel.Children.Add(printImage);
            TextBlock txtb2 = new TextBlock();
            txtb2.Text = "  5pgs";
            dpanel.Children.Add(txtb2);
            StatusBarItem sbi = new StatusBarItem();
            sbi.Content = dpanel;
            sbi.HorizontalAlignment = HorizontalAlignment.Right;
            ToolTip ttp = new ToolTip();
            ttp.Content = "Sent to printer.";
            sbi.ToolTip = (ttp);
            sbar.Items.Add(sbi);
        }

        private void MakeHelp(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            Image helpImage = new Image();
            helpImage.Width = 16;
            helpImage.Height = 16;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,,/images/help.bmp");
            bi.EndInit();
            helpImage.Source = bi;
            ToolTip ttp = new ToolTip();
            ttp.Content = "HELP";
            helpImage.ToolTip = (ttp);
            sbar.Items.Add(helpImage);
        }

        private void MakeGroup(object sender, RoutedEventArgs e)
        {
            sbar.Items.Clear();
            //<SnippetItemsWithSeparator>
            Image helpImage = new Image();
            helpImage.Width = 16;
            helpImage.Height = 16;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"pack://application:,,,/images/help.bmp");
            bi.EndInit();
            helpImage.Source = bi;
            ToolTip ttp = new ToolTip();
            ttp.Content = "HELP";
            helpImage.ToolTip = (ttp);
            sbar.Items.Add(helpImage);

            Separator sp = new Separator();
            sp.Style = (Style)FindResource("StatusBarSeparatorStyle");
            sbar.Items.Add(sp);

            Image printImage = new Image();
            printImage.Width = 16;
            printImage.Height = 16;
            BitmapImage bi_print = new BitmapImage();
            bi_print.BeginInit();
            bi_print.UriSource = new Uri(@"pack://application:,,,/images/print.bmp");
            bi_print.EndInit();
            printImage.Source = bi_print;
            ToolTip ttp_print = new ToolTip();
            ttp.Content = "Sent to printer.";
            printImage.ToolTip = (ttp_print);
            sbar.Items.Add(printImage);
            //</SnippetItemsWithSeparator>

        }
    }
}