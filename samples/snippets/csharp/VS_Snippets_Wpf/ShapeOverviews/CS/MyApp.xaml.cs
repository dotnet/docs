using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

namespace AvalonTemplate
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

            ///Displays the values of the variables that will be used
            mainWindow.ShowVars();
        }
    }
}
