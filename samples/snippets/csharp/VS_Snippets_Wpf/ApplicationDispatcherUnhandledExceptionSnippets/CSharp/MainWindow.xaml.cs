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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void raiseRecoverableException_Click(object sender, RoutedEventArgs e)
        {
            throw new ArgumentNullException("Recoverable Exception");
        }

        void raiseUnecoverableException_Click(object sender, RoutedEventArgs e)
        {
            throw new DivideByZeroException("Unrecoverable Exception"); 
        }
    }
}