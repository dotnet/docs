using System;
using System.Windows;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>

    public partial class app : Application
    {
        void AppStartup(object sender, StartupEventArgs e)
        {
            Window mainWindow = new MyWindow();
            mainWindow.Show();
            mainWindow.Height = 600;
            MainWindow.Width = 800;
        }
    }
}