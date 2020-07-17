using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;

namespace SDKSample
{
    public partial class TestNavigation : Page
	{
		NavigationWindow navWindow;

        private void Init(object sender, EventArgs e)
        {
	        navWindow = (NavigationWindow) MyApp.Current.MainWindow;
        }

        // <SnippetPerformanceSnippet14>
        private void buttonGoToUri(object sender, RoutedEventArgs args)
        {
            navWindow.Source = new Uri("NewPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void buttonGoNewObject(object sender, RoutedEventArgs args)
        {
            NewPage nextPage = new NewPage();
            nextPage.InitializeComponent();
            navWindow.Content = nextPage;
        }
        // </SnippetPerformanceSnippet14>
    }
}