using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

namespace AdornersMiscCode
{
    /// <summary>
    /// Interaction logic for MyApp.xaml
    /// </summary>

    public partial class MyApp : Application
    {

        void AppStartup(object sender, StartupEventArgs args)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();
        }
    }
}
