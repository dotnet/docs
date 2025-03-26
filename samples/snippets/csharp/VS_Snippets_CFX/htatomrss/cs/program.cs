// <Snippet12>
using System;
using System.Xml;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
namespace Service
{
    // <Snippet0>
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    public interface IBlog
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetBlog?format={format}")]
        SyndicationFeedFormatter GetBlog(string format);
    }
    // </Snippet0>

    // <Snippet1>
    public class BlogService : IBlog
    {
        public SyndicationFeedFormatter GetBlog(string format)
        {
            // <Snippet2>
            SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"));
            feed.Authors.Add(new SyndicationPerson("someone@microsoft.com"));
            feed.Categories.Add(new SyndicationCategory("How To Sample Code"));
            feed.Description = new TextSyndicationContent("This is a sample that demonstrates how to expose a feed through RSS and Atom with WCF");
            // </Snippet2>
            // <Snippet3>
            SyndicationItem item1 = new SyndicationItem(
                "Item One",
                "This is the content for item one",
                new Uri("http://localhost/Content/One"),
                "ItemOneID",
                DateTime.Now);

            SyndicationItem item2 = new SyndicationItem(
                "Item Two",
                "This is the content for item two",
                new Uri("http://localhost/Content/Two"),
                "ItemTwoID",
                DateTime.Now);

            SyndicationItem item3 = new SyndicationItem(
                "Item Three",
                "This is the content for item three",
                new Uri("http://localhost/Content/three"),
                "ItemThreeID",
                DateTime.Now);
            // </Snippet3>
            // <Snippet4>
            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            feed.Items = items;
            // </Snippet4>

            // <Snippet5>
            if (format == "rss")
                return new Rss20FeedFormatter(feed);
            else if (format == "atom")
                return new Atom10FeedFormatter(feed);
            else return null;
            // </Snippet5>
        }
    }
    // </Snippet1>

    public class Host
    {
        static void Main(string[] args)
        {
            // <Snippet6>
            Uri address = new Uri("http://localhost:8000/BlogService/");
            WebServiceHost svcHost = new WebServiceHost(typeof(BlogService), address);
            // </Snippet6>
            try
            {
                 // <Snippet8>
                svcHost.Open();
                Console.WriteLine("Service is running");

                Console.WriteLine("Loading feed in Atom 1.0 format.");
                XmlReader atomReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog?format=atom");
                SyndicationFeed atomFeed = SyndicationFeed.Load(atomReader);
                Console.WriteLine(atomFeed.Title.Text);
                Console.WriteLine("Items:");
                foreach (SyndicationItem item in atomFeed.Items)
                {
                    Console.WriteLine($"Title: {item.Title.Text}");
                    Console.WriteLine($"Content: {((TextSyndicationContent)item.Content).Text}");
                }

                Console.WriteLine("Loading feed in RSS 2.0 format.");
                XmlReader rssReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog?format=rss");
                SyndicationFeed rssFeed = SyndicationFeed.Load(rssReader);
                Console.WriteLine(rssFeed.Title.Text);
                Console.WriteLine("Items:");
                foreach (SyndicationItem item in rssFeed.Items)
                {
                    Console.WriteLine($"Title: {item.Title.Text}");
                    // Notice we are using item.Summary here instead of item.Content. This is because
                    // of the differences between Atom 1.0 and RSS 2.0 specs.
                    Console.WriteLine($"Content: {((TextSyndicationContent)item.Summary).Text}");
                }

                Console.WriteLine("Press <ENTER> to quit...");
                Console.ReadLine();
                svcHost.Close();
                // </Snippet8>
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"An exception occurred: {ce.Message}");
                svcHost.Abort();
            }
        }
    }
}
// </Snippet12>