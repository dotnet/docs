//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using SDKSample;

namespace SDKSample
{
    public partial class RoutedEventCustomApp
    {
		private void TapHandler(object sender, RoutedEventArgs e) 
		{
   			MessageBox.Show("Tapped!");
		}

    }
}