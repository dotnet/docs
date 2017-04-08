using System;
using System.Xml;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace SyndicationFeedSnippets
{
    class Program
    {
        static void Snippet0()
        {
            // <Snippet0>
            // <Snippet49>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            // </Snippet49>
            // Add a custom attribute.
            XmlQualifiedName xqName = new XmlQualifiedName("CustomAttribute");
            feed.AttributeExtensions.Add(xqName, "Value");

            SyndicationPerson sp = new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg");
            feed.Authors.Add(sp);

            SyndicationCategory category = new SyndicationCategory("FeedCategory", "CategoryScheme", "CategoryLabel");
            feed.Categories.Add(category);

            feed.Contributors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://lene/aaling"));
            feed.Copyright = new TextSyndicationContent("Copyright 2007");
            feed.Description = new TextSyndicationContent("This is a sample feed");

            // Add a custom element.
            XmlDocument doc = new XmlDocument();
            XmlElement feedElement = doc.CreateElement("CustomElement");
            feedElement.InnerText = "Some text";
            feed.ElementExtensions.Add(feedElement);

            feed.Generator = "Sample Code";
            feed.Id = "FeedID";
            feed.ImageUrl = new Uri("http://server/image.jpg");

            TextSyndicationContent textContent = new TextSyndicationContent("Some text content");
            SyndicationItem item = new SyndicationItem("Item Title", textContent, new Uri("http://server/items"), "ItemID", DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item);
            feed.Items = items;

            feed.Language = "en-us";
            feed.LastUpdatedTime = DateTime.Now;

            SyndicationLink link = new SyndicationLink(new Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000);
            feed.Links.Add(link);

            XmlWriter atomWriter = XmlWriter.Create("atom.xml");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();

            XmlWriter rssWriter = XmlWriter.Create("rss.xml");
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();

            // </Snippet0>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            List<SyndicationItem> items = new List<SyndicationItem>();
            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Summary = new TextSyndicationContent("This is Item 1's summary");
            item1.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Summary = new TextSyndicationContent("This is Item 2's summary");
            item2.Authors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed(items);

            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            SyndicationFeed feed = new SyndicationFeed("My Data Feed", "This is a sample feed", new Uri("http://localhost/MyDataService"));
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            List<SyndicationItem> items = new List<SyndicationItem>();
            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Summary = new TextSyndicationContent("This is Item 1's summary");
            item1.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Summary = new TextSyndicationContent("This is Item 2's summary");
            item2.Authors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed("My Data Feed", "This is a sample feed", new Uri("http://localhost/MyDataService"), items);
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            SyndicationFeed feed = new SyndicationFeed("My Data Feed", "This is a sample feed", new Uri("http://localhost/MyDataService"), "Feed ID", DateTime.Now);
            // </Snippet6>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            List<SyndicationItem> items = new List<SyndicationItem>();

            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Summary = new TextSyndicationContent("This is Item 1's summary");
            item1.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Summary = new TextSyndicationContent("This is Item 2's summary");
            item2.Authors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed("My Data Feed", "This is a sample feed", new Uri("http://localhost/MyDataService"), "Feed ID", DateTime.Now, items);
            // </Snippet7>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));           
            // </Snippet8>
        }

        public static void Snippet9()
        {
            // <Snippet9>
            XmlReader reader = XmlReader.Create("http://localhost/feeds/serializedFeed.xml");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            // </Snippet9>
        }

        public static void Snippet10()
        {
            // <Snippet10>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Categories.Add(new SyndicationCategory("MyFeedCategory"));
            // </Snippet10>
        }

        public static void Snippet11()
        {
            // <Snippet11>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Contributors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            // </Snippet11>
        }

        public static void Snippet12()
        {
            // <Snippet12>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Copyright = new TextSyndicationContent("Copyright 2007");
            // </Snippet12>
        }

        public static void Snippet13()
        {
            // <Snippet13>
            List<SyndicationItem> items = new List<SyndicationItem>();

            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed(items);
            feed.Description = new TextSyndicationContent("This is a feed description");
            // </Snippet13>
        }

        public static void Snippet39()
        {
            // <Snippet39>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Generator = "Generator Name or Description";
            // </Snippet39>
        }

        public static void Snippet40()
        {
            // <Snippet40>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Id = "SyndicationFeedId";
            // </Snippet40>
        }

        public static void Snippet41()
        {
            // <Snippet41>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.ImageUrl = new Uri("http://contoso/images/TestFeedImage");
            // </Snippet41>
        }

        public static void Snippet42()
        {
            // <Snippet42>
            List<SyndicationItem> items = new List<SyndicationItem>();

            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed();
            feed.Items = items;
            // </Snippet42>
        }

        public static void Snippet43()
        {
            // <Snippet43>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Language = "en-us";
            // </Snippet43>
        }

        public static void Snippet44()
        {
            // <Snippet44>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.LastUpdatedTime = DateTimeOffset.Now;
            // </Snippet44>
        }

        public static void Snippet45()
        {
            // <Snippet45>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            feed.Links.Add(new SyndicationLink(new Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000));
            // </Snippet45>
        }

        public static void Snippet46()
        {
            // <Snippet46>
            SyndicationFeed feed = new SyndicationFeed();
            feed.Title = new TextSyndicationContent("My Feed Title");
            // </Snippet46>
        }

        public static void Snippet47()
        {
            // <Snippet47>
            SyndicationFeed feed = new SyndicationFeed();
            SyndicationFeed clonedFeed = feed.Clone(true);
            // </Snippet47>
        }

        public static void Snippet48()
        {
            // <Snippet48>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            Uri baseUri = feed.BaseUri;
            // </Snippet48>
        }

        public static void Snippet50()
        {
            // <Snippet50>
            List<SyndicationItem> items = new List<SyndicationItem>();
            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Summary = new TextSyndicationContent("This is Item 1's summary");
            item1.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Summary = new TextSyndicationContent("This is Item 2's summary");
            item2.Authors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now, items);
            // </Snippet50>
        }

        public static void Snippet51()
        {
            // <Snippet51>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            // ...
            XmlWriter xmlWriter = XmlWriter.Create("TestRSSFile.xml");
            feed.SaveAsRss20(xmlWriter);
            // </Snippet51>
        }

        public static void Snippet52()
        {
            // <Snippet52>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            // ...
            XmlWriter xmlWriter = XmlWriter.Create("TestAtomFile.xml");
            feed.SaveAsAtom10(xmlWriter);
            // </Snippet52>
        }

        public static XmlObjectSerializer GetXmlObjectSerializer()
        {
            object dummy = new object();
            return (XmlObjectSerializer)dummy;
        }
         static void Main(string[] args)
        {
        }

    }
}
