using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace SDKSample
{
    public class app : Application
    {
        Border myBorder;
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

            // Create the application's main Window.
            mainWindow = new Window ();
            mainWindow.Title = "HorizontalAlignment Sample";

            // Add a Border
            myBorder = new Border();
            myBorder.Background = Brushes.LightBlue;
            myBorder.BorderBrush = Brushes.Black;
            myBorder.Padding = new Thickness(15);
            myBorder.BorderThickness = new Thickness(2);

            myStackPanel = new StackPanel();
            myStackPanel.Background = Brushes.White;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness(5, 0, 5, 0);
            myTextBlock.FontSize = 18;
            myTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock.Text = "HorizontalAlignment Sample";
            // <Snippet2>
            Button myButton1 = new Button();
            myButton1.HorizontalAlignment = HorizontalAlignment.Left;
            myButton1.Content = "Button 1 (Left)";
            Button myButton2 = new Button();
            myButton2.HorizontalAlignment = HorizontalAlignment.Right;
            myButton2.Content = "Button 2 (Right)";
            Button myButton3 = new Button();
            myButton3.HorizontalAlignment = HorizontalAlignment.Center;
            myButton3.Content = "Button 3 (Center)";
            Button myButton4 = new Button();
            myButton4.HorizontalAlignment = HorizontalAlignment.Stretch;
            myButton4.Content = "Button 4 (Stretch)";
            //</Snippet2>
            myStackPanel.Children.Add(myTextBlock);
            myStackPanel.Children.Add(myButton1);
            myStackPanel.Children.Add(myButton2);
            myStackPanel.Children.Add(myButton3);
            myStackPanel.Children.Add(myButton4);
            
            // Add the StackPanel as the lone Child of the Border.
            myBorder.Child = myStackPanel;
            
            // Add the Border as the Content of the Parent Window Object.
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