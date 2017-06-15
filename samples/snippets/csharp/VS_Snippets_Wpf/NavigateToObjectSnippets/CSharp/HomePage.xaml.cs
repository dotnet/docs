//<SnippetPageThatNavsToObjectCODEBEHIND>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person("Nancy Davolio", Colors.Yellow);
            this.NavigationService.Navigate(person);
        }
    }
}
//</SnippetPageThatNavsToObjectCODEBEHIND>