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
	class Snippets
	{
        public static void Snippet9()
        {
            // <Snippet9>
            Uri serviceAddress = new Uri("http://localhost:8000/BlogService/GetBlog");
            // </Snippet9>
        }

        public static void Snippet10()
        {
            Uri serviceAddress = new Uri("http://localhost:8000/BlogService/GetBlog");
            // <Snippet10>
            XmlReader reader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog");
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            // </Snippet10>
            // <Snippet11>
            Console.WriteLine(feed.Title.Text);
            Console.WriteLine("Items:");
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine($"Title: {item.Title.Text}");
                Console.WriteLine("Summary: {0}", ((TextSyndicationContent)item.Summary).Text);
            }
            // </Snippet11>
        }
	}
}
