using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace BasicManipulation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ReportBoundaryFeedBackExample win2 = new ReportBoundaryFeedBackExample();
            win2.Show();
        }
    }
}
