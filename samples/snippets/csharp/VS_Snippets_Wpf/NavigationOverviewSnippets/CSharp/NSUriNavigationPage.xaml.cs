//<SnippetNSUriNavigationPageCODEBEHIND>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class NSUriNavigationPage : Page
    {
        public NSUriNavigationPage()
        {
            InitializeComponent();
        }

        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Create a pack URI
            Uri uri = new Uri("AnotherPage.xaml", UriKind.Relative);

            // Get the navigation service that was used to 
            // navigate to this page, and navigate to 
            // AnotherPage.xaml
            this.NavigationService.Navigate(uri);
        }
    }
}
//</SnippetNSUriNavigationPageCODEBEHIND>