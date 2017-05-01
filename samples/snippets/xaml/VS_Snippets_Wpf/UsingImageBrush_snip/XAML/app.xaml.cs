#define DEBUG  
using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Microsoft.Samples.Graphics.UsingImageBrush
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>

    public partial class app : Application
    {



        void AppStartingUp(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Window mainWindow = new MyWindow();
            mainWindow.Show();
            mainWindow.Height = 600;
            MainWindow.Width = 800;
            
            
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }

    }
}