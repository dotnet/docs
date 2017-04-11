//<SnippetNSUriNavigationPageCODEBEHIND>
using System; // Uri, UriKind
using System.Windows; // RoutedEventArgs
using System.Windows.Controls; // Page
using System.Windows.Navigation; // NavigationService

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