using System;
using System.Windows;

namespace SDKSample
{
    public partial class MyApp : Application
    {
        void AppStartup(object sender, StartupEventArgs e)
        {
            Window mainWindow = new Window1();
            mainWindow.Show();
            mainWindow.Height = 600;
            MainWindow.Width = 800;
        }
    }
}