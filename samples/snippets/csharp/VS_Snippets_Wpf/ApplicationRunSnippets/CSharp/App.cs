//<SnippetCustomEntryPointAndRunCODE>
using System;
using System.Windows;

namespace CSharp
{
    public class EntryPoint
    {
        // All WPF applications should execute on a single-threaded apartment (STA) thread
        [STAThread]
        public static void Main()
        {
            CustomApplication app = new CustomApplication();
            app.Run();
        }
    }

    public class CustomApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window window = new Window();
            window.Show();
        }
    }
}
//</SnippetCustomEntryPointAndRunCODE>