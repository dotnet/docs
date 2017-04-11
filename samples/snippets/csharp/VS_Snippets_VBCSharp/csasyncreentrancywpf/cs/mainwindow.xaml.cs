
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

// Add the following using directives, and add a reference for System.Net.Http.
using System.Net.Http;
using System.Threading;

namespace WebsiteDownloadWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //<snippet2>
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // This line is commented out to make the results clearer in the output.
            //ResultsTextBox.Text = "";

            try
            {
                await AccessTheWebAsync();
            }
            catch (Exception)
            {
                ResultsTextBox.Text += "\r\nDownloads failed.";
            }
        }
        //</snippet2>


        private async Task AccessTheWebAsync()
        {
            // Declare an HttpClient object.
            HttpClient client = new HttpClient();

            // Make a list of web addresses.
            List<string> urlList = SetUpURLList();

            var total = 0;
            var position = 0;

            foreach (var url in urlList)
            {
                // GetByteArrayAsync returns a task. At completion, the task
                // produces a byte array.
                byte[] urlContents = await client.GetByteArrayAsync(url);

                DisplayResults(url, urlContents, ++position);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the websites.
            ResultsTextBox.Text +=
                string.Format("\r\n\r\nTOTAL bytes returned:  {0}\r\n", total);
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


        private void DisplayResults(string url, byte[] content, int pos)
        {
            // Display the length of each website. The string format is designed
            // to be used with a monospaced font, such as Lucida Console or 
            // Global Monospace.

            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            // Display position in the URL list, the URL, and the number of bytes.
            ResultsTextBox.Text += string.Format("\n{0}. {1,-58} {2,8}", pos, displayURL, content.Length);
        }
    }
}
//</snippet1>
// Output if you choose the Start button just once:

//1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732

//2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273

//3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019

//4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152

//5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959

//6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325

//7. msdn.microsoft.com                                            42963

//8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

//TOTAL bytes returned:  890582


// Sample output for multiple starts:

//1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732

//2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273

//3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019

//1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732

//4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152

//1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732

//2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273

//5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959

//3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019

//2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273

//6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325

//7. msdn.microsoft.com                                            42963

//8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

//TOTAL bytes returned:  890582


//4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152

//3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019

//5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959

//4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152

//6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325

//7. msdn.microsoft.com                                            42963

//8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

//TOTAL bytes returned:  890582


//5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959

//6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325

//7. msdn.microsoft.com                                            42963

//8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

//TOTAL bytes returned:  890582

