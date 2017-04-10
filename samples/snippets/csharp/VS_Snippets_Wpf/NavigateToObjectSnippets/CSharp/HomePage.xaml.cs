//<SnippetPageThatNavsToObjectCODEBEHIND>
using System.Windows; // RoutedEventArgs
using System.Windows.Controls; // Page
using System.Windows.Media; // Colors

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