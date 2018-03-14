using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;

namespace SyndicationPersonSnippets
{
    class Program
    {
        public static void Snippet2()
        {
            // <Snippet2>
            SyndicationPerson person = new SyndicationPerson("lene@company.com");
            // </Snippet2>

            // <Snippet3>
            SyndicationPerson person2 = new SyndicationPerson("lene@company.com", "Lene Aalling", "http://lene/Aalling");
            // </Snippet3>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            SyndicationPerson sp = new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg");
            feed.Authors.Add(sp);
            // </Snippet8>
        }

        public static void Snippet9()
        {
            // <Snippet9>
            SyndicationPerson sp = new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg");
            sp.AttributeExtensions.Add(new XmlQualifiedName("myAttribute", ""), "someValue");
            // </Snippet9>
        }

        public static void Snippet10()
        {
            // <Snippet10>
            SyndicationPerson sp = new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg");
            sp.ElementExtensions.Add("simpleString", "", "hello, world!");
            // </Snippet10>
        }

        public static void Snippet11()
        {
            // <Snippet11>
            SyndicationPerson sp = new SyndicationPerson();
            sp.Email = "jesper@contoso.com";
            // </Snippet11>
        }

        public static void Snippet12()
        {
            // <Snippet12>
            SyndicationPerson sp = new SyndicationPerson();
            sp.Name = "Jesper Aaberg";
            // </Snippet12>
        }

        public static void Snippet13()
        {
            // <Snippet13>
            SyndicationPerson sp = new SyndicationPerson();
            sp.Uri = "http://Jesper/Aaberg";
            // </Snippet13>
        }

        public static void Snippet14()
        {
            // <Snippet14>
            SyndicationPerson sp = new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg");
            SyndicationPerson copy = sp.Clone();
            // </Snippet14>
        }

        static void Main(string[] args)
        {
        }
    }
}
