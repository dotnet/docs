//<snippet10>
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
//<snippet11>
using System.Net.Http;
using System.IO;
using System.Net;
//</snippet11>

namespace AsyncExampleWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //<snippet24>
        private async void startButton_Click(object sender, RoutedEventArgs e)
        //</snippet24>
        {
            //<snippet25>
            // Disable the button until the operation is complete.
            startButton.IsEnabled = false;
            //</snippet25>

            resultsTextBox.Clear();

            //<snippet23>
            // One-step async call.
            await SumPageSizesAsync();

            // Two-step async call.
            //Task sumTask = SumPageSizesAsync();
            //await sumTask;
            //</snippet23>

            resultsTextBox.Text += "\r\nControl returned to startButton_Click.\r\n";

            //<snippet26>
            // Reenable the button in case you want to run the operation again.
            startButton.IsEnabled = true;
            //</snippet26>
        }


        //<snippet22>
        private async Task SumPageSizesAsync()
        //</snippet22>
        {
            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();

            var total = 0;

            foreach (var url in urlList)
            {
                //<snippet19>
                byte[] urlContents = await GetURLContentsAsync(url);
                //</snippet19>

                // The previous line abbreviates the following two assignment statements.

                //<snippet21>
                // GetURLContentsAsync returns a Task<T>. At completion, the task
                // produces a byte array.
                //Task<byte[]> getContentsTask = GetURLContentsAsync(url);
                //byte[] urlContents = await getContentsTask;
                //</snippet21>

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


        //<snippet18>
        private async Task<byte[]> GetURLContentsAsync(string url)
        //</snippet18>
        {
            // The downloaded resource ends up in the variable named content.
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for
            // the response.                
            //<snippet14>
            using (WebResponse response = await webReq.GetResponseAsync())
            //</snippet14>
                        
            // The previous statement abbreviates the following two statements.

            //<snippet12>
            //Task<WebResponse> responseTask = webReq.GetResponseAsync();
            //using (WebResponse response = await responseTask)
            //</snippet12>
            {
                // Get the data stream that is associated with the specified url.
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Read the bytes in responseStream and copy them to content. 
                    //<snippet15>
                    await responseStream.CopyToAsync(content);
                    //</snippet15>           

                    // The previous statement abbreviates the following two statements.

                    //<snippet17>
                    // CopyToAsync returns a Task, not a Task<T>.
                    //Task copyTask = responseStream.CopyToAsync(content);

                    // When copyTask is completed, content contains a copy of
                    // responseStream.
                    //await copyTask;
                    //</snippet17>
                }
            }
            // Return the result as a byte array.
            return content.ToArray();
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
//</snippet10>
