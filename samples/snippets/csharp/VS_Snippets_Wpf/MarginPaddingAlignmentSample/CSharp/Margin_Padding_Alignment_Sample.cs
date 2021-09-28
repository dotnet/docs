using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace Margin_Padding_Alignment_Sample
{
    public class app : Application
    {
        Border myBorder;
        Grid myGrid;
        Window mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }
        private void CreateAndShowMainWindow()
        {
            // <Snippet4>
            mainWindow = new Window();

            // <Snippet3>
            myBorder = new Border();
            myBorder.Background = Brushes.LightBlue;
            myBorder.BorderBrush = Brushes.Black;
            myBorder.BorderThickness = new Thickness(2);
            myBorder.CornerRadius = new CornerRadius(45);
            myBorder.Padding = new Thickness(25);
            //</Snippet3>

            // Define the Grid.
            myGrid = new Grid();
            myGrid.Background = Brushes.White;
            myGrid.ShowGridLines = true;

            // Define the Columns.
            ColumnDefinition myColDef1 = new ColumnDefinition();
            myColDef1.Width = new GridLength(1, GridUnitType.Auto);
            ColumnDefinition myColDef2 = new ColumnDefinition();
            myColDef2.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition myColDef3 = new ColumnDefinition();
            myColDef3.Width = new GridLength(1, GridUnitType.Auto);

            // Add the ColumnDefinitions to the Grid.
            myGrid.ColumnDefinitions.Add(myColDef1);
            myGrid.ColumnDefinitions.Add(myColDef2);
            myGrid.ColumnDefinitions.Add(myColDef3);

            // Add the first child StackPanel.
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetColumn(myStackPanel, 0);
            Grid.SetRow(myStackPanel, 0);
            TextBlock myTextBlock1 = new TextBlock();
            myTextBlock1.FontSize = 18;
            myTextBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock1.Margin = new Thickness(0, 0, 0, 15);
            myTextBlock1.Text = "StackPanel 1";
            // <Snippet2>
            Button myButton1 = new Button();
            myButton1.Margin = new Thickness(0, 10, 0, 10);
            myButton1.Content = "Button 1";
            Button myButton2 = new Button();
            myButton2.Margin = new Thickness(0, 10, 0, 10);
            myButton2.Content = "Button 2";
            Button myButton3 = new Button();
            myButton3.Margin = new Thickness(0, 10, 0, 10);
            //</Snippet2>
            TextBlock myTextBlock2 = new TextBlock();
            myTextBlock2.Text = @"ColumnDefinition.Width = ""Auto""";
            TextBlock myTextBlock3 = new TextBlock();
            myTextBlock3.Text = @"StackPanel.HorizontalAlignment = ""Left""";
            TextBlock myTextBlock4 = new TextBlock();
            myTextBlock4.Text = @"StackPanel.VerticalAlignment = ""Top""";
            TextBlock myTextBlock5 = new TextBlock();
            myTextBlock5.Text = @"StackPanel.Orientation = ""Vertical""";
            TextBlock myTextBlock6 = new TextBlock();
            myTextBlock6.Text = @"Button.Margin = ""1,10,0,10""";
            myStackPanel.Children.Add(myTextBlock1);
            myStackPanel.Children.Add(myButton1);
            myStackPanel.Children.Add(myButton2);
            myStackPanel.Children.Add(myButton3);
            myStackPanel.Children.Add(myTextBlock2);
            myStackPanel.Children.Add(myTextBlock3);
            myStackPanel.Children.Add(myTextBlock4);
            myStackPanel.Children.Add(myTextBlock5);
            myStackPanel.Children.Add(myTextBlock6);

            // Add the second child StackPanel.
            StackPanel myStackPanel2 = new StackPanel();
            myStackPanel2.HorizontalAlignment = HorizontalAlignment.Stretch;
            myStackPanel2.VerticalAlignment = VerticalAlignment.Top;
            myStackPanel2.Orientation = Orientation.Vertical;
            Grid.SetColumn(myStackPanel2, 1);
            Grid.SetRow(myStackPanel2, 0);
            TextBlock myTextBlock7 = new TextBlock();
            myTextBlock7.FontSize = 18;
            myTextBlock7.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock7.Margin = new Thickness(0, 0, 0, 15);
            myTextBlock7.Text = "StackPanel 2";
            Button myButton4 = new Button();
            myButton4.Margin = new Thickness(10, 0, 10, 0);
            myButton4.Content = "Button 4";
            Button myButton5 = new Button();
            myButton5.Margin = new Thickness(10, 0, 10, 0);
            myButton5.Content = "Button 5";
            Button myButton6 = new Button();
            myButton6.Margin = new Thickness(10, 0, 10, 0);
            myButton6.Content = "Button 6";
            TextBlock myTextBlock8 = new TextBlock();
            myTextBlock8.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock8.Text = @"ColumnDefinition.Width = ""*""";
            TextBlock myTextBlock9 = new TextBlock();
            myTextBlock9.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock9.Text = @"StackPanel.HorizontalAlignment = ""Stretch""";
            TextBlock myTextBlock10 = new TextBlock();
            myTextBlock10.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock10.Text = @"StackPanel.VerticalAlignment = ""Top""";
            TextBlock myTextBlock11 = new TextBlock();
            myTextBlock11.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock11.Text = @"StackPanel.Orientation = ""Horizontal""";
            TextBlock myTextBlock12 = new TextBlock();
            myTextBlock12.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock12.Text = @"Button.Margin = ""10,0,10,0""";
            myStackPanel2.Children.Add(myTextBlock7);
            myStackPanel2.Children.Add(myButton4);
            myStackPanel2.Children.Add(myButton5);
            myStackPanel2.Children.Add(myButton6);
            myStackPanel2.Children.Add(myTextBlock8);
            myStackPanel2.Children.Add(myTextBlock9);
            myStackPanel2.Children.Add(myTextBlock10);
            myStackPanel2.Children.Add(myTextBlock11);
            myStackPanel2.Children.Add(myTextBlock12);

            // Add the final child StackPanel.
            StackPanel myStackPanel3 = new StackPanel();
            myStackPanel3.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel3.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetColumn(myStackPanel3, 2);
            Grid.SetRow(myStackPanel3, 0);
            TextBlock myTextBlock13 = new TextBlock();
            myTextBlock13.FontSize = 18;
            myTextBlock13.HorizontalAlignment = HorizontalAlignment.Center;
            myTextBlock13.Margin = new Thickness(0, 0, 0, 15);
            myTextBlock13.Text = "StackPanel 3";
            // <Snippet1>
            Button myButton7 = new Button();
            myButton7.Margin = new Thickness(10);
            myButton7.Content = "Button 7";
            Button myButton8 = new Button();
            myButton8.Margin = new Thickness(10);
            myButton8.Content = "Button 8";
            Button myButton9 = new Button();
            myButton9.Margin = new Thickness(10);
            myButton9.Content = "Button 9";
            //</Snippet1>
            TextBlock myTextBlock14 = new TextBlock();
            myTextBlock14.Text = @"ColumnDefinition.Width = ""Auto""";
            TextBlock myTextBlock15 = new TextBlock();
            myTextBlock15.Text = @"StackPanel.HorizontalAlignment = ""Left""";
            TextBlock myTextBlock16 = new TextBlock();
            myTextBlock16.Text = @"StackPanel.VerticalAlignment = ""Top""";
            TextBlock myTextBlock17 = new TextBlock();
            myTextBlock17.Text = @"StackPanel.Orientation = ""Vertical""";
            TextBlock myTextBlock18 = new TextBlock();
            myTextBlock18.Text = @"Button.Margin = ""10""";
            myStackPanel3.Children.Add(myTextBlock13);
            myStackPanel3.Children.Add(myButton7);
            myStackPanel3.Children.Add(myButton8);
            myStackPanel3.Children.Add(myButton9);
            myStackPanel3.Children.Add(myTextBlock14);
            myStackPanel3.Children.Add(myTextBlock15);
            myStackPanel3.Children.Add(myTextBlock16);
            myStackPanel3.Children.Add(myTextBlock17);
            myStackPanel3.Children.Add(myTextBlock18);

            // Add child content to the parent Grid.
            myGrid.Children.Add(myStackPanel);
            myGrid.Children.Add(myStackPanel2);
            myGrid.Children.Add(myStackPanel3);

            // Add the Grid as the lone child of the Border.
            myBorder.Child = myGrid;

            // Add the Border to the Window as Content and show the Window.
            mainWindow.Content = myBorder;
            mainWindow.Title = "Margin, Padding, and Alignment Sample";
            mainWindow.Show();
            //</Snippet4>
        }
    }
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