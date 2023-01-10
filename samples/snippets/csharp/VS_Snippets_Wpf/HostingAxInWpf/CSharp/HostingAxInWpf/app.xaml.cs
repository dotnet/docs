using System.Windows;

namespace HostingAxInWpf
{
    /// <summary>
    /// Interaction logic for app.xaml
    /// </summary>

    public partial class app : Application
    {
        void AppStartup(object sender, StartupEventArgs args)
        {
            Window mainWindow = new Window();
            mainWindow.Show();
        }
    }
}
