using System;
using System.Xml;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace htAtomRss
{
    class Snippets
    {
        public static void Snippet9()
        {
            // <Snippet9>
            XmlReader reader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog?format=atom");
            // </Snippet9>
            // <Snippet10>
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            // </Snippet10>
            // <Snippet11>
            Console.WriteLine(feed.Title.Text);
            Console.WriteLine("Items:");
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine($"Title: {item.Title.Text}");
                Console.WriteLine($"Content: {((TextSyndicationContent)item.Content).Text}");
            }
            // </Snippet11>
        }
    }
}
