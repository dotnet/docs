//<SnippetAppDefAugCODE1>
using System;
using System.Windows;

namespace SDKSample
{
    public class App : Application
    {
        public App() { }
        [STAThread]
        public static void Main()
        {
            // Create new instance of application subclass
            App app = new App();

            // Code to register events and set properties that were
            // defined in XAML in the application definition
            app.InitializeComponent();

            // Start running the application
            app.Run();
        }

        public void InitializeComponent()
        {
            //</SnippetAppDefAugCODE1>
            //<SnippetAppDefAugCODE2>
        }
    }
}
//</SnippetAppDefAugCODE2>
