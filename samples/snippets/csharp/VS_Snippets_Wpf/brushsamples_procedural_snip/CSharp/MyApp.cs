using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Microsoft.Samples.BrushExamples
{

    // Displays the sample.
    public partial class MyApp : Application
    {

        public MyApp()
        {
             AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(currentDomain_UnhandledException);
        }

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }

        private void CreateAndShowMainWindow ()
        {
            // Create the application's main window.
            NavigationWindow myWindow = new NavigationWindow();

            // Display the sample
            Page myContent = new SampleViewer();
            myWindow.Navigate(myContent);
            MainWindow = myWindow;
            myWindow.Show();
        }

        private void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }
    }

    // Starts the application.
    internal sealed class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {

            MyApp app = new MyApp ();
            app.Run ();
        }
    }
}
