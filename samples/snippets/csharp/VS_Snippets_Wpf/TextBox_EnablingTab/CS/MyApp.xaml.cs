using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xml;

namespace Microsoft.Samples.WinFX.EnablingTab
{

    public partial class MyApp : Application
    {
        void AppStartingUp(object sender, StartupEventArgs e)
        {
            // Defined in Window1.xaml.cs - don't change "Window1".
            Window mainWindow = new Window1();
            mainWindow.Show();
        }
    }
}
