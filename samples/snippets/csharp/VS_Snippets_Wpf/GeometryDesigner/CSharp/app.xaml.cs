using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for app.xaml
    /// </summary>

    public partial class app : Application
    {
    
        public app()
        {

        }
            
        
        void AppStartingUp(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Title = "Geometry Designer";
            mainWindow.Width = 800;
            mainWindow.Height = 600;
            mainWindow.Show();
        }
        
         

    }
}