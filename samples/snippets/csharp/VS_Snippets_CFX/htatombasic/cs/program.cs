﻿// <Snippet12>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Xml;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace Service
{
    // <Snippet0>
    [ServiceContract]
    public interface IBlog
    {
        [OperationContract]
        [WebGet]
        Atom10FeedFormatter GetBlog();
    }
    // </Snippet0>

    // <Snippet1>
    public class BlogService : IBlog
    {
        public Atom10FeedFormatter GetBlog()
        {
            // <Snippet2>
            SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"), "FeedOneID", new DateTimeOffset(DateTime.Now));
            feed.Authors.Add(new SyndicationPerson("someone@microsoft.com"));
            feed.Categories.Add(new SyndicationCategory("How To Sample Code"));
            feed.Description = new TextSyndicationContent("This is a sample that illistrates how to expose a feed using ATOM with WCF");
            // </Snippet2>

            // <Snippet3>
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
            // </Snippet3>
            // <Snippet4>
            List<SyndicationItem> items = new List<SyndicationItem>();

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            feed.Items = items;
            // </Snippet4>
            // <Snippet5>
            return new Atom10FeedFormatter(feed);
            // </Snippet5>
        }
    }
    // </Snippet1>

    public class Host
    {
        static void Main(string[] args)
        {
            // <Snippet6>
            Uri baseAddress = new Uri("http://localhost:8000/BlogService/");
            WebServiceHost svcHost = new WebServiceHost(typeof(BlogService), baseAddress);
            // </Snippet6>
            try
            {
                // <Snippet8>
                svcHost.Open();
                Console.WriteLine("Service is running");

                XmlReader reader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog");
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Console.WriteLine(feed.Title.Text);
                Console.WriteLine("Items:");
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine("Title: {0}", item.Title.Text);
                    Console.WriteLine("Content: {0}", ((TextSyndicationContent)item.Content).Text);
                }
                Console.WriteLine("Press <ENTER> to quit...");
                Console.ReadLine();
                svcHost.Close();
                // </Snippet8>
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                svcHost.Abort();
            }
        }
    }
}
// </Snippet12>