using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using System.Xml;

namespace Microsoft.Samples.Graphics.Geometries
{

    public partial class app : Application
    {

        public app()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            Window myWindow = new Window();
            myWindow.Content = new SampleViewer();
            myWindow.Show();
            this.MainWindow = myWindow;
            base.OnStartup(e);
        }
    }
}
