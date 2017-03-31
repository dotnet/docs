//  Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Microsoft.Syndication.Samples
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create an extensible object (in this case, SyndicationFeed). Other extensible types (SyndicationItem,
            //SyndicationCategory, SyndicationPerson, SyndicationLink) follow the same pattern.
            // <Snippet0>
            SyndicationFeed feed = new SyndicationFeed();

            //Attribute extensions are stored in a dictionary indexed by XmlQualifiedName
            feed.AttributeExtensions.Add(new XmlQualifiedName("myAttribute", ""), "someValue");
            // </Snippet0>

            //Add several different types of element extensions.
            feed.ElementExtensions.Add("simpleString", "", "hello, world!");
            feed.ElementExtensions.Add("simpleString", "", "another simple string");


            feed.ElementExtensions.Add( new DataContractExtension() { Key = "X", Value = 4 } );
            feed.ElementExtensions.Add( new XmlSerializerExtension { Key = "Y", Value = 8 }, new XmlSerializer( typeof( XmlSerializerExtension ) ) );

            feed.ElementExtensions.Add(new XElement("xElementExtension",
                                           new XElement("Key", new XAttribute("attr1", "someValue"), "Z"),
                                           new XElement("Value", new XAttribute("attr1", "someValue"), "15")).CreateReader());

            //Dump the raw feed XML to the console to show how extensions elements appear in the final XML
            Console.WriteLine("Raw XML");
            Console.WriteLine( "-------" );
            DumpToConsole( feed.GetAtom10Formatter() );
            Console.WriteLine(Environment.NewLine);

            //Read in the XML into a new SyndicationFeed to show the "read" path
            Stream inputStream = WriteToMemoryStream(feed.GetAtom10Formatter());
            SyndicationFeed feed2 = SyndicationFeed.Load(new XmlTextReader(inputStream));


            Console.WriteLine("Attribute Extensions");
            Console.WriteLine("--------------------");

            Console.WriteLine( feed.AttributeExtensions[ new XmlQualifiedName( "myAttribute", "" )]);
            Console.WriteLine("");


            Console.WriteLine("Primitive Extensions");
            Console.WriteLine("--------------------");
            foreach( string s in feed2.ElementExtensions.ReadElementExtensions<string>("simpleString", ""))
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("");

            Console.WriteLine("SerializableExtensions");
            Console.WriteLine("----------------------");

            foreach (DataContractExtension dce in feed2.ElementExtensions.ReadElementExtensions<DataContractExtension>("DataContractExtension",
                                                                                                                        "http://schemas.datacontract.org/2004/07/SyndicationExtensions"))
            {
                Console.WriteLine(dce.ToString());
            }

            Console.WriteLine("");

            foreach (XmlSerializerExtension xse in feed2.ElementExtensions.ReadElementExtensions<XmlSerializerExtension>("XmlSerializerExtension", "", new XmlSerializer(typeof(XmlSerializerExtension))))
            {
                Console.WriteLine(xse.ToString());
            }

            Console.WriteLine("");

            Console.WriteLine("XElement Extensions");
            Console.WriteLine("-------------------");

            foreach (SyndicationElementExtension extension in feed2.ElementExtensions.Where<SyndicationElementExtension>(x => x.OuterName == "xElementExtension"))
            {
                XNode xelement = XElement.ReadFrom(extension.GetReader());
                Console.WriteLine(xelement.ToString());
            }

            Console.WriteLine("");

            Console.WriteLine("Reader over all extensions");
            Console.WriteLine("--------------------------");

            XmlReader extensionsReader = feed2.ElementExtensions.GetReaderAtElementExtensions();

            while (extensionsReader.IsStartElement())
            {
                XNode extension = XElement.ReadFrom(extensionsReader);
                Console.WriteLine(extension.ToString());
            }

            Console.ReadLine();

        }

        private static void DumpToConsole( SyndicationFeedFormatter formatter )
        {
            XmlWriter writer = XmlTextWriter.Create(Console.Out, new XmlWriterSettings() { Indent = true });

            formatter.WriteTo(writer);
            writer.Flush();
        }

        private static Stream WriteToMemoryStream(SyndicationFeedFormatter formatter)
        {
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlTextWriter.Create(stream, new XmlWriterSettings() { Indent = true });

            formatter.WriteTo(writer);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}
