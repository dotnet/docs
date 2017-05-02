//<SnippetStartupXBAPCODEBEHIND>
using System;
using System.Windows;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class App : Application
    {        
        void App_Startup(object sender, StartupEventArgs e)
        {
            ((NavigationWindow)this.MainWindow).Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
//</SnippetStartupXBAPCODEBEHIND>

//protected override void OnActivated(EventArgs e)
//{
//    base.OnActivated(e);

//    Console.WriteLine("Activated");
//}

//protected override void OnDeactivated(EventArgs e)
//{
//    base.OnDeactivated(e);

//    Console.WriteLine("Deactivated");
//}

//protected override void OnExit(ExitEventArgs e)
//{
//    base.OnExit(e);

//    Console.WriteLine("Exit");

//    e.ApplicationExitCode = -10;
//}

//protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
//{
//    base.OnSessionEnding(e);

//    MessageBoxResult result = MessageBox.Show("End SEssion?", "End?", MessageBoxButton.YesNo);
//    if( result == MessageBoxResult.No) e.Cancel = true;
//}