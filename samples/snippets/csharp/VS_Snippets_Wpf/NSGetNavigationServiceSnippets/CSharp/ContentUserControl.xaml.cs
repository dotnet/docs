using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CSharp
{
    /// <summary>
    /// Interaction logic for ContentUserControl.xaml
    /// </summary>

    public partial class ContentUserControl : UserControl
    {
        public ContentUserControl()
        {
            InitializeComponent();
        }

//<SnippetGetNavigationServiceCODE1>
void getNavigationServiceButton_Click(object sender, RoutedEventArgs e) {
    // Retrieve first navigation service up the content tree
    NavigationService svc = NavigationService.GetNavigationService(this.getNavigationServiceButton);
    if (svc != null)
    {
        // Use navigation service
        //</SnippetGetNavigationServiceCODE1>
        //<SnippetGetNavigationServiceCODE2>
    }
}
//</SnippetGetNavigationServiceCODE2>
    }
}