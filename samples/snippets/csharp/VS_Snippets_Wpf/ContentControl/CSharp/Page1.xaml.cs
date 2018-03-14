//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ContentControlSimple
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>



    public partial class Page1 : Canvas
    {
        //<Snippet4>
        void OnClick(object sender, RoutedEventArgs e)
        {
            if (contCtrl.HasContent == true)
            {
                MessageBox.Show("contCtrl has content");
            }
        }
        //</Snippet4>
    }
}

