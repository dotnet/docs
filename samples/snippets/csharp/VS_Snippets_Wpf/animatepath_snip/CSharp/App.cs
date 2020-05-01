using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Microsoft.Samples.Animation.AnimatePathShapeSample
{

    // Displays the sample.
    public class app : Application
    {

        public app()
        {
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
            Page myContent = new EllipseGeometryExample();
            myWindow.Navigate(myContent);
            MainWindow = myWindow;
            myWindow.Show();
        }
    }

    // Starts the application.
    internal sealed class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {

            app app = new app ();
            app.Run ();
        }
    }
}
