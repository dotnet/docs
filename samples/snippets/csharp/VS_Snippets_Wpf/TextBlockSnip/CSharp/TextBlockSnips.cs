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

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "TextBlock Snips";

            // Define the StackPanel
            myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;

            // <Snippet1>
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.FontSize = 18;
            myTextBlock.FontWeight = FontWeights.Bold;
            myTextBlock.FontStyle = FontStyles.Italic;
            myTextBlock.Text = "Hello, world!";
            // </Snippet1>

            // Add child element to the parent StackPanel
            myStackPanel.Children.Add(myTextBlock);

            // Add the StackPanel as the Content of the Parent Window Object
            mainWindow.Content = myStackPanel;
            mainWindow.Show ();
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