using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

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
