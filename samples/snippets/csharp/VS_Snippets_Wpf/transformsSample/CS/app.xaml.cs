using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Media;

namespace Microsoft.Samples.Graphics.Transforms
{

    public partial class app : Application
    {



		void AppStartingUp(object sender, StartupEventArgs e)
		{
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			Window mainWindow = new SampleViewer();
			mainWindow.Show();

		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
		{
			MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
		}

    }
}