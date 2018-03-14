//<SnippetNSNavigationPageCODEBEHIND>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class NSNavigationPage : Page
    {
        public NSNavigationPage()
        {
            InitializeComponent();
        }

        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate the page to navigate to
            PageWithNonDefaultConstructor page = new PageWithNonDefaultConstructor("Hello!");

            // Navigate to the page, using the NavigationService
            this.NavigationService.Navigate(page);
        }
    }
}
//</SnippetNSNavigationPageCODEBEHIND>