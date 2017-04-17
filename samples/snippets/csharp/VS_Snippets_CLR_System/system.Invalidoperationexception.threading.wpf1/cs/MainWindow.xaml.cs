using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace WPFCrossThreadCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

 
        // <Snippet1>
        private async void threadExampleBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = String.Empty;

            textBox1.Text = "Simulating work on UI thread.\n";
            DoSomeWork(20);
            textBox1.Text += "Work completed...\n";

            textBox1.Text += "Simulating work on non-UI thread.\n";
            await Task.Run( () => DoSomeWork(1000));
            textBox1.Text += "Work completed...\n";
        }

        private async void DoSomeWork(int milliseconds)
        {
            // Simulate work.
            await Task.Delay(milliseconds);

            // Report completion.
            var msg = String.Format("Some work completed in {0} ms.\n", milliseconds);
            textBox1.Text += msg;
        }
        // </Snippet1>
    }
}
