using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

namespace GridLengthConverter_grid
{
    /// <summary>
    /// Interaction logic for app.xaml
    /// </summary>

    public partial class app : Application
    {
        void AppStartingUp(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.InitializeComponent();
            mainWindow.Show();
        }
    }
}
