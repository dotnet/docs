using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace SDKSample
{
    public class app : Application
    {
        Canvas myCanvas;
        Rectangle myRectangle1;
        Rectangle myRectangle2;
        Rectangle myRectangle3;
        Rectangle myRectangle4;
        Rectangle myRectangle5;
        Rectangle myRectangle6;
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
            mainWindow.Title = "Canvas ZIndex Sample";

            // Create the Canvas
            myCanvas = new Canvas();

            // Create the child Rectangle elements
            myRectangle1 = new Rectangle();
            myRectangle2 = new Rectangle();
            myRectangle3 = new Rectangle();
            myRectangle4 = new Rectangle();
            myRectangle5 = new Rectangle();
            myRectangle6 = new Rectangle();

            // Set properties on the Rectangle elements
            Canvas.SetTop(myRectangle1, 100);
            Canvas.SetLeft(myRectangle1, 100);
            Canvas.SetZIndex(myRectangle1, 3);
            myRectangle1.Fill = Brushes.Blue;
            myRectangle1.Width = 100;
            myRectangle1.Height = 100;

            // <Snippet2>
            Canvas.SetTop(myRectangle2, 150);
            Canvas.SetLeft(myRectangle2, 150);
            Canvas.SetZIndex(myRectangle2, 1);
            myRectangle2.Fill = Brushes.Yellow;
            myRectangle2.Width = 100;
            myRectangle2.Height = 100;
            // </Snippet2>

            Canvas.SetTop(myRectangle3, 200);
            Canvas.SetLeft(myRectangle3, 200);
            Canvas.SetZIndex(myRectangle3, 2);
            myRectangle3.Fill = Brushes.Green;
            myRectangle3.Width = 100;
            myRectangle3.Height = 100;

            Canvas.SetTop(myRectangle4, 300);
            Canvas.SetLeft(myRectangle4, 200);
            Canvas.SetZIndex(myRectangle4, 1);
            myRectangle4.Fill = Brushes.Green;
            myRectangle4.Width = 100;
            myRectangle4.Height = 100;

            Canvas.SetTop(myRectangle5, 350);
            Canvas.SetLeft(myRectangle5, 150);
            Canvas.SetZIndex(myRectangle5, 3);
            myRectangle5.Fill = Brushes.Yellow;
            myRectangle5.Width = 100;
            myRectangle5.Height = 100;

            Canvas.SetTop(myRectangle6, 400);
            Canvas.SetLeft(myRectangle6, 100);
            Canvas.SetZIndex(myRectangle6, 2);
            myRectangle6.Fill = Brushes.Blue;
            myRectangle6.Width = 100;
            myRectangle6.Height = 100;
            
            // Add the Rectangles to the Canvas' Children collection
            myCanvas.Children.Add(myRectangle1);
            myCanvas.Children.Add(myRectangle2);
            myCanvas.Children.Add(myRectangle3);
            myCanvas.Children.Add(myRectangle4);
            myCanvas.Children.Add(myRectangle5);
            myCanvas.Children.Add(myRectangle6);
            
            // Add the Canvas as the Content of the parent Window Object
            mainWindow.Content = myCanvas;
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