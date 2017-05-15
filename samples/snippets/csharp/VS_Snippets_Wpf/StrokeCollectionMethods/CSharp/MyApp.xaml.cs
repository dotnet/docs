using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace StrokeCollectionEraseMethods
{
    /// <summary>
    /// Interaction logic for MyApp.xaml
    /// </summary>

    public partial class MyApp : Application
    {
        void AppStartingUp(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();

            //Window2 secondWindow = new Window2();
            //secondWindow.Show();

            //Window3 thirdWindow = new Window3();
            //thirdWindow.Show();
        }

    }
}