using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace SDKSample
{
    public class app : Application
    {
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
            mainWindow.Title = "Canvas Attached Properties Sample";

            // Add a Border
            Border myBorder = new Border();
            myBorder.HorizontalAlignment = HorizontalAlignment.Left;
            myBorder.VerticalAlignment = VerticalAlignment.Top;
            myBorder.BorderBrush = Brushes.Black;
            myBorder.BorderThickness = new Thickness(2);

            // Create the Canvas
            Canvas myCanvas = new Canvas();
            myCanvas.Background = Brushes.LightBlue;
            myCanvas.Width = 400;
            myCanvas.Height = 400;

            // Create the child Button elements
            Button myButton1 = new Button();
            Button myButton2 = new Button();
            Button myButton3 = new Button();
            Button myButton4 = new Button();

            // Set Positioning attached properties on Button elements
            Canvas.SetTop(myButton1, 50);
            myButton1.Content = "Canvas.Top=50";
            Canvas.SetBottom(myButton2, 50);
            myButton2.Content = "Canvas.Bottom=50";
            Canvas.SetLeft(myButton3, 50);
            myButton3.Content = "Canvas.Left=50";
            Canvas.SetRight(myButton4, 50);
            myButton4.Content = "Canvas.Right=50";

            // Add Buttons to the Canvas' Children collection
            myCanvas.Children.Add(myButton1);
            myCanvas.Children.Add(myButton2);
            myCanvas.Children.Add(myButton3);
            myCanvas.Children.Add(myButton4);

            // Add the Canvas as the lone Child of the Border
            myBorder.Child = myCanvas;

            // Add the Border as the Content of the Parent Window Object
            mainWindow.Content = myBorder;
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
            app app = new app ();
            app.Run ();
        }
    }
}