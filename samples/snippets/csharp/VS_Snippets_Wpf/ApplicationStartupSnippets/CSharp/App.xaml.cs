//<SnippetStartupCODEBEHIND1>
//<SnippetHandleStartupCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Application is running
            //</SnippetStartupCODEBEHIND1>
            // Process command line args
            bool startMinimized = false;
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i] == "/StartMinimized")
                {
                    startMinimized = true;
                }
            }

            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            if (startMinimized)
            {
                mainWindow.WindowState = WindowState.Minimized;
            }
            mainWindow.Show();
            //<SnippetStartupCODEBEHIND2>
        }
    }
}
//</SnippetStartupCODEBEHIND2>
//</SnippetHandleStartupCODEBEHIND>