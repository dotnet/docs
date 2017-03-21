//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ToolTipSimple_wcp
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : StackPanel
	{
                Button button;
                ToolTip tt;
                
		void OnClick(object sender, RoutedEventArgs e)
		{
                        //<Snippet2>
                        button = new Button();
                        button.Content = "Hover over me.";
                        tt = new ToolTip();
                        tt.Content = "Created with C#";
                        button.ToolTip = tt;
                        cv2.Children.Add(button);
                        //</Snippet2>
		}
	}
}