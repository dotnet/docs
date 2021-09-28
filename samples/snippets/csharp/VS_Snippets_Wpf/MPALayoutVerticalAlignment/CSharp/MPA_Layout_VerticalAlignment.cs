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
        Grid myGrid;
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
            mainWindow.Title = "VerticalAlignment Sample";

            // Add a Border
            myBorder = new Border();
            myBorder.Background = Brushes.LightBlue;
            myBorder.BorderBrush = Brushes.Black;
            myBorder.Padding = new Thickness(15);
            myBorder.BorderThickness = new Thickness(2);

            myGrid = new Grid();
            myGrid.Background = Brushes.White;
            myGrid.ShowGridLines = true;
            RowDefinition myRowDef1 = new RowDefinition();
            myRowDef1.Height = new GridLength(25);
            RowDefinition myRowDef2 = new RowDefinition();
            myRowDef2.Height = new GridLength(50);
            RowDefinition myRowDef3 = new RowDefinition();
            myRowDef3.Height = new GridLength(50);
            RowDefinition myRowDef4 = new RowDefinition();
            myRowDef4.Height = new GridLength(50);
            RowDefinition myRowDef5 = new RowDefinition();
            myRowDef5.Height = new GridLength(50);
            myGrid.RowDefinitions.Add(myRowDef1);
            myGrid.RowDefinitions.Add(myRowDef2);
            myGrid.RowDefinitions.Add(myRowDef3);
            myGrid.RowDefinitions.Add(myRowDef4);
            myGrid.RowDefinitions.Add(myRowDef5);

            // <Snippet2>
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.FontSize = 18;
            myTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock.Text = "VerticalAlignment Sample";
            Grid.SetRow(myTextBlock, 0);
            Button myButton1 = new Button();
            myButton1.VerticalAlignment = VerticalAlignment.Top;
            myButton1.Content = "Button 1 (Top)";
            Grid.SetRow(myButton1, 1);
            Button myButton2 = new Button();
            myButton2.VerticalAlignment = VerticalAlignment.Bottom;
            myButton2.Content = "Button 2 (Bottom)";
            Grid.SetRow(myButton2, 2);
            Button myButton3 = new Button();
            myButton3.VerticalAlignment = VerticalAlignment.Center;
            myButton3.Content = "Button 3 (Center)";
            Grid.SetRow(myButton3, 3);
            Button myButton4 = new Button();
            myButton4.VerticalAlignment = VerticalAlignment.Stretch;
            myButton4.Content = "Button 4 (Stretch)";
            Grid.SetRow(myButton4, 4);
            //</Snippet2>

            // Add child elements to the parent Grid.
            myGrid.Children.Add(myTextBlock);
            myGrid.Children.Add(myButton1);
            myGrid.Children.Add(myButton2);
            myGrid.Children.Add(myButton3);
            myGrid.Children.Add(myButton4);

            // Add the Grid as the lone Child of the Border.
            myBorder.Child = myGrid;

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