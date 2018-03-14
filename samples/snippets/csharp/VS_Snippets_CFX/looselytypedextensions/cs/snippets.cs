using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Microsoft.Syndication.Samples
{
    class Snippets
    {
        public static void Snippet1()
        {
            //  <Snippet1>
            SyndicationFeed feed = new SyndicationFeed();

            // Add several different types of element extensions
            feed.ElementExtensions.Add("simpleString", "", "hello, world!");
            feed.ElementExtensions.Add("simpleString", "", "another simple string");

            // DataContractExtension is a user-defined type marked with the DataContractAttribute
            feed.ElementExtensions.Add( new DataContractExtension() {Key = "X", Value = 4});

            // XmlSerializerExtension is a user-defined type that defines a ToString() method
            feed.ElementExtensions.Add( new XmlSerializerExtension() {Key = "Y", Value = 8}, new XmlSerializer(typeof(XmlSerializerExtension)));

            feed.ElementExtensions.Add(new XElement("xElementExtension", new XElement("Key", new XAttribute("attr1", "someValue"), "Z"),
                new XElement("Value", new XAttribute("attr1", "someValue"), "15")).CreateReader());
            //  </Snippet1>
        }

        public static void Snippet2()
        {
            //  <Snippet2>
            SyndicationItem item = new SyndicationItem();

            // Add several different types of element extensions
            item.ElementExtensions.Add("simpleString", "", "hello, world!");
            item.ElementExtensions.Add("simpleString", "", "another simple string");

            // DataContractExtension is a user-defined type marked with the DataContractAttribute
            item.ElementExtensions.Add(new DataContractExtension() { Key = "X", Value = 4 });

            // XmlSerializerExtension is a user-defined type that defines a ToString() method
            item.ElementExtensions.Add(new XmlSerializerExtension() { Key = "Y", Value = 8 }, new XmlSerializer(typeof(XmlSerializerExtension)));

            item.ElementExtensions.Add(new XElement("xElementExtension", new XElement("Key", new XAttribute("attr1", "someValue"), "Z"),
                new XElement("Value", new XAttribute("attr1", "someValue"), "15")).CreateReader());
            //  </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            SyndicationItem item = new SyndicationItem();
            item.AttributeExtensions.Add(new XmlQualifiedName("myAttribute", ""), "someValue");
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            SyndicationLink link = new SyndicationLink(new Uri("http://server/link"));
            link.AttributeExtensions.Add(new XmlQualifiedName("myAttribute", ""), "someValue");
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            SyndicationLink link = new SyndicationLink();
            link.ElementExtensions.Add("simpleString", "", "hello, world!");
            // </Snippet5>
        }
    }
}
