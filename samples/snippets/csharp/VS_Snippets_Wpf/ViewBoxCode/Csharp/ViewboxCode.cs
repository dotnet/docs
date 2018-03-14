using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace ViewboxCode
{
	public class app : System.Windows.Application
	{
        System.Windows.Controls.Canvas myCanvas;
		System.Windows.Window mainWindow;
        System.Windows.Controls.Viewbox myViewbox;
        System.Windows.Controls.Grid myGrid;
        System.Windows.Controls.TextBlock myTextBlock;
        System.Windows.Shapes.Ellipse myEllipse;

		protected override void OnStartup (StartupEventArgs e)
		{
			base.OnStartup (e);
			CreateAndShowMainWindow ();
		}

		private void CreateAndShowMainWindow ()
		{
			// Create the application's main window
			mainWindow = new System.Windows.Window ();

			// Create a Canvas sized to fill the window
			myCanvas = new Canvas();
            myCanvas.Background = System.Windows.Media.Brushes.Silver;
            myCanvas.Width = 600;
            myCanvas.Height = 600;
            // <Snippet1>
            
            // <Snippet2>
            
            // Create a Viewbox and add it to the Canvas
            myViewbox = new Viewbox();
            myViewbox.StretchDirection = StretchDirection.Both;
            myViewbox.Stretch = Stretch.Fill;
            myViewbox.MaxWidth = 400;
            myViewbox.MaxHeight = 400;
            //</Snippet2>

            // Create a Grid that will be hosted inside the Viewbox
            myGrid = new Grid();
            
            // Create an Ellipse that will be hosted inside the Viewbox
            myEllipse = new Ellipse();
            myEllipse.Stroke = Brushes.RoyalBlue;
            myEllipse.Fill = Brushes.LightBlue;

            // Create an TextBlock that will be hosted inside the Viewbox
            myTextBlock = new TextBlock();
            myTextBlock.Text = "Viewbox";

            // Add the children to the Grid
            myGrid.Children.Add(myEllipse);
            myGrid.Children.Add(myTextBlock);

            // <Snippet3>
            
            // Add the Grid as the single child of the Viewbox
            myViewbox.Child = myGrid;
            
            //</Snippet3>
            
            // Position the Viewbox in the Parent Canvas
            Canvas.SetTop(myViewbox, 100);
            Canvas.SetLeft(myViewbox, 100);
            myCanvas.Children.Add(myViewbox);

            //</Snippet1>
            
            // Set the Window content
            mainWindow.Content = myCanvas;
			mainWindow.Show();
            
		}
	}

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
