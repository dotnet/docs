using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace FlowDocSelection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Window2 win2 = new Window2();
            win2.Show();

            Window3 win3 = new Window3();
            win3.Show();
        }
    }
}
