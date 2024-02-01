using System;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCrossThreadCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void Main() { }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void threadExampleBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = String.Empty;

            textBox1.Text = "Simulating work on UI thread.\n";
            DoSomeWork(20);
            textBox1.Text += "Work completed...\n";

            textBox1.Text += "Simulating work on non-UI thread.\n";
            await Task.Run(() => DoSomeWork(1000));
            textBox1.Text += "Work completed...\n";
        }

        // <Snippet3>
        private async void DoSomeWork(int milliseconds)
        {
            // Simulate work.
            await Task.Delay(milliseconds);

            // Report completion.
            bool uiAccess = textBox1.Dispatcher.CheckAccess();
            String msg = String.Format("Some work completed in {0} ms. on {1}UI thread\n",
                                       milliseconds, uiAccess ? String.Empty : "non-");
            if (uiAccess)
                textBox1.Text += msg;
            else
                textBox1.Dispatcher.Invoke(() => { textBox1.Text += msg; });
        }
        // </Snippet3>
    }
}
