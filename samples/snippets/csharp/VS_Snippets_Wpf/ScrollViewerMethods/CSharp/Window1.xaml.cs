using System;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Text;

namespace ScrollViewer_Methods
{
    public partial class Window1 : Window
    {
        private static String FillText = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.";

        private void onLoad(object sender, System.EventArgs e)
        {
            StringBuilder myStringBuilder = new StringBuilder(400);
            for (int i = 0; i < 100; i++)
            {
                myStringBuilder.Append(FillText);
            }
            txt1.Text = myStringBuilder.ToString();
        }
        // <Snippet2>
        private void svLineUp(object sender, RoutedEventArgs e)
        {
            sv1.LineUp();
        }
        private void svLineDown(object sender, RoutedEventArgs e)
        {
            sv1.LineDown();
        }
        // </Snippet2>
        private void svLineRight(object sender, RoutedEventArgs e)
        {
            sv1.LineRight();
        }
        private void svLineLeft(object sender, RoutedEventArgs e)
        {
            sv1.LineLeft();
        }
        private void svPageUp(object sender, RoutedEventArgs e)
        {
            sv1.PageUp();
        }
        private void svPageDown(object sender, RoutedEventArgs e)
        {
            sv1.PageDown();
        }
        private void svPageRight(object sender, RoutedEventArgs e)
        {
            sv1.PageRight();
        }
        private void svPageLeft(object sender, RoutedEventArgs e)
        {
            sv1.PageLeft();
        }
    }
}