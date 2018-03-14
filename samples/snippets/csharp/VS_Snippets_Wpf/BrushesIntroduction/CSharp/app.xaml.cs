using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace BrushesIntroduction
{

    /// <summary>
    /// Defines the application.
    /// </summary>
    public partial class app : Application
    {

        public app()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Window myWindow = new Window();
            myWindow.Content = new SampleViewer();
            myWindow.Show();
        }


    }
}