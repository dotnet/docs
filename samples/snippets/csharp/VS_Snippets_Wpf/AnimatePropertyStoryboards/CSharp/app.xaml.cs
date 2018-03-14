using System;
using System.Windows;
using System.Windows.Navigation;
using System.Data;
using System.Xml;
using System.Configuration;

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