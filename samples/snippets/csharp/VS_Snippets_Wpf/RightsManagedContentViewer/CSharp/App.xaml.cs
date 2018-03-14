// RightsManagedContentViewer SDK Sample - App.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace SdkSample
{
    // =========================== partial class App ==========================
    /// <summary>
    ///   Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        // ---------------------------- AppStartup ----------------------------
        /// <summary>
        ///   Initializes the application and opens the
        ///   display window when the program is started.</summary>
        void AppStartUp(object sender, StartupEventArgs e)
        {
            // Create the application window (as defined in Window1.xaml).
            _appWindow = new Window1();
            _appWindow.Show();
        }// end:AppStartup()


        private Window1 _appWindow = null;      // application main window

    }// end:partial class App

}// end:namespace SdkSample
