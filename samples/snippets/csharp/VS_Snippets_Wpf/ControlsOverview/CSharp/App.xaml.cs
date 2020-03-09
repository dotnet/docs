using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace ControlsOverview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppInCode win2 = new AppInCode();
            win2.Show();

            //Window2 win3 = new Window2();
            //win3.Show();
        }
    }
}