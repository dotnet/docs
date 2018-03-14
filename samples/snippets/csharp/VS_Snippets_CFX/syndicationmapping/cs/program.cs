using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Xml;

namespace FeedMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            //SyndicationFeed feed = new SyndicationFeed("My Feed Title", "My Feed Description", new Uri("http://MyFeedURI"));
            //feed.Copyright = new TextSyndicationContent("Copyright 2007");
            //feed.Language = "EN-US";
            //feed.LastUpdatedTime = DateTime.Now;
            //feed.Generator = "Sample Code";
            //feed.Id = "FeedID";
            //feed.ImageUrl = new Uri("http://server/image.jpg");

            //SyndicationCategory category = new SyndicationCategory("MyCategory");
            //category.Label = "categoryLabel";
            //category.Name = "categoryName";
            //category.Scheme = "categoryScheme";
            //feed.Categories.Add(category);

            //SyndicationCategory category2 = new SyndicationCategory("MyCategoryTwo");
            //category2.Label = "categoryLabel";
            //category2.Name = "categoryName";
            //category2.Scheme = "categoryScheme";
            //feed.Categories.Add(category2);

            //SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://MyItemURI"));
            //item.Authors.Add(new SyndicationPerson("Jesper@Aaberg.com", "Jesper Aaberg", "http://Jesper/Aaberg"));
            //item.Authors.Add(new SyndicationPerson("Syed@Abbas.com", "Syed Abbas", "http://Syed/Abbas"));
            //item.Categories.Add(category);
            //item.Categories.Add(category2);
            //item.Contributors.Add(new SyndicationPerson("Lene@Aaling.com", "Lene Aaling", "http://Lene/Aaling"));
            //item.Contributors.Add(new SyndicationPerson("Kim@Abercrombie.com", "Kim Abercrombie", "http://Kim/Abercrombie"));
            //item.Copyright = new TextSyndicationContent("Copyright 2007");
            //item.Id = "ItemID";
            //item.LastUpdatedTime = DateTime.Now;
            //item.PublishDate = DateTime.Today;
            //item.SourceFeed = feed;
            //item.Summary = new TextSyndicationContent("Item Summary");
            //feed.Items = new Collection<SyndicationItem>();
            //((Collection<SyndicationItem>)feed.Items).Add(item);

            //SyndicationItem htmlItem = new SyndicationItem();
            //htmlItem.Id = "htmlItemId";
            //htmlItem.LastUpdatedTime = DateTime.Now;
            //htmlItem.PublishDate = DateTime.Today;
            //htmlItem.SourceFeed = feed;
            //htmlItem.Summary = new TextSyndicationContent("Html Item Summary");
            //htmlItem.Title = new TextSyndicationContent("Html Item Title");
            //htmlItem.Content = new TextSyndicationContent("<html> some html </html>", TextSyndicationContentKind.Html);
            //((Collection<SyndicationItem>)feed.Items).Add(htmlItem);

            //SyndicationItem urlItem = new SyndicationItem();
            //urlItem.Id = "urlItemId";
            //urlItem.LastUpdatedTime = DateTime.Now;
            //urlItem.PublishDate = DateTime.Today;
            //urlItem.SourceFeed = feed;
            //urlItem.Summary = new TextSyndicationContent("URL Item Summary");
            //urlItem.Title = new TextSyndicationContent("URL Item Title");
            //urlItem.Content = new UrlSyndicationContent(new Uri("http://someUrl"), "audio");
            //((Collection<SyndicationItem>)feed.Items).Add(urlItem);

            //SyndicationItem xmlItem = new SyndicationItem();
            //xmlItem.Id = "urlItemId";
            //xmlItem.LastUpdatedTime = DateTime.Now;
            //xmlItem.PublishDate = DateTime.Today;
            //xmlItem.SourceFeed = feed;
            //xmlItem.Summary = new TextSyndicationContent("URL Item Summary");
            //XmlDocument doc = new XmlDocument();
            //XmlElement xmlElement = doc.CreateElement("MyXmlElement", "http://MyElements");
            //xmlItem.Title = new TextSyndicationContent("Xml Item Title");
            //xmlItem.Content = new XmlSyndicationContent("mytype", new SyndicationElementExtension(xmlElement));
            //((Collection<SyndicationItem>)feed.Items).Add(xmlItem);

            //SyndicationItem xhtmlItem = new SyndicationItem();
            //xhtmlItem.Id = "xhtmlItemId";
            //xhtmlItem.LastUpdatedTime = DateTime.Now;
            //xhtmlItem.PublishDate = DateTime.Today;
            //xhtmlItem.SourceFeed = feed;
            //xhtmlItem.Summary = new TextSyndicationContent("Html Item Summary");
            //xhtmlItem.Title = new TextSyndicationContent("Html Item Title");
            //xhtmlItem.Content = new TextSyndicationContent("<html> some xhtml </html>", TextSyndicationContentKind.XHtml);
            //((Collection<SyndicationItem>)feed.Items).Add(xhtmlItem);

            //SyndicationLink link = new SyndicationLink(new Uri("http://some/link"), "alternate", "Link Title", "text/html", 2048);
            //feed.Links.Add(link);
          
            ///*
            //// Add custom attribute
            //XmlQualifiedName xqName = new XmlQualifiedName("CustomFeedAttribute");
            //feed.AttributeExtensions.Add(xqName, "value");

            //// Add custom element
            //XmlDocument doc = new XmlDocument();
            //XmlElement feedElement = doc.CreateElement("CustomFeedElement", "http://CustomFeeds");
            //feedElement.InnerText = "Feed Element Text";
            //feed.ElementExtensions.Add(feedElement);
            //*/


            //Atom10FeedFormatter atomFormatter = feed.GetAtom10Formatter();
            //Rss20FeedFormatter rssFormatter = feed.GetRss20Formatter();

            //XmlWriter atomWriter = XmlWriter.Create("atom.xml");
            //XmlWriter rssWriter = XmlWriter.Create("rss.xml");
            //atomFormatter.WriteTo(atomWriter);
            //rssFormatter.WriteTo(rssWriter);
            //atomWriter.Close();
            //rssWriter.Close();
        }
    }
}
