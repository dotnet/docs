//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace MenuStyles
{
    /// <summary>
    /// Interaction logic for Pane1.xaml
    /// </summary>

    public partial class Pane1 : StackPanel
    {
        string status;

        void StatusClick(object sender, RoutedEventArgs e)
        {

            MenuItem menu = (MenuItem)sender;

            status = (string)menu.Header;
            switch (status)
            {
                case "Online":
                    mi1.IsChecked = true;
                    mi2.IsChecked = false;
                    mi3.IsChecked = false;
                    mi4.IsChecked = false;
                    break;

                case "Busy":
                    mi1.IsChecked = false;
                    mi2.IsChecked = true;
                    mi3.IsChecked = false;
                    mi4.IsChecked = false;
                    break;

                case "Be Right Back":
                    mi1.IsChecked = false;
                    mi2.IsChecked = false;
                    mi3.IsChecked = true;
                    mi4.IsChecked = false;
                    break;

                case "Away":
                    mi1.IsChecked = false;
                    mi2.IsChecked = false;
                    mi3.IsChecked = false;
                    mi4.IsChecked = true;
                    break;
            }
        }

        //<SnippetMenuItemsCheckedEvent>
        private void OnChecked(object sender, RoutedEventArgs e)
        {
            if (mi1.IsChecked == true)
            {
                textBlock1.Text = "Item is checked.";
            }
        }
        //</SnippetMenuItemsCheckedEvent>

        //<SnippetMenuItemsUncheckedEvent>
        private void OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (mi1.IsChecked == false)
            {
                textBlock1.Text = "Item is unchecked.";
            }
        }
        //</SnippetMenuItemsUncheckedEvent>


    }


}