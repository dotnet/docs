using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ScrollChangedEventArgs_layout
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        // <Snippet4>
        private void scrollTrue(object sender, RoutedEventArgs e)
        {
            svrContent.CanContentScroll = true;
            svrContent.Height = 600;
            myStackPanel.Visibility = Visibility.Visible;
            btnEnableContentScrolling.Visibility = Visibility.Collapsed;
        }
        //</Snippet4>

        // <Snippet3>
        private void sChanged(object sender, ScrollChangedEventArgs e)
        {
            if (svrContent.CanContentScroll == true)
            {
                tBlock1.Foreground = System.Windows.Media.Brushes.Red;
                tBlock1.Text = "ScrollChangedEvent just Occurred";
                tBlock2.Text = "ExtentHeight is now " + e.ExtentHeight.ToString();
                tBlock3.Text = "ExtentWidth is now " + e.ExtentWidth.ToString();
                tBlock4.Text = "ExtentHeightChange was " + e.ExtentHeightChange.ToString();
                tBlock5.Text = "ExtentWidthChange was " + e.ExtentWidthChange.ToString();
                tBlock6.Text = "HorizontalOffset is now " + e.HorizontalOffset.ToString();
                tBlock7.Text = "VerticalOffset is now " + e.VerticalOffset.ToString();
                tBlock8.Text = "HorizontalChange was " + e.HorizontalChange.ToString();
                tBlock9.Text = "VerticalChange was " + e.VerticalChange.ToString();
                tBlock10.Text = "ViewportHeight is now " + e.ViewportHeight.ToString();
                tBlock11.Text = "ViewportWidth is now " + e.ViewportWidth.ToString();
                tBlock12.Text = "ViewportHeightChange was " + e.ViewportHeightChange.ToString();
                tBlock13.Text = "ViewportWidthChange was " + e.ViewportWidthChange.ToString();
            }
            else
            {
                tBlock1.Text = "";
            }
            //</Snippet3>
        }
    }
}
