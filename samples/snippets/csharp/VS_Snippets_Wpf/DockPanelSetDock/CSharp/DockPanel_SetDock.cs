using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace DockPanel_SetDock
{
	public class app : System.Windows.Application
	{

		System.Windows.Controls.DockPanel dp1;
		System.Windows.Controls.TextBlock txt1;
		System.Windows.Window mainWindow;

		protected override void OnStartup (StartupEventArgs e)
		{
			base.OnStartup (e);
			CreateAndShowMainWindow ();
		}

		private void CreateAndShowMainWindow ()
		{
			// Create the application's main window
			mainWindow = new Window();
            // <Snippet1>
			// Create the Panel DockPanel
			dp1 = new DockPanel();
            
			// Create a Text Control and then set its Dock property
			txt1 = new TextBlock();
			DockPanel.SetDock(txt1, System.Windows.Controls.Dock.Top);
			txt1.Text = "The Dock Property is set to " + DockPanel.GetDock(txt1);
			dp1.Children.Add(txt1);
			mainWindow.Content = dp1;
			mainWindow.Show();
            //</Snippet1>
		}
	}

	internal sealed class EntryClass
	{
		[System.STAThread()]
		private static void Main ()
		{
			app app = new app ();
			app.Run ();
		}
	}
}
