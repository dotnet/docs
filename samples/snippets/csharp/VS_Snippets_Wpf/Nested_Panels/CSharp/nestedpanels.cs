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
        Border myBorder;
        DockPanel myDockPanel;
        Window mainWindow;

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        private void CreateAndShowMainWindow ()
        {
            // Create the application's main window.
            mainWindow = new Window ();
            mainWindow.Title = "Nested Panels Sample";

            // Define the Parent Border
            myBorder = new Border();
            myBorder.Width = 400;
            myBorder.Height = 300;
            myBorder.Background = Brushes.AliceBlue;
            myBorder.BorderBrush = Brushes.DarkSlateBlue;
            myBorder.BorderThickness = new Thickness(2);
            myBorder.HorizontalAlignment = HorizontalAlignment.Left;
            myBorder.VerticalAlignment = VerticalAlignment.Top;

            // <Snippet1>

            // Define the DockPanel.
            myDockPanel = new DockPanel();

            // Add the Left Docked StackPanel
            Border myBorder2 = new Border();
            myBorder2.BorderThickness = new Thickness(1);
            myBorder2.BorderBrush = Brushes.Black;
            DockPanel.SetDock(myBorder2, Dock.Left);
            StackPanel myStackPanel = new StackPanel();
            Button myButton1 = new Button();
            myButton1.Content = "Left Docked";
            myButton1.Margin = new Thickness(5);
            Button myButton2 = new Button();
            myButton2.Content = "StackPanel";
            myButton2.Margin = new Thickness(5);
            myStackPanel.Children.Add(myButton1);
            myStackPanel.Children.Add(myButton2);
            myBorder2.Child = myStackPanel;

            // Add the Top Docked Grid.
            Border myBorder3 = new Border();
            myBorder3.BorderThickness = new Thickness(1);
            myBorder3.BorderBrush = Brushes.Black;
            DockPanel.SetDock(myBorder3, Dock.Top);
            Grid myGrid = new Grid();
            myGrid.ShowGridLines = true;
            RowDefinition myRowDef1 = new RowDefinition();
            RowDefinition myRowDef2 = new RowDefinition();
            ColumnDefinition myColDef1 = new ColumnDefinition();
            ColumnDefinition myColDef2 = new ColumnDefinition();
            ColumnDefinition myColDef3 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(myColDef1);
            myGrid.ColumnDefinitions.Add(myColDef2);
            myGrid.ColumnDefinitions.Add(myColDef3);
            myGrid.RowDefinitions.Add(myRowDef1);
            myGrid.RowDefinitions.Add(myRowDef2);
            TextBlock myTextBlock1 = new TextBlock();
            myTextBlock1.FontSize = 20;
            myTextBlock1.Margin = new Thickness(10);
            myTextBlock1.Text = "Grid Element Docked at the Top";
            Grid.SetRow(myTextBlock1, 0);
            Grid.SetColumnSpan(myTextBlock1, 3);
            Button myButton3 = new Button();
            myButton3.Margin = new Thickness(5);
            myButton3.Content = "A Row";
            Grid.SetColumn(myButton3, 0);
            Grid.SetRow(myButton3, 1);
            Button myButton4 = new Button();
            myButton4.Margin = new Thickness(5);
            myButton4.Content = "of Button";
            Grid.SetColumn(myButton4, 1);
            Grid.SetRow(myButton4, 1);
            Button myButton5 = new Button();
            myButton5.Margin = new Thickness(5);
            myButton5.Content = "Elements";
            Grid.SetColumn(myButton5, 2);
            Grid.SetRow(myButton5, 1);
            myGrid.Children.Add(myTextBlock1);
            myGrid.Children.Add(myButton3);
            myGrid.Children.Add(myButton4);
            myGrid.Children.Add(myButton5);
            myBorder3.Child = myGrid;

            // Add the Bottom Docked StackPanel.
            Border myBorder4 = new Border();
            myBorder4.BorderBrush = Brushes.Black;
            myBorder4.BorderThickness = new Thickness(1);
            DockPanel.SetDock(myBorder4, Dock.Bottom);
            StackPanel myStackPanel2 = new StackPanel();
            myStackPanel2.Orientation = Orientation.Horizontal;
            TextBlock myTextBlock2 = new TextBlock();
            myTextBlock2.Text = "This StackPanel is Docked to the Bottom";
            myTextBlock2.Margin = new Thickness(5);
            myStackPanel2.Children.Add(myTextBlock2);
            myBorder4.Child = myStackPanel2;

            // Add the Canvas, that fills remaining space.
            Border myBorder5 = new Border();
            myBorder4.BorderBrush = Brushes.Black;
            myBorder5.BorderThickness = new Thickness(1);
            Canvas myCanvas = new Canvas();
            myCanvas.ClipToBounds = true;
            TextBlock myTextBlock3 = new TextBlock();
            myTextBlock3.Text = "Content in the Canvas will Fill the remaining space.";
            Canvas.SetTop(myTextBlock3, 50);
            Canvas.SetLeft(myTextBlock3, 50);
            Ellipse myEllipse = new Ellipse();
            myEllipse.Height = 100;
            myEllipse.Width = 125;
            myEllipse.Fill = Brushes.CornflowerBlue;
            myEllipse.Stroke = Brushes.Aqua;
            Canvas.SetTop(myEllipse, 100);
            Canvas.SetLeft(myEllipse, 150);
            myCanvas.Children.Add(myTextBlock3);
            myCanvas.Children.Add(myEllipse);
            myBorder5.Child = myCanvas;

            // Add child elements to the parent DockPanel.
            myDockPanel.Children.Add(myBorder2);
            myDockPanel.Children.Add(myBorder3);
            myDockPanel.Children.Add(myBorder4);
            myDockPanel.Children.Add(myBorder5);
            // </Snippet1>

            // Add the DockPanel as the single child of the Border.
            myBorder.Child = myDockPanel;

            // Add the Border as the Content of the Parent Window Object.
            mainWindow.Content = myBorder;
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