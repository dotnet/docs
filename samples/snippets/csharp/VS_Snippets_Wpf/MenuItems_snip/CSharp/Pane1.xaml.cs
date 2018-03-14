//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;

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
            //<Snippet4>
            menu.Width = SystemParameters.CaptionWidth;
            //</Snippet4>
            mi = new MenuItem();
            mi.Width = 50;
            mi.Header = "File";
            menu.Items.Add(mi);

            //<Snippet7>
            mia = new MenuItem();
            mia.Header = "Cut";
            mia.InputGestureText = "Ctrl+X";
            mi.Items.Add(mia);
            //</Snippet7>

            //<Snippet9>
            mib = new MenuItem();
            mib.Command = System.Windows.Input.ApplicationCommands.Copy;
            mi.Items.Add(mib);

            mic = new MenuItem();
            mic.Command = System.Windows.Input.ApplicationCommands.Paste;
            mi.Items.Add(mic);
            //</Snippet9>
            cv2.Children.Add(menu);
            //</Snippet2>
        }

        //<SnippetIsSubMenuOpen>
        private void FileMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (sender == e.Source)
            {
                recentFiles.IsSubmenuOpen = true;
                Keyboard.Focus(recentFiles);
            }
        }
        //</SnippetIsSubMenuOpen>

        //<SnippetSubmenuEventOpened2>
        private void OnSubmenuOpened(object sender, RoutedEventArgs e)
        {

            if (sender == e.Source)
            {
                textBlock1.Text = "Submenu is open.";
            }
        }
        //</SnippetSubmenuEventOpened2>

        //<SnippetSubmenuEventClosed2> 
        private void OnSubmenuClosed(object sender, RoutedEventArgs e)
        {
            if (sender == e.Source)
            {
                textBlock1.Text = "Submenu is closed.";
            }
        }
        //</SnippetSubmenuEventClosed2>

        //<SnippetMenuItemIsHighlighted>
        private void Highlight(object sender, RoutedEventArgs e)
        {
            if (item1.IsHighlighted == true)
            {
                hlbtn.Content = "Item is highlighted.";
            }
        }
        //</SnippetMenuItemIsHighlighted>
    }
}