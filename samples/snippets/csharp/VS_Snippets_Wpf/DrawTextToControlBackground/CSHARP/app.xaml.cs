using System;
using System.Windows;

namespace SDKSample
{
	/// <summary>
	/// Interaction logic for app.xaml
	/// </summary>

	public partial class app : Application
	{
        void AppStartup(object sender, StartupEventArgs args)
        {
			Window1 mainWindow = new Window1();			
			mainWindow.Show();
		}

	}
}