// <Snippet12>
using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Service
{
    // <Snippet0>
    [ServiceContract]
    public interface IBlog
    {
        [OperationContract]
        [WebGet]
        Rss20FeedFormatter GetBlog();
    }
    // </Snippet0>

    // <Snippet1>
    public class BlogService : IBlog
    {
        public Rss20FeedFormatter GetBlog()
        {
            // <Snippet2>
            SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"));
            feed.Authors.Add(new SyndicationPerson("someone@microsoft.com"));
            feed.Categories.Add(new SyndicationCategory("How To Sample Code"));
            feed.Description = new TextSyndicationContent("This is a how to sample that demonstrates how to expose a feed using RSS with WCF");
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
            return new Rss20FeedFormatter(feed);
            // </Snippet5>
        }
    }
    // </Snippet1>

    public class Host
    {
        static void Main(string[] args)
        {
            // <Snippet6>
            Uri baseAddress = new Uri("http://localhost:8000/BlogService");
            WebServiceHost svcHost = new WebServiceHost(typeof(BlogService), baseAddress);
            // </Snippet6>

            try
            {
                 // <Snippet8>
                svcHost.Open();
                Console.WriteLine("Service is running");

                XmlReader reader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog");
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Console.WriteLine(feed.Title.Text);
                Console.WriteLine("Items:");
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine($"Title: {item.Title.Text}");
                    Console.WriteLine("Summary: {0}", ((TextSyndicationContent)item.Summary).Text);
                }
                Console.WriteLine("Press <enter> to quit...");
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