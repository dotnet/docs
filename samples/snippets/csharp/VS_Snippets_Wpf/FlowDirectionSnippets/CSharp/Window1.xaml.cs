using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FlowDirection_layout
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        // <Snippet_FlowDirection>
        private void LR(object sender, RoutedEventArgs e)
        {
            tf1.FlowDirection = FlowDirection.LeftToRight;
            txt1.Text = "FlowDirection is now " + tf1.FlowDirection;
        }
        private void RL(object sender, RoutedEventArgs e)
        {
            tf1.FlowDirection = FlowDirection.RightToLeft;
            txt1.Text = "FlowDirection is now " + tf1.FlowDirection;
        }
        // </Snippet_FlowDirection>
    }
}