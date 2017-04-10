using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Schema;

public class Class1
{
    public void Method1()
    {
        // <Snippet1>
        XmlTextReader reader = new XmlTextReader("myfile.xml");
        XmlNamespaceManager nsmanager = new XmlNamespaceManager(reader.NameTable);
        nsmanager.AddNamespace("msbooks", "www.microsoft.com/books");
        nsmanager.PushScope();
        nsmanager.AddNamespace("msstore", "www.microsoft.com/store");
        while (reader.Read())
        {
            Console.WriteLine("Reader Prefix:{0}", reader.Prefix);
            Console.WriteLine("XmlNamespaceManager Prefix:{0}",
            nsmanager.LookupPrefix(nsmanager.NameTable.Get(reader.NamespaceURI)));
        }
        // </Snippet1>
    }
}

