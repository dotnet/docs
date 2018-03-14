using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.IO;


namespace Microsoft.Samples.Animation.TimingBehaviors
{


    public partial class MyApp : Application
    {
    
        public MyApp()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        
        }
    
    
        void myAppStartup(object sender, StartupEventArgs e)
        {
            Window myWindow = new Window();
            myWindow.Content = new SampleViewer();
            myWindow.Show();
        }
        

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            
            try {
                StreamWriter wr = new StreamWriter("error.txt");
                wr.Write(args.ExceptionObject.ToString());
                wr.Close();
            
            }catch
            {
            
            }
            
            
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }     
    
    }


}
