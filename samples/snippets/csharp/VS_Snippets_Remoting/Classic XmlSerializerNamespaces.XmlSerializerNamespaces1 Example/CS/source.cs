using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Sample
{
// <Snippet1>
private XmlSerializerNamespaces CreateFromQNames()
{
   XmlQualifiedName q1 = 
   new XmlQualifiedName("money", "http://www.cohowinery.com");
        
   XmlQualifiedName q2 = 
   new XmlQualifiedName("books", "http://www.cpandl.com");
        
   XmlQualifiedName[] names = {q1, q2};

   return new XmlSerializerNamespaces(names);
}

// </Snippet1>
}
