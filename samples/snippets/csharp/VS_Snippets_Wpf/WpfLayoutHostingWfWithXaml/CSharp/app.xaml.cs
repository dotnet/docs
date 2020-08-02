using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

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
