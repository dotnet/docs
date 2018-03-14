using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace AdvancedInkInputSemples
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

            //Window2 win = new Window2();
            //win.Show();
        }

    }
}