//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace Menus
{
	
	public partial class Pane1 : Canvas
	{
        System.Windows.Controls.Menu menu;
        System.Windows.Controls.MenuItem mi, mia, mib, mic;

        void OnClick(object sender, RoutedEventArgs e)
		{
                //<Snippet2>
                menu = new Menu();
                menu.Background = Brushes.LightBlue;
                mi = new MenuItem();
                mi.Width = 50;
                mi.Header = "_File";
                menu.Items.Add(mi);

                //<Snippet7>
                mia = new MenuItem();
                mia.Header = "_Cut";
                mia.InputGestureText = "Ctrl+X";
                mi.Items.Add(mia);
                //</Snippet7>

                //<Snippet9>
                mib = new MenuItem();
                mib.Command = System.Windows.Input.ApplicationCommands.Copy;
                mib.Header = "_Copy";
                mi.Items.Add(mib);

                mic = new MenuItem();
                mic.Command = System.Windows.Input.ApplicationCommands.Paste;
                mic.Header = "_Paste";
                mi.Items.Add(mic);
                //</Snippet9>
                cv2.Children.Add(menu);
                //</Snippet2>
		}
	}
}