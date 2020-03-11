using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

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