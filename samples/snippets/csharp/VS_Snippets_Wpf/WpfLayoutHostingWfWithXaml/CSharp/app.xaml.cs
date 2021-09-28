using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace WpfLayoutHostingWfWithXaml
{
    /// <summary>
    /// Interaction logic for app.xaml
    /// </summary>

    public partial class app : Application
    {

        void AppStartup(object sender, StartupEventArgs args)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}