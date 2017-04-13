//<SnippetNSRefreshNavigationPageCODEBEHIND1>
using System.Windows; // RoutedEventArgs
using System.Windows.Controls; // Page
using System.Windows.Navigation; // NavigationService

namespace SDKSample
{
    public partial class NSRefreshNavigationPage : Page
    {
        //</SnippetNSRefreshNavigationPageCODEBEHIND1>
        public NSRefreshNavigationPage()
        {
            InitializeComponent();
        }

        //<SnippetNSRefreshNavigationPageCODEBEHIND2>
        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Force WPF to download this page again
            this.NavigationService.Refresh();
        }
    }
}
//</SnippetNSRefreshNavigationPageCODEBEHIND2>