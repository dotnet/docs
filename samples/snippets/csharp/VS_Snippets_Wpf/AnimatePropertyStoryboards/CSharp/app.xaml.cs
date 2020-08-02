using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using System.Xml;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{

    public partial class app : Application
    {

        public app()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationWindow myWindow = new NavigationWindow();
            myWindow.Content = new StoryboardExample();
            MainWindow = myWindow;
            myWindow.Show();
        }
    }
}
