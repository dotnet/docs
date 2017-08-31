
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
using System.Threading;

namespace QueueResults
{
    //<snippet1>
    public partial class MainWindow : Window  // Class MainPage in Windows Store app.
    {
        // ***Declare the following variables where all methods can access them. 
        private Task pendingWork = null;   
        private char group = (char)('A' - 1);
        //</snippet1>

        public MainWindow()
        {
            InitializeComponent();
        }


        //<snippet2>
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // ***Verify that each group's results are displayed together, and that
            // the groups display in order, by marking each group with a letter.
            group = (char)(group + 1);
            ResultsTextBox.Text += string.Format("\r\n\r\n#Starting group {0}.", group);

            try
            {
                // *** Pass the group value to AccessTheWebAsync.
                char finishedGroup = await AccessTheWebAsync(group);

                // The following line verifies a successful return from the download and
                // display procedures. 
                ResultsTextBox.Text += string.Format("\r\n\r\n#Group {0} is complete.\r\n", finishedGroup);
            }
            catch (Exception)
            {
                ResultsTextBox.Text += "\r\nDownloads failed.";
            }
        }
        //</snippet2>


        //<snippet3>
        private async Task<char> AccessTheWebAsync(char grp)
        {
            HttpClient client = new HttpClient();

            // Make a list of the web addresses to download.
            List<string> urlList = SetUpURLList();

            // ***Kick off the downloads. The application of ToArray activates all the download tasks.
            Task<byte[]>[] getContentTasks = urlList.Select(url => client.GetByteArrayAsync(url)).ToArray();

            // ***Call the method that awaits the downloads and displays the results.
            // Assign the Task that FinishOneGroupAsync returns to the gatekeeper task, pendingWork.
            pendingWork = FinishOneGroupAsync(urlList, getContentTasks, grp);

            ResultsTextBox.Text += string.Format("\r\n#Task assigned for group {0}. Download tasks are active.\r\n", grp);

            // ***This task is complete when a group has finished downloading and displaying.
            await pendingWork;

            // You can do other work here or just return.
            return grp;
        }
        //</snippet3>


        //<snippet4>
        private async Task FinishOneGroupAsync(List<string> urls, Task<byte[]>[] contentTasks, char grp)
        {
            // ***Wait for the previous group to finish displaying results.
            if (pendingWork != null) await pendingWork;

            int total = 0;

            // contentTasks is the array of Tasks that was created in AccessTheWebAsync.
            for (int i = 0; i < contentTasks.Length; i++)
            {
                // Await the download of a particular URL, and then display the URL and
                // its length.
                byte[] content = await contentTasks[i];
                DisplayResults(urls[i], content, i, grp);
                total += content.Length;
            }

            // Display the total count for all of the websites.
            ResultsTextBox.Text +=
                string.Format("\r\n\r\nTOTAL bytes returned:  {0}\r\n", total);
        }
        //</snippet4>


        // ***Add a parameter for the group label.
        private void DisplayResults(string url, byte[] content, int pos, char grp)
        {
            // Display the length of a website. The string format is designed to be 
            // used with a monospaced font, such as Lucida Console or Global Monospace.

            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            // Display position in the URL list, the URL, and the number of bytes.
            ResultsTextBox.Text += string.Format("\r\n{0}-{1}. {2,-58} {3,8}", grp, pos + 1, displayURL, content.Length);
        }


        private List<string> SetUpURLList()
        {
            List<string> urls = new List<string> 
            { 
                "http://msdn.microsoft.com/en-us/library/hh191443.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/jj155761.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/hh524395.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };
            return urls;
        }
    }
}

