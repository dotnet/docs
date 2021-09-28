// <Snippet2>
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
        Window mainWindow;

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        // <Snippet1>
        private void CreateAndShowMainWindow()
        {
            // Create the application's main window
            mainWindow = new Window ();

            // Create a DockPanel
            DockPanel myDockPanel = new DockPanel();

            // Add the first rectangle to the DockPanel
            Rectangle rect1 = new Rectangle();
            rect1.Stroke = Brushes.Black;
            rect1.Fill = Brushes.SkyBlue;
            rect1.Height = 25;
            DockPanel.SetDock(rect1, Dock.Top);
            myDockPanel.Children.Add(rect1);

            // Add the second rectangle to the DockPanel
            Rectangle rect2 = new Rectangle();
            rect2.Stroke = Brushes.Black;
            rect2.Fill = Brushes.SkyBlue;
            rect2.Height = 25;
            DockPanel.SetDock(rect2, Dock.Top);
            myDockPanel.Children.Add(rect2);

            // Add the third rectangle to the DockPanel
            Rectangle rect4 = new Rectangle();
            rect4.Stroke = Brushes.Black;
            rect4.Fill = Brushes.Khaki;
            rect4.Height = 25;
            DockPanel.SetDock(rect4, Dock.Bottom);
            myDockPanel.Children.Add(rect4);

            // Add the fourth rectangle to the DockPanel
            Rectangle rect3 = new Rectangle();
            rect3.Stroke = Brushes.Black;
            rect3.Fill = Brushes.PaleGreen;
            rect3.Width = 200;
            DockPanel.SetDock(rect3, Dock.Left);
            myDockPanel.Children.Add(rect3);

            // Add the final rectangle to the DockPanel
            Rectangle rect5 = new Rectangle();
            rect5.Stroke = Brushes.Black;
            rect5.Fill = Brushes.White;
            myDockPanel.Children.Add(rect5);

            // Add the DockPanel to the Window as Content and show the Window
            mainWindow.Content = myDockPanel;
            mainWindow.Title = "DockPanel Sample";
            mainWindow.Show();
        }
    }
    //</Snippet1>
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main()
        {
            app app = new app();
            app.Run();
        }
    }
}
//</Snippet2>