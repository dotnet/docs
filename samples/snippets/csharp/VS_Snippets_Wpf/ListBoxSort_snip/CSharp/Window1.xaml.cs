using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;


namespace ListBoxSort_snip
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        //<SnippetHowToCode>
        private void OnClick(object sender, RoutedEventArgs e)
        {
//<SnippetSort>
            myListBox.Items.SortDescriptions.Add(
                new SortDescription("Content", ListSortDirection.Descending));
//</SnippetSort>
        }
        //</SnippetHowToCode>

    }
}