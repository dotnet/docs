using System.Windows;

namespace SDKSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void messageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetGetLocalizedResourceFromCode>
            // Programmatic use of string resource from StringResources.xaml resource dictionary
            string localizedMessage = (string)Application.Current.FindResource("localizedMessage");
            MessageBox.Show(localizedMessage);
            //</SnippetGetLocalizedResourceFromCode>
        }
    }
}