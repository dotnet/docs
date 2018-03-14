using System;
using System.Windows;
using System.Windows.Navigation;
using System.Data;
using System.Xml;
using System.Configuration;

namespace Microsoft.Samples.Animation.AnimatedTransformations
{
 
    public partial class app : Application
    {
    
        public app()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        
        void AppStartingUp( object sender, StartupEventArgs e )
        {   
            Window myWindow = new Window();
            myWindow.Content = new AnimatedHeightExample(); 
            MainWindow = myWindow;                       
            myWindow.Show();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }
    }

}