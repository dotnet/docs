using System.Windows; // Application, RoutedEventArgs
using System.Windows.Controls; // Page

namespace SDKSample
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void shutdownButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}