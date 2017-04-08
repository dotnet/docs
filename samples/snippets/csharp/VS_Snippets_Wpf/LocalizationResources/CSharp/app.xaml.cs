namespace MySampleApp
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Globalization;
    using System.Threading;
    using System.Resources;
    using System.Reflection;
    using System.Windows.Resources;
    public partial class app
    {
            protected override void OnStartup(StartupEventArgs e)
            {
                // Setup the application window.
                Window Mywindow = new Window();
                Mywindow.Width =(500);
                Mywindow.Height =(420);
                ResourceManager rm = new ResourceManager 
                   ("MySampleApp.data.stringtable", Assembly.GetExecutingAssembly());
                Mywindow.Title = rm.GetString("Title");
                FrameworkElement root;
		MySampleApp.MyPage page = new MySampleApp.MyPage();
		page.InitializeComponent();
		root = page as FrameworkElement;
                Mywindow.Content=root;
                Mywindow.Show();
            }
    }
}
