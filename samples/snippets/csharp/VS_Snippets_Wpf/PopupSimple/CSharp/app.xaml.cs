﻿using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace Popup_Properties_Sample
{
  /// <summary>
  /// Interaction logic for app.xaml
  /// </summary>

  public partial class app : Application
  {

    void AppStartup(object sender, StartupEventArgs args)
    {
      Window1 mainWindow = new Window1();
      mainWindow.Show();
    }
  }
}