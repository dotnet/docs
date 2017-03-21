using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ListBox_Index
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            //<SnippetSelectorSelectedIndex>
            if (lb.SelectedIndex == 0)
            {
                Item.Content = "Index 0";
            }
            //</SnippetSelectorSelectedIndex>
            else if (lb.SelectedIndex == 1)
            {
                Item.Content = "Index 1";
            }
            else if (lb.SelectedIndex == 2)
            {
                Item.Content = "Index 2";
            }
            else if (lb.SelectedIndex == 3)
            {
                Item.Content = "Index 3";
            }
        }

        //<SnippetSelectorSelected>
        private void OnSelected(object sender, RoutedEventArgs e)
        {
            Item.Content = ((ListBoxItem)sender).Name + " was selected.";
        }
        //</SnippetSelectorSelected>

        //<SnippetSelectorUnselected>
        private void OnUnselected(object sender, RoutedEventArgs e)
        {
            Item.Content = ((ListBoxItem)sender).Name + " was unselected.";
        }
        //</SnippetSelectorUnselected>
        
    }
}