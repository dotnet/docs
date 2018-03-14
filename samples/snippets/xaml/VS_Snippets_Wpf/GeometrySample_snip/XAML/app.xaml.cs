
using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Navigation;

namespace Microsoft.Samples.Graphics.Geometries
{


    public partial class app : Application
    {
    
        public app()
        {

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
        
            Window myWindow = new Window();
            myWindow.Content = new SampleViewer();
            myWindow.Show();
            this.MainWindow = myWindow;
            base.OnStartup(e);       
        }
        
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }         
        
    }
}