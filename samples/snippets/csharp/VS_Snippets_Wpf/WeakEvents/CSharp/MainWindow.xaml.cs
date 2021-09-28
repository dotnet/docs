using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeakEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EventSource Source;
        EventClientWEPV4UsingManager wep4ManagerEvent;

        public MainWindow()
        {
            InitializeComponent();
            Source = new EventSource();

            wep4ManagerEvent = new EventClientWEPV4UsingManager(Source);
        }

        private void Button_HandleClrEvent(object sender, RoutedEventArgs e)
        {
            Source.RaiseDoEvent();
        }
    }
}
