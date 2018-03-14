//<SnippetNSRefreshNavigationPageCODEBEHIND1>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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