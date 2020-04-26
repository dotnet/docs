// <Snippet2>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace SDKSample
{
    public class app : System.Windows.Application
    {
        Window mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }
        // <Snippet1>
        private void CreateAndShowMainWindow()
        {
            // Create the application's main window
            mainWindow = new Window();

            // Create a canvas sized to fill the window
            Canvas myCanvas = new Canvas();
            myCanvas.Background = Brushes.LightSteelBlue;

            // Add a "Hello World!" text element to the Canvas
            TextBlock txt1 = new TextBlock();
            txt1.FontSize = 14;
            txt1.Text = "Hello World!";
            Canvas.SetTop(txt1, 100);
            Canvas.SetLeft(txt1, 10);
            myCanvas.Children.Add(txt1);

            // Add a second text element to show how absolute positioning works in a Canvas
            TextBlock txt2 = new TextBlock();
            txt2.FontSize = 22;
            txt2.Text = "Isn't absolute positioning handy?";
            Canvas.SetTop(txt2, 200);
            Canvas.SetLeft(txt2, 75);
            myCanvas.Children.Add(txt2);
            mainWindow.Content = myCanvas;
            mainWindow.Title = "Canvas Sample";
            mainWindow.Show();
        }
    }
    //</Snippet1>

    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {
            app app = new app ();
            app.Run ();
        }
    }
}
//</Snippet2>
