//<SnippetStartupEventCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Open a window
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
//</SnippetStartupEventCODEBEHIND>