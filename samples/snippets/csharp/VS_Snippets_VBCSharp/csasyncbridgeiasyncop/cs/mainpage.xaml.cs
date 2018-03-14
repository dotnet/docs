
//<snippet10>
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


namespace SequentialBlogReader
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsTextBox.Text = "";

            // Disable the button until the operation is complete.
            StartButton.IsEnabled = false;

            Windows.Web.Syndication.SyndicationClient client = new SyndicationClient();

            // Force the SyndicationClient to download the information.
            client.BypassCacheOnRetrieve = true;

            var uriList = CreateUriList();

            try
            {
                //<snippet7>
                IEnumerable<IAsyncOperationWithProgress<SyndicationFeed, 
                    RetrievalProgress>> feedsQuery = from uri in uriList
                                                     select client.RetrieveFeedAsync(uri);
                //</snippet7>

                // Run the query to start all the asynchronous processes.
                //<snippet8>
                List<IAsyncOperationWithProgress<SyndicationFeed, 
                    RetrievalProgress>> blogFeedOpsList = feedsQuery.ToList();
                //</snippet8>

                //<snippet9>
                SyndicationFeed feed;
                foreach (var blogFeedOp in blogFeedOpsList)
                {
                    // The await operator retrieves the final result (a SyndicationFeed instance)
                    // from each IAsyncOperation instance.
                    feed = await blogFeedOp;
                    DisplayResults(feed);
                }
                //</snippet9>
            }
            catch (Exception ex)
            {
                ResultsTextBox.Text =
                    "Page could not be loaded.\n\r" + "Exception: " + ex.ToString();
            }

            // Reenable the button in case you want to run the operation again.
            StartButton.IsEnabled = true;
        }

        List<Uri> CreateUriList()
        {
            // Create a list of URIs.
            List<Uri> uriList = new List<Uri> 
            { 
                new Uri("http://windowsteamblog.com/windows/b/developers/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/extremewindows/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/bloggingwindows/atom.aspx"),
                new Uri("http://windowsteamblog.com/windows/b/springboard/atom.aspx")
            };
            return uriList;
        }


        void DisplayResults(SyndicationFeed sf)
        {
            // Title of the blog.
            ResultsTextBox.Text += sf.Title.Text + "\r\n";

            // Titles and dates for blog posts.
            foreach (SyndicationItem item in sf.Items)
            {
                ResultsTextBox.Text += "\t" + item.Title.Text + ", " +
                                    item.PublishedDate.ToString() + "\r\n";
            }
            ResultsTextBox.Text += "\r\n";
        }
    }
}
//</snippet10>