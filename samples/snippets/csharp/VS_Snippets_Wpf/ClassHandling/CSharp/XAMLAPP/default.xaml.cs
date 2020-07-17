
using System;
using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Text;

namespace SDKSample {
    public partial class XAMLAPP{
      void InstanceHandler(object sender, RoutedEventArgs e)
      {
        MessageBox.Show("This should never be invoked....");
      }
  }
}