using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

namespace HOWTOWindowManagementSnippets
{
    //<SnippetFirstWindowUsingCodeCODEBEHIND>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
    //</SnippetFirstWindowUsingCodeCODEBEHIND>
}
