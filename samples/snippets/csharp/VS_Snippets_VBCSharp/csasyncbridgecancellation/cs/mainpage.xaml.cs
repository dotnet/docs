
//<snippet1>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Add a using directive for SyndicationClient.
using Windows.Web.Syndication;
// Add a using directive for Tasks.
using System.Threading.Tasks;
// Add a using directive for CancellationToken.
using System.Threading;


namespace BlogFeedWithCancellation
{
    //<snippet3>
    public sealed partial class MainPage : Page
    {
        // ***Declare a System.Threading.CancellationTokenSource.
        CancellationTokenSource cts;
        //</snippet3>

        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsTextBox.Text = "";
            // Prevent unexpected reentrance.
            StartButton.IsEnabled = false;

            //<snippet5>
            // ***Instantiate the CancellationTokenSource.
            cts = new CancellationTokenSource();
            //</snippet5>

            //<snippet6>
            try
            {
                // ***Send a token to carry the message if cancellation is requested.
                await DownloadBlogsAsync(cts.Token);
            }
            // ***Check for cancellations.
            catch (OperationCanceledException)
            {
                // In practice, this catch block often is empty. It is used to absorb
                // the exception,
                ResultsTextBox.Text += "\r\nCancellation exception bubbles up to the caller.";
            }
            // Check for other exceptions.
            catch (Exception ex)
            {
                ResultsTextBox.Text =
                    "Page could not be loaded.\r\n" + "Exception: " + ex.ToString();
            }
            //</snippet6>

            // ***Set the CancellationTokenSource to null when the work is complete.
            cts = null;

            // In case you want to try again.
            StartButton.IsEnabled = true;
        }


        // ***Provide a parameter for the CancellationToken.
        //<snippet2>
        async Task DownloadBlogsAsync(CancellationToken ct)
        {
            Windows.Web.Syndication.SyndicationClient client = new SyndicationClient();

            var uriList = CreateUriList();

            // Force the SyndicationClient to download the information.
            client.BypassCacheOnRetrieve = true;
            
            // The following code avoids the use of implicit typing (var) so that you 
            // can identify the types clearly.

            foreach (var uri in uriList)
            {
                // ***These three lines are combined in the single statement that follows them.
                //IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> feedOp = 
                //    client.RetrieveFeedAsync(uri);
                //Task<SyndicationFeed> feedTask = feedOp.AsTask(ct);
                //SyndicationFeed feed = await feedTask;

                // ***You can combine the previous three steps in one expression.
                //<snippet7>
                SyndicationFeed feed = await client.RetrieveFeedAsync(uri).AsTask(ct);
                //</snippet7>

                DisplayResults(feed);
            }
        }
        //</snippet2>


        
        //<snippet4>
        // ***Add an event handler for the Cancel button.
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                ResultsTextBox.Text += "\r\nDownloads canceled by the Cancel button.";
            }
        }
        //</snippet4>


        List<Uri> CreateUriList()
        {
            // Create a list of URIs.
            List<Uri> uriList = new List<Uri> 
            { 
                new Uri("http://windowsteamblog.com/windows/b/developers/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/extremewindows/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/bloggingwindows/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/business/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/windowsexperience/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/windowssecurity/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/windowshomeserver/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/springboard/atom.aspx")
            };
            return uriList;
        }


        // You can pass the CancellationToken to this method if you think you might use a
        // cancellable API here in the future.
        void DisplayResults(SyndicationFeed sf)
        {
            // Title of the blog.
            ResultsTextBox.Text += sf.Title.Text + "\r\n";

            // Titles and dates for the first three blog posts.
            for (int i = 0; i < (sf.Items.Count < 3 ? sf.Items.Count : 3); i++)    // Is Math.Min better?
            {
                ResultsTextBox.Text += "\t" + sf.Items.ElementAt(i).Title.Text + ", " +
                    sf.Items.ElementAt(i).PublishedDate.ToString() + "\r\n";
            }

            ResultsTextBox.Text += "\r\n";
        }
    }
}
//</snippet1>

// Sample Output:
// Developing for Windows
//     New blog for Windows 8 app developers, 5/1/2012 2:33:02 PM -07:00
//     Trigger-Start Services Recipe, 3/24/2011 2:23:01 PM -07:00
//     Windows Restart and Recovery Recipe, 3/21/2011 2:13:24 PM -07:00

// Extreme Windows Blog
//     Samsung Series 9 27" PLS Display: Amazing Picture, 8/20/2012 2:41:48 PM -07:00
//     NVIDIA GeForce GTX 660 Ti Graphics Card: Affordable Graphics Powerhouse, 8/16/2012 10:56:19 AM -07:00
//     HP Z820 Workstation: Rising To the Challenge, 8/14/2012 1:57:01 PM -07:00

// Blogging Windows
//     Windows Upgrade Offer Registration Now Available, 8/20/2012 1:01:00 PM -07:00
//     Windows 8 has reached the RTM milestone, 8/1/2012 9:00:00 AM -07:00
//     Windows 8 will be available on…, 7/18/2012 1:09:00 PM -07:00

// Windows for your Business
//     What Windows 8 RTM Means for Businesses, 8/1/2012 9:01:00 AM -07:00
//     Higher-Ed Learning with Windows 8, 7/26/2012 12:03:00 AM -07:00
//     Second Public Beta of App-V 5.0 Now Available with Office Integration, 7/24/2012 10:07:26 AM -07:00

// Downloads canceled.