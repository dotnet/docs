//<snippet4>
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

// Add the following using directive, and add a reference for System.Net.Http.
using System.Net.Http;


namespace AsyncExample_MultipleTasks
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            //<snippet1>
            resultsTextBox.Clear();
            await CreateMultipleTasksAsync();
            resultsTextBox.Text += "\r\n\r\nControl returned to startButton_Click.\r\n";
            //</snippet1>
        }


        //<snippet3>
        private async Task CreateMultipleTasksAsync()
        {
            // Declare an HttpClient object, and increase the buffer size. The
            // default buffer size is 65,536.
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            // Create and start the tasks. As each task finishes, DisplayResults 
            // displays its length.
            Task<int> download1 = 
                ProcessURLAsync("http://msdn.microsoft.com", client);
            Task<int> download2 = 
                ProcessURLAsync("http://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx", client);
            Task<int> download3 = 
                ProcessURLAsync("http://msdn.microsoft.com/en-us/library/67w7t67f.aspx", client);

            // Await each task.
            int length1 = await download1;
            int length2 = await download2;
            int length3 = await download3;

            int total = length1 + length2 + length3;
            
            // Display the total count for the downloaded websites.
            resultsTextBox.Text +=
                string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);
        }
        //</snippet3>


        //<snippet2>
        async Task<int> ProcessURLAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);
            DisplayResults(url, byteArray);
            return byteArray.Length;
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
        //</snippet2>
    }
}
//</snippet4>