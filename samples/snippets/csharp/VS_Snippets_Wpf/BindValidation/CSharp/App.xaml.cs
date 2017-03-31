using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace SDKSample
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    void AppStartingUp(object sender, StartupEventArgs e)
    {
      Window1 mainWindow = new Window1();
      mainWindow.Show();
    }
  }
}
