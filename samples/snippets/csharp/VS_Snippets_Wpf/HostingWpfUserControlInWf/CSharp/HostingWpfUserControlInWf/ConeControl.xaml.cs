using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HostingWpfUserControlInWf
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        // To use this handler put Loaded="UserControlLoaded" in root element of .xaml file.
        // private void UserControlLoaded(object sender, RoutedEventArgs e) {}
        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }
}