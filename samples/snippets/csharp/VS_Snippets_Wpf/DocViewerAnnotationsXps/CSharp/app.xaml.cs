// DocViewerAnnotationsXps SDK Sample - app.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace SDKSample
{
    // ========================== partial class app =========================
    /// <summary>
    ///   Interaction logic for app.xaml</summary>
    public partial class app : Application
    {
        // ---------------------------- AppStartup ----------------------------
        /// <summary>
        ///   Initializes the application and opens the
        ///   display window when the program is started.</summary>
        void AppStartup(object sender, StartupEventArgs args)
        {
            // Create the application window (as defined in Window1.xaml).
            _window1 = new Window1();
            _window1.Show();
        }// end:AppStartup()


        private Window1 _window1 = null;            // application main window

    }// end:partial class app

}// end:namespace SDKSample
