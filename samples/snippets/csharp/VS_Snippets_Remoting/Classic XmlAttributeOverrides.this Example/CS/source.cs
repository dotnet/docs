using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
// This is the class that will be serialized.
public class Group
{
   public string GroupName;
   [XmlAttribute]
   public int GroupCode;
}

public class Sample
{
public XmlSerializer CreateOverrider()
{
   // Create an XmlSerializer with overriding attributes.
   XmlAttributes attrs = new XmlAttributes();
   XmlAttributeOverrides xOver = new XmlAttributeOverrides();
   
   XmlRootAttribute xRoot = new XmlRootAttribute();
   // Set a new Namespace and ElementName for the root element.
   xRoot.Namespace = "http://www.cpandl.com";
   xRoot.ElementName = "NewGroup";
   attrs.XmlRoot = xRoot;
   
   xOver.Add(typeof(Group), attrs);

   // Get the XmlAttributes object, based on the type.
   XmlAttributes tempAttrs;
   tempAttrs = xOver[typeof(Group)];

   // Print the Namespace and ElementName of the root.
   Console.WriteLine(tempAttrs.XmlRoot.Namespace);
   Console.WriteLine(tempAttrs.XmlRoot.ElementName);

   XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
   return xSer;
}
}
// </Snippet1>

