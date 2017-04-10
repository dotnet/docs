//<snippet33>
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

// Add the following using directives, and add a reference for System.Net.Http.
using System.Net.Http;
using System.IO;
using System.Net;


namespace AsyncExampleWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();

            // Disable the button until the operation is complete.
            startButton.IsEnabled = false;

            // One-step async call.
            await SumPageSizesAsync();

            //// Two-step async call.
            //Task sumTask = SumPageSizesAsync();
            //await sumTask;

            resultsTextBox.Text += "\r\nControl returned to startButton_Click.\r\n";

            // Reenable the button in case you want to run the operation again.
            startButton.IsEnabled = true;
        }


        private async Task SumPageSizesAsync()
        {
            //<snippet30>
            // Declare an HttpClient object and increase the buffer size. The
            // default buffer size is 65,536.
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            //</snippet30>
            
            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();
            
            var total = 0;
            
            foreach (var url in urlList)
            {
                // GetByteArrayAsync returns a task. At completion, the task
                // produces a byte array.
                //<snippet31>
                byte[] urlContents = await client.GetByteArrayAsync(url);               
                //</snippet31>               

                // The following two lines can replace the previous assignment statement.
                //Task<byte[]> getContentsTask = client.GetByteArrayAsync(url);
                //byte[] urlContents = await getContentsTask;

                DisplayResults(url, urlContents);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the websites.
            resultsTextBox.Text +=
                string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
        }


        private List<string> SetUpURLList()
        {
            List<string> urls = new List<string> 
            { 
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };
            return urls;
        }


        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format 
            // is designed to be used with a monospaced font, such as
            // Lucida Console or Global Monospace.
            var bytes = content.Length;
            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            resultsTextBox.Text += string.Format("\n{0,-58} {1,8}", displayURL, bytes);
        }
    }
}
//</snippet33>