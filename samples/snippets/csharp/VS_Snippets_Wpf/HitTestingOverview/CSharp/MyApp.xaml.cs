using System;
using System.Windows;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>

    public partial class MyApp : Application
    {
        void AppStartingUp(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.InitializeComponent();
            mainWindow.Show();
        }
    }
}