//This is a list of commonly used namespaces for an application class.
using System;
using System.Windows;
using System.Runtime.InteropServices;

namespace WPF_Hosting_Win32_Control
{
  public partial class app : Application
  {
    [DllImport("comctl32.dll", EntryPoint="InitCommonControls", CharSet=CharSet.Auto)]
    public static extern void InitCommonControls();

    private void ApplicationStartup(object sender, StartupEventArgs args)
    {
      InitCommonControls();
      HostWindow host = new HostWindow();
      host.InitializeComponent();
      host.Show();
    }
  }
}