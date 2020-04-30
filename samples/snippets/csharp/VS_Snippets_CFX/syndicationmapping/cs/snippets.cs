using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Xml;
using System.Runtime.Serialization;

namespace FeedMapping
{
    [DataContract]
    public class SomeData
    {
        public SomeData() { }
    }

    class Snippets
    {
        public void Snippet0()
        {
            // <Snippet0>
            SyndicationFeed feed = new SyndicationFeed("My Feed Title", "My Feed Description", new Uri("http://MyFeedURI"));
            feed.Copyright = new TextSyndicationContent("Copyright 2007");
            feed.Language = "EN-US";
            feed.LastUpdatedTime = DateTime.Now;
            feed.Generator = "Sample Code";
            feed.Id = "FeedID";
            feed.ImageUrl = new Uri("http://server/image.jpg");

            SyndicationCategory category = new SyndicationCategory("MyCategory");
            category.Label = "categoryLabel";
            category.Name = "categoryName";
            category.Scheme = "categoryScheme";
            feed.Categories.Add(category);

            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://MyItemURI"));
            item.Authors.Add(new SyndicationPerson("Jesper.Aaberg@contoso.com", "Jesper Aaberg", "http://Contoso/Aaberg"));
            item.Categories.Add(category);
            item.Contributors.Add(new SyndicationPerson("Lene.Aaling@contoso.com", "Lene Aaling", "http://Contoso/Aaling"));
            item.Copyright = new TextSyndicationContent("Copyright 2007");
            item.Id = "ItemID";
            item.LastUpdatedTime = DateTime.Now;
            item.PublishDate = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("Item Summary");

            Collection<SyndicationItem> items = new Collection<SyndicationItem>();
            items.Add(item);
            feed.Items = items;

            SerializeFeed(feed);
            // </Snippet0>
        }

        public void Snippet1()
        {
            SyndicationFeed feed = new SyndicationFeed("My Feed Title", "My Feed Description", new Uri("http://MyFeedURI"));

            // <Snippet1>
            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://MyItemURI"));
            item.Authors.Add(new SyndicationPerson("Jesper.Aaberg@contoso.com", "Jesper Aaberg", "http://Contoso/Aaberg"));
            item.Authors.Add(new SyndicationPerson("Syed.Abbas@contoso.com", "Syed Abbas", "http://Contoso/Abbas"));

            SyndicationCategory category = new SyndicationCategory("MyCategory");
            category.Label = "categoryLabel";
            category.Name = "categoryName";
            category.Scheme = "categoryScheme";

            SyndicationCategory category2 = new SyndicationCategory("MyCategoryTwo");
            category2.Label = "categoryLabel";
            category2.Name = "categoryName";
            category2.Scheme = "categoryScheme";

            item.Categories.Add(category);
            item.Categories.Add(category2);
            item.Contributors.Add(new SyndicationPerson("Lene.Aaling@contoso.com", "Lene Aaling", "http://Contoso/Aaling"));
            item.Contributors.Add(new SyndicationPerson("Kim.Abercrombie@contoso.com", "Kim Abercrombie", "http://Contoso/Abercrombie"));
            item.Copyright = new TextSyndicationContent("Copyright 2007");
            item.Id = "ItemID";
            item.LastUpdatedTime = DateTime.Now;
            item.PublishDate = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("Item Summary");

            Collection<SyndicationItem> items = new Collection<SyndicationItem>();
            items.Add(item);
            feed.Items = items;

            SerializeItem(item);
            // </Snippet1>
        }

        public void Snippet2()
        {
            // <Snippet2>
            SyndicationFeed feed = new SyndicationFeed("My Feed Title", "My Feed Description", new Uri("http://MyFeedURI"));
            feed.Authors.Add(new SyndicationPerson("Jesper.Aaberg@contoso.com", "Jesper Aaberg", "http://Contoso/Aaberg"));
            feed.Authors.Add(new SyndicationPerson("Syed.Abbas@contoso.com", "Syed Abbas", "http://Contoso/Abbas"));

            feed.Contributors.Add(new SyndicationPerson("Lene.Aaling@contoso.com", "Lene Aaling", "http://Contoso/Aaling"));
            feed.Contributors.Add(new SyndicationPerson("Kim.Abercrombie@contoso.com", "Kim Abercrombie", "http://Contoso/Abercrombie"));

            SerializeFeed(feed);
            // </Snippet2>
        }

        public void Snippet3()
        {
            // <Snippet3>
            SyndicationFeed feed = new SyndicationFeed("My Feed Title", "My Feed Description", new Uri("http://MyFeedURI"));
            feed.Links.Add(new SyndicationLink(new Uri("http://contoso/MyLink"), "alternate", "My Link Title", "text/html", 2048));

            SerializeFeed(feed);
            // </Snippet3>
        }

        public void Snippet4()
        {
            // <Snippet4>
            SyndicationFeed feed = new SyndicationFeed("My Feed Title", "My Feed Description", new Uri("http://MyFeedURI"));

            SyndicationCategory category = new SyndicationCategory("MyCategory");
            category.Label = "categoryLabel";
            category.Name = "categoryName";
            category.Scheme = "categoryScheme";
            feed.Categories.Add(category);

            SerializeFeed(feed);
            // </Snippet4>
        }

        public void Snippet5()
        {
            // <Snippet5>
            SyndicationItem htmlItem = new SyndicationItem();
            htmlItem.Content = new TextSyndicationContent("<html> some html </html>", TextSyndicationContentKind.Html);

            SerializeItem(htmlItem);
            // </Snippet5>
        }

        public void Snippet6()
        {
            // <Snippet6>
            SyndicationItem txtItem = new SyndicationItem();
            txtItem.Content = new TextSyndicationContent("Some Plain Text", TextSyndicationContentKind.Plaintext);

            SerializeItem(txtItem);
            // </Snippet6>
        }

        public void Snippet7()
        {
            // <Snippet7>
            SyndicationItem xhtmlItem = new SyndicationItem();
            xhtmlItem.Content = new TextSyndicationContent("<html> some xhtml </html>", TextSyndicationContentKind.XHtml);

            SerializeItem(xhtmlItem);
            // </Snippet7>
        }

        public void Snippet8()
        {
            // <Snippet8>
            SyndicationItem urlItem = new SyndicationItem();
            urlItem.Content = new UrlSyndicationContent(new Uri("http://Contoso/someUrl"), "audio");

            SerializeItem(urlItem);
            // </Snippet8>
        }

        public void Snippet9()
        {
            // <Snippet9>
            SyndicationItem xmlItem = new SyndicationItem();

            xmlItem.Title = new TextSyndicationContent("Xml Item Title");
            xmlItem.Content = new XmlSyndicationContent("mytype", new SyndicationElementExtension(new SomeData()));

            SerializeItem(xmlItem);
            // </Snippet9>
        }

        // <Snippet10>
        public void SerializeFeed(SyndicationFeed feed)
        {
            Atom10FeedFormatter atomFormatter = feed.GetAtom10Formatter();
            Rss20FeedFormatter rssFormatter = feed.GetRss20Formatter();

            XmlWriter atomWriter = XmlWriter.Create("atom.xml");
            XmlWriter rssWriter = XmlWriter.Create("rss.xml");
            atomFormatter.WriteTo(atomWriter);
            rssFormatter.WriteTo(rssWriter);
            atomWriter.Close();
            rssWriter.Close();
        }
        // </Snippet10>

        // <Snippet11>
        public void SerializeItem(SyndicationItem item)
        {
            Atom10ItemFormatter atomFormatter = item.GetAtom10Formatter();
            Rss20ItemFormatter rssFormatter = item.GetRss20Formatter();

            XmlWriter atomWriter = XmlWriter.Create("atom.xml");
            XmlWriter rssWriter = XmlWriter.Create("rss.xml");
            atomFormatter.WriteTo(atomWriter);
            rssFormatter.WriteTo(rssWriter);
            atomWriter.Close();
            rssWriter.Close();
        }
        // </Snippet11>
    }
}
