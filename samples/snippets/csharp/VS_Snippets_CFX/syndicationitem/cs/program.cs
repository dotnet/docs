using System;
using System.Xml;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SyndicationItemSnippets
{
    class Program
    {
        public static void Snippet0()
        {
            // <Snippet0>
            // <Snippet2>          
            SyndicationItem item = new SyndicationItem("My Item", "This is some content", new Uri("http://SomeServer/MyItem"), "Item ID", DateTime.Now);
            item.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item.Categories.Add(new SyndicationCategory("Category One"));
            item.Contributors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item.Copyright = new TextSyndicationContent("Copyright 2007");
            item.Links.Add(new SyndicationLink(new Uri("http://OtherServer/Item"), "alternate", "Alternate Link", "text/html", 1000));
            item.PublishDate = new DateTime(2007, 2, 23);
            item.Summary = new TextSyndicationContent("this is a summary for my item");
            // </Snippet2>
            XmlQualifiedName xqName = new XmlQualifiedName("itemAttrib", "http://FeedServer/tags");
            item.AttributeExtensions.Add(xqName, "ItemAttribValue");

            SyndicationFeed feed = new SyndicationFeed();
            Collection<SyndicationItem> items = new Collection<SyndicationItem>();
            items.Add(item);
            feed.Items = items;
            // </Snippet0>
        }

        public static void Snippet1()
        {
            // <Snippet1>
            SyndicationItem item = new SyndicationItem("My Item", "This is some content", new Uri("http://SomeServer/MyItem"));
            item.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item.Categories.Add(new SyndicationCategory("Category One"));
            item.Contributors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item.Copyright = new TextSyndicationContent("Copyright 2007");
            item.Links.Add(new SyndicationLink(new Uri("http://OtherServer/Item"), "alternate", "Alternate Link", "text/html", 1000));
            item.PublishDate = new DateTime(2007, 2, 23);
            item.Summary = new TextSyndicationContent("this is a summary for my item");
            // </Snippet1>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            TextSyndicationContent content = new TextSyndicationContent("This is some text content");
            Uri altLink = new Uri("http://someserver/item");
            SyndicationItem item = new SyndicationItem("Item Title", content, altLink, "Item ID", DateTime.Now);
            // </Snippet3>
        }

        public static void Snippet21()
        {
            // <Snippet21>
            XmlReader reader = XmlReader.Create("http://localhost/items/serializedItem.xml");
            SyndicationItem item = SyndicationItem.Load(reader);
            reader.Close();
            // </Snippet21>
        }

        public static void Snippet22()
        {
            // <Snippet22>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            // </Snippet22>
        }

        public static void Snippet23()
        {
            // <Snippet23>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Categories.Add(new SyndicationCategory("MyFeedCategory"));
            // </Snippet23>
        }

        public static void Snippet24()
        {
            // <Snippet24>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Content = new TextSyndicationContent("This is the content of the syndication item");
            // </Snippet24>
        }

        public static void Snippet25()
        {
            // <Snippet25>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Contributors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            // </Snippet25>
        }

        public static void Snippet26()
        {
            // <Snippet26>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Copyright = new TextSyndicationContent("Copyright 2007 Contoso");
            // </Snippet26>
        }

        public static void Snippet27()
        {
            // <Snippet27>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Id = "ItemID";
            // </Snippet27>
        }

        public static void Snippet28()
        {
            // <Snippet28>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.LastUpdatedTime = DateTimeOffset.Now;
            // </Snippet28>
        }

        public static void Snippet29()
        {
            // <Snippet29>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Links.Add(new SyndicationLink(new Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000));
            // </Snippet29>
        }

        public static void Snippet30()
        {
            // <Snippet30>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.PublishDate = DateTimeOffset.Now;
            // </Snippet30>
        }

        public static void Snippet31()
        {
            // <Snippet31>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"));
            item.Summary = new TextSyndicationContent("This is a syndication item summary");
            // </Snippet31>
        }

        public static void Snippet32()
        {
            // <Snippet32>
            SyndicationItem item = new SyndicationItem();
            item.Title = new TextSyndicationContent("Item Title");
            // </Snippet32>
        }

        public static void Snippet33()
        {
            // <Snippet33>
            SyndicationItem item = new SyndicationItem();
            item.BaseUri = new Uri("http://SomeServer/MyItem");
            // </Snippet33>
        }

        public static void Snippet34()
        {
            // <Snippet34>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            // </Snippet34>
        }

        public static void Snippet35()
        {
            // <Snippet35>
            TextSyndicationContent content = new TextSyndicationContent("Item Content");
            Uri uri = new Uri("http://Item/Alternate/Link");
            SyndicationItem item = new SyndicationItem("Item Title", content, uri, "itemID", DateTimeOffset.Now);
            // </Snippet35>
        }

        public static void Snippet36()
        {
            // <Snippet36>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            item.AddPermalink(new Uri("http://contoso/links/mylink"));
            // </Snippet36>
        }

        public static void Snippet37()
        {
            // <Snippet37>
            XmlReader reader = XmlReader.Create("http://localhost/items/serializedItem.xml");
            MySyndicationItem myItem = SyndicationItem.Load<MySyndicationItem>(reader);
            reader.Close();
            // </Snippet37>
        }

        public static void Snippet38()
        {
            // <Snippet38>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            XmlWriter writer = XmlWriter.Create("outfile.xml");
            item.SaveAsAtom10(writer);
            writer.Close();
            // </Snippet38>
        }

        public static void Snippet39()
        {
            // <Snippet39>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            XmlWriter writer = XmlWriter.Create("outfile.xml");
            item.SaveAsRss20(writer);
            writer.Close();
            // </Snippet39>
        }

        public static void Snippet40()
        {
            // <Snippet40>
            // </Snippet40>
        }

        public static void Snippet41()
        {
            // <Snippet41>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            SyndicationItem clone = item.Clone();
            // </Snippet41>
        }

        public static void Snippet42()
        {
            // <Snippet42>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            Atom10ItemFormatter atomFormatter = item.GetAtom10Formatter();
            XmlWriter writer = XmlWriter.Create("output.xml");
            atomFormatter.WriteTo(writer);
            writer.Close();
            // </Snippet42>
        }

        public static void Snippet43()
        {
            // <Snippet43>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            Rss20ItemFormatter rssFormatter = item.GetRss20Formatter();
            XmlWriter writer = XmlWriter.Create("output.xml");
            rssFormatter.WriteTo(writer);
            writer.Close();
            // </Snippet43>
        }

        public static void Snippet44()
        {
            // <Snippet44>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            Rss20ItemFormatter rssFormatter = item.GetRss20Formatter(true);
            XmlWriter writer = XmlWriter.Create("output.xml");
            rssFormatter.WriteTo(writer);
            writer.Close();
            // </Snippet44>
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
