using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace VectorSample
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
            mainWindow.Show();

            ///Displays the values of the variables that will be used
            mainWindow.ShowVars();

        }

    }
}