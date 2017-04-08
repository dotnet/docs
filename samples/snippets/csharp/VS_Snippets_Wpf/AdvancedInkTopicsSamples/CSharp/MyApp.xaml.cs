using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace AdavancedInkTopicsSamples
{
    /// <summary>
    /// Interaction logic for MyApp.xaml
    /// </summary>

    public partial class MyApp : Application
    {
        //public MyApp()
        //    : base()
        //{
        //    Window1 win = new Window1();
        //    win.Show();
        //}

        void AppStartup(object sender, StartupEventArgs args)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();
        }

    }
}