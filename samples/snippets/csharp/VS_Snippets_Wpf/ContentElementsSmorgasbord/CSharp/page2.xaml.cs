using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoDev;

namespace SDKSample
{
    public partial class Page2 : FlowDocument
    {
        void ConnectFastZoom(object sender, RoutedEventArgs e) 
        {
            FastZoom fz = new FastZoom();
            fz.Attach((FrameworkContentElement)FindName("ExplodeThis"));
        }
    }
}
