using System;
using System.Windows;

namespace CSharp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //<SnippetGetApplicationMainWindowCODE>
            // Get the main window
            Window mainWindow = this.MainWindow;
            //</SnippetGetApplicationMainWindowCODE>
        }
    }
}
