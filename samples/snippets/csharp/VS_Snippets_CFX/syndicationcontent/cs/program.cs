using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;

namespace TextSyndicationContentSnippets
{
    class Program
    {
        public static void Snippet0()
        {
            // <Snippet0>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);

            feed.Copyright = new TextSyndicationContent("Copyright 2007");
            feed.Description = new TextSyndicationContent("This is a sample feed");

            TextSyndicationContent textContent = new TextSyndicationContent("Some text content");
            SyndicationItem item = new SyndicationItem("Item Title", textContent, new Uri("http://server/items"), "ItemID", DateTime.Now);
            // </Snippet0>
        }

        public static void Snippet1()
        {
            // <Snippet1>
            TextSyndicationContent textContent = new TextSyndicationContent("Some text content");
            // </Snippet1>

            // <Snippet2>
            TextSyndicationContent textContent2 = new TextSyndicationContent("Some text content", TextSyndicationContentKind.Plaintext);
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            UrlSyndicationContent urlContent = new UrlSyndicationContent(new Uri("http://localhost/content"), "text/html");
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            // </Snippet4>
        }


        static void Main(string[] args)
        {
        }
    }
}
