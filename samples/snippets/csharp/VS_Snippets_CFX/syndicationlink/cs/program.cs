using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;

namespace SyndicationLinkSnippets
{
    class Program
    {
        public static void Snippet0()
        {
            // <Snippet0>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);

            SyndicationLink link = new SyndicationLink(new Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000);
            feed.Links.Add(link);
            // </Snippet0>
        }

        public static void Snippet1()
        {
            // <Snippet1>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);

            SyndicationLink link = new SyndicationLink(new Uri("http://server/link"));
            feed.Links.Add(link);
            // </Snippet1>

        }

        public static void Snippet4()
        {
            // <Snippet4>
            SyndicationLink link = SyndicationLink.CreateAlternateLink(new Uri("http://server/link"));
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            SyndicationLink link = SyndicationLink.CreateAlternateLink(new Uri("http://server/link"), "text/html");
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            SyndicationLink link = SyndicationLink.CreateMediaEnclosureLink(new Uri("http://server/link"), "audio/mpeg", 100000);
            // </Snippet6>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            SyndicationLink link = SyndicationLink.CreateSelfLink(new Uri("http://server/link"));
            // </Snippet7>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            SyndicationLink link = SyndicationLink.CreateSelfLink(new Uri("http://server/link"), "text/html");
            // </Snippet8>
        }




        static void Main(string[] args)
        {
        }
    }
}
