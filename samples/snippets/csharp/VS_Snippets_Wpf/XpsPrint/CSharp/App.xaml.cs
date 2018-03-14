// XpsPrint SDK Sample - App.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Windows;

namespace SDKSample
{
    /// <summary>
    ///   Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        void AppStartup(object sender, StartupEventArgs args)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();
        }

    }// end:partial class App

}// end:namespace SDKSample
