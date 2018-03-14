using System;
using System.Windows;
using System.Windows.Controls;

namespace grid_issharedsizescope_prop
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        // <Snippet3>
        private void setTrue(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid.SetIsSharedSizeScope(dp1, true);
            txt1.Text = "IsSharedSizeScope Property is set to " + Grid.GetIsSharedSizeScope(dp1).ToString();
        }

        private void setFalse(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid.SetIsSharedSizeScope(dp1, false);
            txt1.Text = "IsSharedSizeScope Property is set to " + Grid.GetIsSharedSizeScope(dp1).ToString();
        }
        //</Snippet3>        
	}
}