using System;
using System.Xml;
using System.IO;
using System.Xml.Serialization;


public class dummyclass
{
	static void Main(){}
}
// <Snippet1>
// This is the class that will be serialized.
public class XClass
{
   /* The XML element name will be XName
   instead of the default ClassName. */
   [XmlElement(ElementName = "XName")]
   public string ClassName;
} 
// </Snippet1>
