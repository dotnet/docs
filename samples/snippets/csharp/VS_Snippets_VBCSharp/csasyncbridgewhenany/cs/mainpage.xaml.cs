
//<snippet4>
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

// Add a using directive for the Tasks.
using System.Threading.Tasks;


namespace WhenAnyBlogReader
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

            // The following code avoids the use of implicit typing (var) so that you 
            // can identify the types clearly.

            //<snippet6>
            try
            {
                //<snippet1>
                IEnumerable<Task<SyndicationFeed>> feedsQuery =
                        from uri in uriList
                        // AsTask changes the returns from RetrieveFeedAsync into tasks.
                        select client.RetrieveFeedAsync(uri).AsTask();

                // Run the query to start all the asynchronous processes.
                List<Task<SyndicationFeed>> blogFeedTasksList = feedsQuery.ToList();
                //</snippet1>

                SyndicationFeed feed;

                // Repeat the following until no tasks remain:
                //    - Grab the first one that finishes.
                //    - Retrieve the results from the task (what the return statement 
                //      in RetrieveFeedAsync returns).
                //    - Remove the task from the list.
                //    - Display the results.
                //<snippet3>
                while (blogFeedTasksList.Count > 0)
                {
                    //<snippet5>
                    Task<SyndicationFeed> nextTask = await Task.WhenAny(blogFeedTasksList);
                    //</snippet5>
                    //<snippet2>
                    feed = await nextTask;                    
                    blogFeedTasksList.Remove(nextTask);
                    //</snippet2>
                    DisplayResults(feed);
                }
                //</snippet3>
            }
            catch (Exception ex)
            {
                ResultsTextBox.Text =
                    "Page could not be loaded.\n\r" + "Exception: " + ex.ToString();
            }
            //</snippet6>

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
//</snippet4>