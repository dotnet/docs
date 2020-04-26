using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class NavigateContentPage : Page
    {
        public NavigateContentPage()
        {
            InitializeComponent();
        }

        //<SnippetNavigationServiceContentCODE>
        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Causes NavigationService to navigate to specified page object.
            // From a navigation history perspective, navigating to an object
            // has the same effect as navigating via URI ie the page navigating
            // from is added to navigation history.
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Content = new AnotherPage();
        }
        //</SnippetNavigationServiceContentCODE>
    }
}