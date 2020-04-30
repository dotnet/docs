using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Threading;

namespace PlotPanel
{
	public class app : System.Windows.Application
	{
        PlotPanel plot1;
        Window mainWindow;
        Rectangle rect1;

        protected override void OnStartup (StartupEventArgs e)
		{
		base.OnStartup (e);
		CreateAndShowMainWindow ();
		}

		private void CreateAndShowMainWindow()
		{
		// Create the application's main window
		mainWindow = new System.Windows.Window();
        plot1 = new PlotPanel();
        plot1.Background = Brushes.White;

        rect1 = new Rectangle();
        rect1.Fill = Brushes.CornflowerBlue;
        rect1.Width = 200;
        rect1.Height = 200;
        mainWindow.Content = plot1;
        plot1.Children.Add(rect1);
        mainWindow.Title = "Custom Panel Sample";
        mainWindow.Show();
		}
        // <Snippet1>
        public class PlotPanel : Panel
        {
            // Default public constructor
            public PlotPanel()
                : base()
            {
            }

            // Override the default Measure method of Panel
            // <Snippet2>
            protected override Size MeasureOverride(Size availableSize)
            {
                Size panelDesiredSize = new Size();

                // In our example, we just have one child.
                // Report that our panel requires just the size of its only child.
                foreach (UIElement child in InternalChildren)
                {
                    child.Measure(availableSize);
                    panelDesiredSize = child.DesiredSize;
                }

                return panelDesiredSize ;
            }
            //</Snippet2>
            protected override Size ArrangeOverride(Size finalSize)
            {
                foreach (UIElement child in InternalChildren)
                {
                    double x = 50;
                    double y = 50;

                    child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                }
                return finalSize; // Returns the final Arranged size
            }
        }
        //</Snippet1>
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
