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
        ScrollViewer myScrollViewer;
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
            mainWindow.Title = "ScrollViewer Sample";

            // Define a ScrollViewer
            myScrollViewer = new ScrollViewer();
            myScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            // Add Layout control
            myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.TextWrapping = TextWrapping.Wrap;
            myTextBlock.Margin = new Thickness(0, 0, 0, 20);
            myTextBlock.Text = "Scrolling is enabled when it is necessary. Resize the Window, making it larger and smaller.";

            Rectangle myRectangle = new Rectangle();
            myRectangle.Fill = Brushes.Red;
            myRectangle.Width = 500;
            myRectangle.Height = 500;

            // Add child elements to the parent StackPanel
            myStackPanel.Children.Add(myTextBlock);
            myStackPanel.Children.Add(myRectangle);

            // Add the StackPanel as the lone Child of the Border
            myScrollViewer.Content = myStackPanel;

            // Add the Border as the Content of the Parent Window Object
            mainWindow.Content = myScrollViewer;
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