using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class NavigateSourcePage : Page
    {
        public NavigateSourcePage()
        {
            InitializeComponent();
        }
        //<SnippetNavigationServiceSourceCODE>
        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Causes NavigationService to navigate to page at specified URI.
            // NavigationService.CurrentSource will have the URI of the page being
            // navigate from until the navigation is complete.
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Source = new Uri("AnotherPage.xaml", UriKind.Relative);
        }
        //</SnippetNavigationServiceSourceCODE>
    }
}