using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Xml;
namespace Service
{
    // <Snippet0>
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    public interface IBlog
    {
        [OperationContract]
        [WebGet(UriTemplate="GetBlog?format={format}", BodyStyle=WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter GetBlog(string format);
    }
    // </Snippet0>

    public class BlogService : IBlog
    {
        public SyndicationFeedFormatter GetBlog(string format)
        {
            SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"));
            feed.Authors.Add(new SyndicationPerson("someone@microsoft.com"));
            feed.Categories.Add(new SyndicationCategory("How To Sample Code"));
            feed.Description = new TextSyndicationContent("This is a how to sample illustrating how to expose a feed through RSS and Atom with WCF");

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

            feed.Items = new Collection<SyndicationItem>();
            ((Collection<SyndicationItem>)feed.Items).Add(item1);
            ((Collection<SyndicationItem>)feed.Items).Add(item2);
            ((Collection<SyndicationItem>)feed.Items).Add(item3);

            if (format == "rss")
                return new Rss20FeedFormatter(feed);
            else
                return new Atom10FeedFormatter(feed);
        }
    }

    public class Host
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:8000/BlogService/");

            WebServiceHost svcHost = new WebServiceHost(typeof(BlogService), address);
            try
            {
                svcHost.AddServiceEndpoint(typeof(IBlog), new WebHttpBinding(), "");

                svcHost.Open();
                Console.WriteLine("Service is running");

                ChannelFactory<IBlog> factory = new ChannelFactory<IBlog>(new WebHttpBinding(), new EndpointAddress("http://localhost:8000/BlogService/"));
                WebHttpBehavior behavior = new WebHttpBehavior();
                factory.Endpoint.Behaviors.Add(behavior);
                IBlog client = factory.CreateChannel();
                Rss20FeedFormatter f = (Rss20FeedFormatter)client.GetBlog("rss");

                string serviceAddress = "http://localhost:8000/BlogService/GetBlog?format=atom";
                XmlReader reader = XmlReader.Create(serviceAddress);

                SyndicationFeed feed = SyndicationFeed.Load(reader);

                Console.WriteLine(feed.Title.Text);
                Console.WriteLine("Items:");
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine($"Title: {item.Title.Text}");
                    Console.WriteLine($"Content: {((TextSyndicationContent)item.Content).Text}");
                }

                Console.WriteLine("Press any <enter> to quit...");
                Console.ReadLine();
                svcHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"An exception occurred: {ce.Message}");
                svcHost.Abort();
            }
        }
    }
}
