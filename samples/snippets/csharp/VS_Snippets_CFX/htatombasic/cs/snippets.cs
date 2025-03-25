using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace htAtomBasic
{
    class Snippets
    {
        public static void Snippet9()
        {
            // <Snippet9>
            XmlReader reader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog");
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
                Console.WriteLine($"Summary: {((TextSyndicationContent)item.Summary).Text}");
            }
            // </Snippet11>
        }
    }
}
