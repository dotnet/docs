using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.IO;

namespace Microsoft.Samples.CustomControls
{

    // Displays the sample.
    public partial class MyApp : Application
    {

        public MyApp()
        {
            
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(currentDomain_UnhandledException);
        }


        protected override void OnStartup(StartupEventArgs e)
        {
           
            Window w = new Window();
            w.Content = new SampleViewer();
            w.Show();
            
            base.OnStartup(e);
        }



        private void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());

            StreamWriter s = new StreamWriter("error.txt");
            s.Write(args.ExceptionObject.ToString());
            s.Flush();
            s.Close();
            
        }
    }

}