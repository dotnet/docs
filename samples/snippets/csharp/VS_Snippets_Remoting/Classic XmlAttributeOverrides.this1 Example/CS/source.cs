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
   XmlAttributeOverrides xOver = new XmlAttributeOverrides();

   /* Create an XmlAttributeAttribute object and set the 
   AttributeName property. */
   XmlAttributeAttribute xAtt = new XmlAttributeAttribute();
   xAtt.AttributeName = "Code";

   /* Create a new XmlAttributes object and set the 
   XmlAttributeAttribute object to the XmlAttribute property. */
   XmlAttributes attrs = new XmlAttributes();
   attrs.XmlAttribute = xAtt;

   /* Add the XmlAttributes to the XmlAttributeOverrides object. The
   name of the overridden attribute must be specified. */
   xOver.Add(typeof(Group), "GroupCode", attrs);


   // Get the XmlAttributes object for the type and member.
   XmlAttributes tempAttrs;
   tempAttrs = xOver[typeof(Group), "GroupCode"];
   Console.WriteLine(tempAttrs.XmlAttribute.AttributeName);

   // Create the XmlSerializer instance and return it.
   XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
   return xSer;
}
}
// </Snippet1>

