using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Data;
using System.Xml;
using System.Configuration;


namespace ImageElementExample
{
	/// <summary>
	/// Interaction logic for app.xaml
	/// </summary>

	public partial class app : Application
	{
		void AppStartingUp(object sender, StartupEventArgs e)
		{
         SampleViewer mainWindow = new SampleViewer();
         mainWindow.Show();
      }
   }
}