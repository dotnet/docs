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
	/// Interaction logic for MyApp.xaml
	/// </summary>

	public partial class MyApp : Application
	{
		void AppStartingUp(object sender, StartupEventArgs e)
		{
         SampleViewer mainWindow = new SampleViewer();
         mainWindow.Show();
      }
   }
}