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
   // Create an XmlAttributeOverrides object. 
   XmlAttributeOverrides xOver = new XmlAttributeOverrides();

   /* Create an XmlAttributeAttribute to override the base class
   object's XmlAttributeAttribute object. Give the overriding object
   a new attribute name ("Code"). */
   XmlAttributeAttribute xAtt = new XmlAttributeAttribute();
   xAtt.AttributeName = "Code";

   /* Create an instance of the XmlAttributes class and set the 
   XmlAttribute property to the XmlAttributeAttribute object. */
   XmlAttributes attrs = new XmlAttributes();
   attrs.XmlAttribute = xAtt;

   /* Add the XmlAttributes object to the XmlAttributeOverrides
      and specify the type and member name to override. */
   xOver.Add(typeof(Group), "GroupCode", attrs);

   XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
   return xSer;
}
}
// </Snippet1>

