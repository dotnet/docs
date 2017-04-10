using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Sample
{
// <Snippet1>
private XmlSerializerNamespaces AddNamespaces()
{
   XmlSerializerNamespaces xmlNamespaces = 
   new XmlSerializerNamespaces();

   // Add three prefix-namespace pairs.
   xmlNamespaces.Add("money", "http://www.cpandl.com");
   xmlNamespaces.Add("books", "http://www.cohowinery.com");
   xmlNamespaces.Add("software", "http://www.microsoft.com");

   return xmlNamespaces;
}

// </Snippet1>
}
