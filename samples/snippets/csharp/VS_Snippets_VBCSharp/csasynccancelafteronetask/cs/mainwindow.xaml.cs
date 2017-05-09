
//<snippet7>
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

// Add a using directive and a reference for System.Net.Http.
using System.Net.Http;

// Add the following using directive.
using System.Threading;

namespace CancelAfterOneTask
{
    public partial class MainWindow : Window
    {
        // Declare a System.Threading.CancellationTokenSource.
        CancellationTokenSource cts;

        public MainWindow()
        {
            InitializeComponent();
        }


        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate the CancellationTokenSource.
            cts = new CancellationTokenSource();

            resultsTextBox.Clear();

            try
            {
                await AccessTheWebAsync(cts.Token);
                resultsTextBox.Text += "\r\nDownload complete.";
            }
            catch (OperationCanceledException)
            {
                resultsTextBox.Text += "\r\nDownload canceled.";
            }
            catch (Exception)
            {
                resultsTextBox.Text += "\r\nDownload failed.";
            }

            // Set the CancellationTokenSource to null when the download is complete.
            cts = null;
        }


        // You can still include a Cancel button if you want to.
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }


        // Provide a parameter for the CancellationToken.
        async Task AccessTheWebAsync(CancellationToken ct)
        {
            HttpClient client = new HttpClient();

            // Call SetUpURLList to make a list of web addresses.
            List<string> urlList = SetUpURLList();

            // ***Comment out or delete the loop.
            //foreach (var url in urlList)
            //{
            //    // GetAsync returns a Task<HttpResponseMessage>. 
            //    // Argument ct carries the message if the Cancel button is chosen. 
            //    // ***Note that the Cancel button can cancel all remaining downloads.
            //    HttpResponseMessage response = await client.GetAsync(url, ct);

            //    // Retrieve the website contents from the HttpResponseMessage.
            //    byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

            //    resultsTextBox.Text +=
            //        String.Format("\r\nLength of the downloaded string: {0}.\r\n", urlContents.Length);
            //}

            //<snippet2>
            // ***Create a query that, when executed, returns a collection of tasks.
            IEnumerable<Task<int>> downloadTasksQuery =
                from url in urlList select ProcessURLAsync(url, client, ct);
            //</snippet2>

            //<snippet3>
            // ***Use ToArray to execute the query and start the download tasks. 
            Task<int>[] downloadTasks = downloadTasksQuery.ToArray();
            //</snippet3>

            //<snippet4>
            // ***Call WhenAny and then await the result. The task that finishes 
            // first is assigned to firstFinishedTask.
            Task<int> firstFinishedTask = await Task.WhenAny(downloadTasks);
            //</snippet4>

            //<snippet5>
            // ***Cancel the rest of the downloads. You just want the first one.
            cts.Cancel();
            //</snippet5>

            // ***Await the first completed task and display the results. 
            // Run the program several times to demonstrate that different
            // websites can finish first.
            //<snippet6>
            var length = await firstFinishedTask;
            resultsTextBox.Text += String.Format("\r\nLength of the downloaded website:  {0}\r\n", length);
            //</snippet6>
        }


        //<snippet1>
        // ***Bundle the processing steps for a website into one async method.
        async Task<int> ProcessURLAsync(string url, HttpClient client, CancellationToken ct)
        {
            // GetAsync returns a Task<HttpResponseMessage>. 
            HttpResponseMessage response = await client.GetAsync(url, ct);

            // Retrieve the website contents from the HttpResponseMessage.
            byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

            return urlContents.Length;
        }
        //</snippet1>


        // Add a method that creates a list of web addresses.
        private List<string> SetUpURLList()
        {
            List<string> urls = new List<string> 
            { 
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };
            return urls;
        }
    }
    // Sample output:

    // Length of the downloaded website:  158856

    // Download complete.
}
//</snippet7>
