using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp
{
    //<SnippetGetPageNavigationServiceCODEBEHIND>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            // Don't allow back navigation if no navigation service
            if (this.NavigationService != null)
            {
                this.goBackButton.IsEnabled = false;
            }
        }

        void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            // Go to previous entry in journal back stack
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
    //</SnippetGetPageNavigationServiceCODEBEHIND>
}