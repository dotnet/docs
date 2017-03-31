using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for AnotherPage.xaml
    /// </summary>

    public partial class AnotherPage : System.Windows.Controls.Page
    {
        public AnotherPage()
        {
            InitializeComponent();
        }

//<SnippetNavigationServiceRefreshCODE>
void refreshHyperlink_Click(object sender, RoutedEventArgs e)
{
    // Reload the current page.
    this.NavigationService.Refresh();
}
//</SnippetNavigationServiceRefreshCODE>
    }
}