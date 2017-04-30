using System.Windows;

namespace SDKSample
{
    public class App : Application { }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //<SnippetGetCurrentAppCODE>
            // Get current application
            Application current = App.Current;
            //</SnippetGetCurrentAppCODE>

            //<SnippetGetSTCurrentAppCODE>
            // Get strongly-typed current application
            App app = (App)App.Current;
            //</SnippetGetSTCurrentAppCODE>
        }
    }
}