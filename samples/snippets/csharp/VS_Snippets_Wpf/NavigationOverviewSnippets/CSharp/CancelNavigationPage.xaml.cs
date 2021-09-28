//<SnippetCancelNavigationPageCODEBEHIND>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class CancelNavigationPage : Page
    {
        public CancelNavigationPage()
        {
            InitializeComponent();

            // Can only access the NavigationService when the page has been loaded
            this.Loaded += new RoutedEventHandler(CancelNavigationPage_Loaded);
            this.Unloaded += new RoutedEventHandler(CancelNavigationPage_Unloaded);
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Force WPF to download this page again
            this.NavigationService.Navigate(new Uri("AnotherPage.xaml", UriKind.Relative));
        }

        void CancelNavigationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigating += new NavigatingCancelEventHandler(NavigationService_Navigating);
        }

        void CancelNavigationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigating -= new NavigatingCancelEventHandler(NavigationService_Navigating);
        }

        void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            // Does the user really want to navigate to another page?
            MessageBoxResult result;
            result = MessageBox.Show("Do you want to leave this page?", "Navigation Request", MessageBoxButton.YesNo);

            // If the user doesn't want to navigate away, cancel the navigation
            if (result == MessageBoxResult.No) e.Cancel = true;
        }
    }
}
//</SnippetCancelNavigationPageCODEBEHIND>