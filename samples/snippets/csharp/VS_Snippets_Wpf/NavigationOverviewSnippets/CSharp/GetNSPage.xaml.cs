using System.Windows;
using System.Windows.Controls;
//<SnippetGetNSCODEBEHIND1>
using System.Windows.Navigation;
//</SnippetGetNSCODEBEHIND1>

namespace SDKSample
{
    public partial class GetNSPage : Page
    {
        public GetNSPage()
        {
            InitializeComponent();
        }

        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
//<SnippetGetNSCODEBEHIND2>
// Get a reference to the NavigationService that navigated to this Page
NavigationService ns = NavigationService.GetNavigationService(this);
//</SnippetGetNSCODEBEHIND2>
        }
    }
}