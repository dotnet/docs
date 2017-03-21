//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ContextMenus
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : Canvas
	{
        
        //<SnippetContextMenuServiceEventHandlers>
        void OnOpening(object sender, RoutedEventArgs e)
                {
                cmButton.Content = "ContextMenu is opening."; 
                }
        void OnClosing(object sender, RoutedEventArgs e)
                {
                 cmButton.Content = "ContextMenu is closing.";
                }
        //</SnippetContextMenuServiceEventHandlers>
       	}
}