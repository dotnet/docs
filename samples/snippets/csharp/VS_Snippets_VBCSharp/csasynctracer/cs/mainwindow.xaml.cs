
//<snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Add a using directive and a reference for System.Net.Http;
using System.Net.Http;

namespace AsyncTracer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            // The display lines in the example lead you through the control shifts.
            resultsTextBox.Text += "ONE:   Entering startButton_Click.\r\n" +
                "           Calling AccessTheWebAsync.\r\n";

            //<snippet4>
            Task<int> getLengthTask = AccessTheWebAsync();
            //</snippet4>

            resultsTextBox.Text += "\r\nFOUR:  Back in startButton_Click.\r\n" +
                "           Task getLengthTask is started.\r\n" +
                "           About to await getLengthTask -- no caller to return to.\r\n";

            //<snippet5>
            int contentLength = await getLengthTask;
            //</snippet5>

            resultsTextBox.Text += "\r\nSIX:   Back in startButton_Click.\r\n" +
                "           Task getLengthTask is finished.\r\n" +
                "           Result from AccessTheWebAsync is stored in contentLength.\r\n" +
                "           About to display contentLength and exit.\r\n";

            resultsTextBox.Text +=
                String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
        }


        async Task<int> AccessTheWebAsync()
        {
            resultsTextBox.Text += "\r\nTWO:   Entering AccessTheWebAsync.";

            // Declare an HttpClient object.
            HttpClient client = new HttpClient();

            resultsTextBox.Text += "\r\n           Calling HttpClient.GetStringAsync.\r\n";

            // GetStringAsync returns a Task<string>. 
            //<snippet2>
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            //</snippet2>

            resultsTextBox.Text += "\r\nTHREE: Back in AccessTheWebAsync.\r\n" +
                "           Task getStringTask is started.";

            // AccessTheWebAsync can continue to work until getStringTask is awaited.

            resultsTextBox.Text +=
                "\r\n           About to await getStringTask and return a Task<int> to startButton_Click.\r\n";

            // Retrieve the website contents when task is complete.
            //<snippet3>
            string urlContents = await getStringTask;
            //</snippet3>

            resultsTextBox.Text += "\r\nFIVE:  Back in AccessTheWebAsync." +
                "\r\n           Task getStringTask is complete." +
                "\r\n           Processing the return statement." +
                "\r\n           Exiting from AccessTheWebAsync.\r\n";

            return urlContents.Length;
        }
    }
}
//</snippet1>

// Sample Output:

// ONE:   Entering startButton_Click.
//           Calling AccessTheWebAsync.

// TWO:   Entering AccessTheWebAsync.
//           Calling HttpClient.GetStringAsync.

// THREE: Back in AccessTheWebAsync.
//           Task getStringTask is started.
//           About to await getStringTask and return a Task<int> to startButton_Click.

// FOUR:  Back in startButton_Click.
//           Task getLengthTask is started.
//           About to await getLengthTask -- no caller to return to.

// FIVE:  Back in AccessTheWebAsync.
//           Task getStringTask is complete.
//           Processing the return statement.
//           Exiting from AccessTheWebAsync.

// SIX:   Back in startButton_Click.
//           Task getLengthTask is finished.
//           Result from AccessTheWebAsync is stored in contentLength.
//           About to display contentLength and exit.

// Length of the downloaded string: 33946.


namespace Outline
{
    public partial class MainWindow : Window
    {
        // . . .
        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            // ONE
            Task<int> getLengthTask = AccessTheWebAsync();

            // FOUR
            int contentLength = await getLengthTask;

            // SIX
            //resultsTextBox.Text +=
                String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
        }


        async Task<int> AccessTheWebAsync()
        {
            // TWO
            HttpClient client = new HttpClient();
            Task<string> getStringTask =
                client.GetStringAsync("http://msdn.microsoft.com");

            // THREE                 
            string urlContents = await getStringTask;

            // FIVE
            return urlContents.Length;
        }
    }
}