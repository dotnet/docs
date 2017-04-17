using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Threading;
using System.Configuration;
using System.Globalization;

namespace StatusBarSimple
{
    /// <summary>
    /// Interaction logic for app.xaml
    /// </summary>

    public partial class app : Application
    {
        private void On_Startup(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.InitializeComponent();
            mainWindow.Show();
            
        }

    }
}