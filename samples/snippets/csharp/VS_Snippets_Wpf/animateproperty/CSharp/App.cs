

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Microsoft.Samples.Animation.LocalAnimations
{
  
    
    // Displays the sample.
    public class app : Application
    {
        
        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }

        private void CreateAndShowMainWindow ()
        {
            // Create the application's main window.
            Window sViewer = new SampleViewer();
            MainWindow = sViewer;
            sViewer.Show();
        }
    }    
    
    public class SampleViewer : Window
    {
    
        public SampleViewer()
        {
            TabControl tControl = new TabControl();
            TabItem tItem = new TabItem();
            tItem.Header = "Local Animation Example";
            Frame contentFrame = new Frame();
            contentFrame.Content = new LocalAnimationExample();
            tItem.Content = contentFrame;
            tControl.Items.Add(tItem);
            tItem = new TabItem();
            tItem.Header = "Interactive Animation Example";
            contentFrame = new Frame();
            contentFrame.Content = new InteractiveAnimationExample();
            tItem.Content = contentFrame;
            tControl.Items.Add(tItem);
            
            this.Content = tControl;
            this.Title = "Local Animations Example";
        
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
