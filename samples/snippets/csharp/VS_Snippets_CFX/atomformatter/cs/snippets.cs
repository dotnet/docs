using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Collections.ObjectModel;

namespace AtomFeedFormatterSnippets
{
    class Snippets
    {
        public static void Snippet0()
        {
            // <Snippet0>
            SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item);
            feed.Items = items;

            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();
            // </Snippet0>
        }

        public static void Snippet1()
        {
            // <Snippet1>
            XmlReader atomReader = XmlReader.Create("AtomFeed.xml");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter();
            atomFormatter.ReadFrom(atomReader);
            atomReader.Close();
            // </Snippet1>
        }

        public static void Snippet2()
        {
            // <Snippet2>
            MySyndicationFeed feed = new MySyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://someuri"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("This the item summary");

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item);
            feed.Items = items;

            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            Atom10FeedFormatter<MySyndicationFeed> atomFormatter = new Atom10FeedFormatter<MySyndicationFeed>(feed);
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            MySyndicationFeed feed = new MySyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://someuri"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("This the item summary");

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item);
            feed.Items = items;
            
            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            // <Snippet5>
            Atom10FeedFormatter<MySyndicationFeed> atomFormatter = new Atom10FeedFormatter<MySyndicationFeed>(feed);
            // </Snippet5>
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();
            // </Snippet3>
        }

         public static void Snippet7()
        {
            // <Snippet7>
            // <Snippet8>
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://someuri"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter atomWriter = XmlWriter.Create("AtomItem.xml");
            Atom10ItemFormatter formatter = new Atom10ItemFormatter(item);
            // </Snippet8>
            formatter.WriteTo(atomWriter);
            atomWriter.Close();

            // </Snippet7>
        }

        public static void Snippet9()
        {
            // <Snippet9>
            // <Snippet10>
            MySyndicationItem item = new MySyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://someuri"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter atomWriter = XmlWriter.Create("AtomItem.xml");
            Atom10ItemFormatter<MySyndicationItem> formatter = new Atom10ItemFormatter<MySyndicationItem>(item);
            // </Snippet10>
            formatter.WriteTo(atomWriter);
            atomWriter.Close();
            // </Snippet9>
        }

        public static void Snippet11()
        {
            // <Snippet11>
            Atom10FeedFormatter myFeedAtomFormatter = new Atom10FeedFormatter(typeof(MySyndicationFeed));
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            myFeedAtomFormatter.ReadFrom(atomReader);
            atomReader.Close();
            // </Snippet11>
        }

        public static void Snippet12()
        {
            // <Snippet12>
            Atom10FeedFormatter feedFormatter = new Atom10FeedFormatter();
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            if (feedFormatter.CanRead(atomReader))
            {
                feedFormatter.ReadFrom(atomReader);
                atomReader.Close();
            }
            // </Snippet12>
        }

        public static void Snippet13()
        {
            // <Snippet13>
            Atom10ItemFormatter itemFormatter = new Atom10ItemFormatter();
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Item");
            if (itemFormatter.CanRead(atomReader))
            {
                itemFormatter.ReadFrom(atomReader);
                atomReader.Close();
            }
            // </Snippet13>
        }

        public static void Snippet14()
        {
            // <Snippet14>
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            Atom10ItemFormatter atomItemFormatter = new Atom10ItemFormatter(item);
            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            atomItemFormatter.WriteTo(atomWriter);
            atomWriter.Close();
            // </Snippet14>
        }

        public static void Snippet15()
        {
            // <Snippet15>
            Atom10ItemFormatter myItemAtomFormatter = new Atom10ItemFormatter(typeof(MySyndicationItem));
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Items");
            myItemAtomFormatter.ReadFrom(atomReader);
            atomReader.Close();
            // </Snippet15>
        }

    }
}
