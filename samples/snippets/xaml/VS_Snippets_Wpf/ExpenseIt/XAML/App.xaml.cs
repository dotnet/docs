using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace ExpenseIt
{
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // SECURITY
            // If executing at run time, do not display default exception dialog box:
            // The defualt dialog box displays application-specific information that
            // an attacker may be able to use.
#if(!DEBUG)
            MessageBox.Show("An error occured.");
            e.Handled = true;
#endif
        }
    }
}
