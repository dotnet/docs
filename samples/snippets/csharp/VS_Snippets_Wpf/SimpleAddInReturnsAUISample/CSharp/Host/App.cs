using System; // STAThreadAttribute, LoaderOptimization
using System.Windows; // Application

namespace Host
{
    /// <summary>
    /// A custom entry point method, Main(), is required to use LoaderOptimizationAttribute,
    /// which ensures that WPF assemblies are shared between the main application's appdomain
    /// and the subsequent appdomains that are created to host isolated add-ins. Using
    /// LoaderOptimizationAttribute dramatically improves performance; otherwise, each 
    /// add-in needs to load a complete set of WPF assemblies.
    /// </summary>
    public class App : Application
    {
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        public static void Main()
        {
            App app = new App();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Show main application window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}