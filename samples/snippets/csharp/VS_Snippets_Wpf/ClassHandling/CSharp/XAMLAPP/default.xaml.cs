
using System;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class XAMLAPP
    {
        void InstanceHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This should never be invoked....");
        }
    }
}
