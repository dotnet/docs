// <Snippet1>
using System;
using System.Windows;
using System.Windows.Controls;
class Program : Application
{
    Window win;
    InkCanvas ic;

    protected override void OnStartup(StartupEventArgs args)
    {
        base.OnStartup(args);
        win = new Window();
        ic = new InkCanvas();
        win.Content = ic;
        win.Show();
    }

    [STAThread]
    static void Main(string[] args)
    {
        new Program().Run();
    }
}
// </Snippet1>