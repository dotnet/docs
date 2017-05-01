using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SDKSample
{

	public partial class Window1 : Window
	{
        //<Snippet2>
        private void Wrap(object sender, RoutedEventArgs e)
        {
            txt2.TextWrapping = System.Windows.TextWrapping.Wrap;
            txt1.Text = "The TextWrap property is currently set to Wrap.";
        }
        private void NoWrap(object sender, RoutedEventArgs e)
        {
            txt2.TextWrapping = System.Windows.TextWrapping.NoWrap;
            txt1.Text = "The TextWrap property is currently set to NoWrap.";
        }
        private void WrapWithOverflow(object sender, RoutedEventArgs e)
        {
            txt2.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt1.Text = "The TextWrap property is currently set to WrapWithOverflow.";
        }
    //</Snippet2>
    }
}