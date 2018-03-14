using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.Properties["NumberOfAppSessions"] = int.Parse(Application.Current.Properties["NumberOfAppSessions"].ToString()) + 1;
            this.Title = "Number of app sessions: " + Application.Current.Properties["NumberOfAppSessions"].ToString();
        }

    }
}