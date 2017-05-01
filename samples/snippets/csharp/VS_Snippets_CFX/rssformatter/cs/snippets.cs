using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;
using System.Collections.ObjectModel;
using System.Xml;

namespace RssFormatterSnippets
{
    class Snippets
    {
        public static void Snippet0()
        {
            // <Snippet0>
            // <Snippet1>
            SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

	    List<SyndicationItem> items = new List<SyndicationItem>();
	    items.Add(item);
            feed.Items = items;

            XmlWriter rssWriter = XmlWriter.Create("RSS.xml");
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);
            // </Snippet1>
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();
            // </Snippet0>
        }

        public static void Snippet2()
        {
            // <Snippet2>
            SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

 	    List<SyndicationItem> items = new List<SyndicationItem>();
	    items.Add(item);
            feed.Items = items;

            XmlWriter rssWriter = XmlWriter.Create("RSS.xml");
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed, true);
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            // <Snippet4>
            MySyndicationFeed feed = new MySyndicationFeed("Test Feed",
 "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);

            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("This the item summary");

 	    List<SyndicationItem> items = new List<SyndicationItem>();
	    items.Add(item);
            feed.Items = items;

            XmlWriter rssWriter = XmlWriter.Create("Rss.xml");
            Rss20FeedFormatter<MySyndicationFeed> rssFormatter = new Rss20FeedFormatter<MySyndicationFeed>(feed);
            // </Snippet4>
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();
            // </Snippet3>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            MySyndicationFeed feed = new MySyndicationFeed("Test Feed",
 "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);

            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("This the item summary");

 	    List<SyndicationItem> items = new List<SyndicationItem>();
	    items.Add(item);
            feed.Items = items;

            XmlWriter rssWriter = XmlWriter.Create("Rss.xml");
            Rss20FeedFormatter<MySyndicationFeed> rssFormatter = new Rss20FeedFormatter<MySyndicationFeed>(feed, true);
            // </Snippet5>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            // <Snippet8>
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter rssWriter = XmlWriter.Create("RssItem.xml");
            Rss20ItemFormatter formatter = new Rss20ItemFormatter(item);
            // </Snippet8>
            formatter.WriteTo(rssWriter);
            rssWriter.Close();

            // </Snippet7>
        }

        public static void Snippet9()
        {
            // <Snippet9>
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter rssWriter = XmlWriter.Create("RssItem.xml");
            Rss20ItemFormatter formatter = new Rss20ItemFormatter(item, true);
            // </Snippet9>
        }

        public static void Snippet10()
        {
            // <Snippet10>
            // <Snippet11>
            MySyndicationItem item = new MySyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter rssWriter = XmlWriter.Create("RssItem.xml");
            Rss20ItemFormatter<MySyndicationItem> formatter = new Rss20ItemFormatter<MySyndicationItem>(item);
            // </Snippet11>
            formatter.WriteTo(rssWriter);
            rssWriter.Close();
            // </Snippet10>
        }

        public static void Snippet12()
        {
            // <Snippet12>
            MySyndicationItem item = new MySyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter rssWriter = XmlWriter.Create("RssItem.xml");
            Rss20ItemFormatter<MySyndicationItem> formatter = new Rss20ItemFormatter<MySyndicationItem>(item, true);
            // </Snippet12>
        }

        public static void Snippet13()
        {
            // <Snippet13>
            XmlReader rssReader = XmlReader.Create("http://contoso/Feeds/RSS/MyFeed");
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter();
            rssFormatter.ReadFrom(rssReader);
            rssReader.Close();
            // </Snippet13>
        }

        public static void Snippet14()
        {
            // <Snippet14>
            Rss20FeedFormatter myFeedRssFormatter = new Rss20FeedFormatter(typeof(MySyndicationFeed));
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            myFeedRssFormatter.ReadFrom(rssReader);
            rssReader.Close();
            // </Snippet14>
        }

        public static void Snippet15()
        {
            // <Snippet15>
            Rss20FeedFormatter feedFormatter = new Rss20FeedFormatter();
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            if (feedFormatter.CanRead(rssReader))
            {
                feedFormatter.ReadFrom(rssReader);
                rssReader.Close();
            }
            // </Snippet15>
        }

        public static void Snippets16()
        {
            // <Snippet16>
            Rss20ItemFormatter myItemRssFormatter = new Rss20ItemFormatter(typeof(MySyndicationItem));
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Items");
            myItemRssFormatter.ReadFrom(rssReader);
            rssReader.Close();
            // </Snippet16>
        }

        public static void Snippet17()
        {
            // <Snippet17>
            Rss20ItemFormatter itemFormatter = new Rss20ItemFormatter();
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Item");
            if (itemFormatter.CanRead(rssReader))
            {
                itemFormatter.ReadFrom(rssReader);
                rssReader.Close();
            }
            // </Snippet17>
        }

        public static void Snippet18()
        {
            // <Snippet18>
            Rss20ItemFormatter feedFormatter = new Rss20ItemFormatter();
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            if (feedFormatter.CanRead(rssReader))
            {
                feedFormatter.ReadFrom(rssReader);
                rssReader.Close();
            }
            // </Snippet18>
        }

        public static void Snippet19()
        {
            // <Snippet19>
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            XmlWriter rssWriter = XmlWriter.Create("RSS.xml");
            Rss20ItemFormatter rssFormatter = new Rss20ItemFormatter(item);
            
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();
            // </Snippet19>
        }

    }
}
