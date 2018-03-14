using System;
using System.Windows;

namespace SDKSamples
{
	/// <summary>
	/// Interaction logic for app.xaml
	/// </summary>

	public partial class app : Application
	{
		void AppStartingUp(object sender, StartupEventArgs e)
		{
         Window1 mainWindow = new Window1();
         mainWindow.InitializeComponent();
         mainWindow.Show();
      }
   }
}