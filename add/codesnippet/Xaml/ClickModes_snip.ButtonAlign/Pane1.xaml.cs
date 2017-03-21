//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ButtonAlign
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : Canvas
	{
		// To use PaneLoaded put Loaded="PaneLoaded" in root element of .xaml file.
		// private void PaneLoaded(object sender, EventArgs e) {}
		// Sample event handler: 
		
 
        //<Snippet2>       
		void OnClick1(object sender, RoutedEventArgs e)
		{
			btn1.Background = Brushes.LightBlue;
		}

		void OnClick2(object sender, RoutedEventArgs e)
		{
			btn2.Background = Brushes.Pink;
		}

		void OnClick3(object sender, RoutedEventArgs e)
		{
			btn1.Background = Brushes.Pink;
			btn2.Background = Brushes.LightBlue;
		}
        //</Snippet2>        
			
		
   }
}