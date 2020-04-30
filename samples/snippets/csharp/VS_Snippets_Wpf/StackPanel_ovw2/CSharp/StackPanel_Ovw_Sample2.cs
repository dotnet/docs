using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace SDKSample
{
    public class MyApp : Application
    {
        StackPanel myStackPanel;
        Window mainWindow;

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        private void CreateAndShowMainWindow ()
        {
            // <Snippet1>

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "StackPanel Sample";

            // Define the StackPanel
            myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;

            // Define child content
            Button myButton1 = new Button();
            myButton1.Content = "Button 1";
            Button myButton2 = new Button();
            myButton2.Content = "Button 2";
            Button myButton3 = new Button();
            myButton3.Content = "Button 3";

            // Add child elements to the parent StackPanel
            myStackPanel.Children.Add(myButton1);
            myStackPanel.Children.Add(myButton2);
            myStackPanel.Children.Add(myButton3);

            // Add the StackPanel as the Content of the Parent Window Object
            mainWindow.Content = myStackPanel;
            mainWindow.Show ();

            //</Snippet1>
        }
    }

    // Define a static entry class
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {
            MyApp app = new MyApp ();
            app.Run ();
        }
    }
}