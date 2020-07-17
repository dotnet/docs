using System.Windows;
using System.Windows.Controls;
//<SnippetGetNSShortcutCODEBEHIND1>
using System.Windows.Navigation;
//</SnippetGetNSShortcutCODEBEHIND1>

namespace SDKSample
{
    public partial class GetNSPageShortCut : Page
    {
        public GetNSPageShortCut()
        {
            InitializeComponent();
        }

        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
//<SnippetGetNSShortcutCODEBEHIND2>
// Get a reference to the NavigationService that navigated to this Page
NavigationService ns = this.NavigationService;
//</SnippetGetNSShortcutCODEBEHIND2>
        }
    }
}