using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace SDKSample
{    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        void btnOdd(object sender, RoutedEventArgs e)
        {
            // Get the NumberList via the DataContext of the passed element.
            FrameworkElement fe = (FrameworkElement)sender;
            NumberList nl = (NumberList)fe.DataContext;

            // Tell the NumberList to set itself to odd values.
            nl.SetOdd();
        }

        // UI Event handler for btnEven
        void btnEven(object sender, RoutedEventArgs e)
        {
            // Get the NumberList by finding its Data Source Object.
            FrameworkElement fe = (FrameworkElement)sender;
            ObjectDataProvider odp = (ObjectDataProvider)fe.FindResource("NumberListDSO");
            NumberList nl = (NumberList)odp.Data;

            // Tell the NumberList to set itself to even values.
            nl.SetEven();
        }

    }

}
