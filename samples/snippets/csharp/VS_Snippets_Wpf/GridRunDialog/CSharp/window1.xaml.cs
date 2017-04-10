// <Snippet2>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Grid_Run_Dialog
{
	public partial class Window1 : Window
	{
		Grid grid1;
		ColumnDefinition colDef1;
		ColumnDefinition colDef2;
		ColumnDefinition colDef3;
		ColumnDefinition colDef4;
		ColumnDefinition colDef5;
		RowDefinition rowDef1;
		RowDefinition rowDef2;
		RowDefinition rowDef3;
		RowDefinition rowDef4;
		TextBlock txt1;
		TextBlock txt2;
		Button button1;
		Button button2;
		Button button3;
		TextBox tb1;
		Image img1;

        void onLoaded(object sender, EventArgs e)
		{
            // Create the application's main window.
            mainWindow.Title = "Grid Run Dialog Sample";
            mainWindow.Background = Brushes.White;

            // <Snippet1>
            
            // Create the Grid.
            grid1 = new Grid ();
            grid1.Background = Brushes.Gainsboro;
            grid1.HorizontalAlignment = HorizontalAlignment.Left;
            grid1.VerticalAlignment = VerticalAlignment.Top;
            grid1.ShowGridLines = true;
            grid1.Width = 425;
            grid1.Height = 165;

            // Define the Columns.
            colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(1, GridUnitType.Auto);
            colDef2 = new ColumnDefinition();
            colDef2.Width = new GridLength(1, GridUnitType.Star);
            colDef3 = new ColumnDefinition();
            colDef3.Width = new GridLength(1, GridUnitType.Star);
            colDef4 = new ColumnDefinition();
            colDef4.Width = new GridLength(1, GridUnitType.Star);
            colDef5 = new ColumnDefinition();
            colDef5.Width = new GridLength(1, GridUnitType.Star);
            grid1.ColumnDefinitions.Add(colDef1);
            grid1.ColumnDefinitions.Add(colDef2);
            grid1.ColumnDefinitions.Add(colDef3);
            grid1.ColumnDefinitions.Add(colDef4);
            grid1.ColumnDefinitions.Add(colDef5);

            // Define the Rows.
            rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(1, GridUnitType.Auto);
            rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(1, GridUnitType.Auto);
            rowDef3 = new RowDefinition();
            rowDef3.Height = new GridLength(1, GridUnitType.Star);
            rowDef4 = new RowDefinition();
            rowDef4.Height = new GridLength(1, GridUnitType.Auto);
            grid1.RowDefinitions.Add(rowDef1);
            grid1.RowDefinitions.Add(rowDef2);
            grid1.RowDefinitions.Add(rowDef3);
            grid1.RowDefinitions.Add(rowDef4);

            // Add the Image.
            img1 = new Image();
            img1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("runicon.png", UriKind.Relative));
            Grid.SetRow(img1, 0);
            Grid.SetColumn(img1, 0);

            // Add the main application dialog.
            txt1 = new TextBlock();
            txt1.Text = "Type the name of a program, folder, document, or Internet resource, and Windows will open it for you.";
            txt1.TextWrapping = TextWrapping.Wrap;
            Grid.SetColumnSpan(txt1, 4);
            Grid.SetRow(txt1, 0);
            Grid.SetColumn(txt1, 1);

            // Add the second text cell to the Grid.
            txt2 = new TextBlock();
            txt2.Text = "Open:";
            Grid.SetRow(txt2, 1);
            Grid.SetColumn(txt2, 0);
            
            // Add the TextBox control.
            tb1 = new TextBox();
            Grid.SetRow(tb1, 1);
            Grid.SetColumn(tb1, 1);
            Grid.SetColumnSpan(tb1, 5);
            
            // Add the buttons.
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button1.Content = "OK";
            button2.Content = "Cancel";
            button3.Content = "Browse ...";
            Grid.SetRow(button1, 3);
            Grid.SetColumn(button1, 2);
            button1.Margin = new Thickness(10, 0, 10, 15);
            button2.Margin = new Thickness(10, 0, 10, 15);
            button3.Margin = new Thickness(10, 0, 10, 15);
            Grid.SetRow(button2, 3);
            Grid.SetColumn(button2, 3);
            Grid.SetRow(button3, 3);
            Grid.SetColumn(button3, 4);
            
            grid1.Children.Add(img1);
            grid1.Children.Add(txt1);
            grid1.Children.Add(txt2);
            grid1.Children.Add(tb1);
            grid1.Children.Add(button1);
            grid1.Children.Add(button2);
            grid1.Children.Add(button3);
            
            mainWindow.Content = grid1;
            //</Snippet1>
        }
    }
}
//</Snippet2>