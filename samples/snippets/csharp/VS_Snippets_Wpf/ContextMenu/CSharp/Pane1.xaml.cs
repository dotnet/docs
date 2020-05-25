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
        System.Windows.Controls.ContextMenu contextmenu;
        System.Windows.Controls.MenuItem mi, mia, mib, mib1, mib1a;
        System.Windows.Controls.Button btn;

        //<SnippetContextMenuEventHandlers>
        void OnOpened(object sender, RoutedEventArgs e)
        {
            cmButton.Content = "The ContextMenu Opened";
        }
        void OnClosed(object sender, RoutedEventArgs e)
        {
            cmButton.Content = "The ContextMenu Closed";
        }
        //</SnippetContextMenuEventHandlers>

        void IsOpenSnippet()
        {
            //<SnippetContextMenuIsOpen>
            if (cm.IsOpen == true)
            {
                cmButton.Content = "The ContextMenu opened and the IsOpen property is true.";
            }
            //</SnippetContextMenuIsOpen>
        }
        void OnClick(object sender, RoutedEventArgs e)
        {
            //<Snippet2>
            btn = new Button();
            btn.Content = "Created with C#";
            contextmenu = new ContextMenu();
            btn.ContextMenu = contextmenu;
            mi = new MenuItem();
            mi.Header = "File";
            mia = new MenuItem();
            mia.Header = "New";
            mi.Items.Add(mia);
            mib = new MenuItem();
            mib.Header = "Open";
            mi.Items.Add(mib);
            mib1 = new MenuItem();
            mib1.Header = "Recently Opened";
            mib.Items.Add(mib1);
            mib1a = new MenuItem();
            mib1a.Header = "Text.xaml";
            mib1.Items.Add(mib1a);
            contextmenu.Items.Add(mi);
            cv2.Children.Add(btn);
            //</Snippet2>
        }

        //Not snippeting these event handlers because they're identical to
        //MenuItemCommandAndEvents#2.  Use that snippet as the companion to
        //ContextMenu#Events (in pane1.xaml of this project).
        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox1.FontWeight = FontWeights.Normal;
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.FontStyle = FontStyles.Italic;
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox1.FontStyle = FontStyles.Normal;
        }

        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.FontSize < 18)
            {
                textBox1.FontSize += 2;
            }
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.FontSize > 10)
            {
                textBox1.FontSize -= 2;
            }
        }
    }
}