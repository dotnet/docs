using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class XAMLOvw : Page
    {
        void NavMe(object sender, RoutedEventArgs e)
        {
            ContentControl cc = e.Source as ContentControl;
            this.NavigationService.Navigate(new Uri(cc.Content.ToString()+".xaml", UriKind.Relative));
        }
    }
}