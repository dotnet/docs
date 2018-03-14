using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Viewbox_Stretch_Layout_Samp
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        // <Snippet2>
        private void stretchNone(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.None;
            txt1.Text = "Stretch is now set to None.";
        }

        private void stretchFill(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.Fill;
            txt1.Text = "Stretch is now set to Fill.";
        }

        private void stretchUni(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.Uniform;
            txt1.Text = "Stretch is now set to Uniform.";
        }

        private void stretchUniFill(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = System.Windows.Media.Stretch.UniformToFill;
            txt1.Text = "Stretch is now set to UniformToFill.";
        }

        private void sdUpOnly(object sender, RoutedEventArgs e)
        {
            vb1.StretchDirection = System.Windows.Controls.StretchDirection.UpOnly;
            txt2.Text = "StretchDirection is now UpOnly.";
        }

        private void sdDownOnly(object sender, RoutedEventArgs e)
        {
            vb1.StretchDirection = System.Windows.Controls.StretchDirection.DownOnly;
            txt2.Text = "StretchDirection is now DownOnly.";
        }

        private void sdBoth(object sender, RoutedEventArgs e)
        {
            vb1.StretchDirection = System.Windows.Controls.StretchDirection.Both;
            txt2.Text = "StretchDirection is now Both.";
        }
        //</Snippet2>

    }
}