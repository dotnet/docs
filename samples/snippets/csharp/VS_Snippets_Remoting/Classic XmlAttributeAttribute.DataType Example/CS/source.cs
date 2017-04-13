using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Group{
   [XmlAttribute(DataType = "string")]
   public string Name;
	
   [XmlAttribute (DataType = "base64Binary")]
   public byte[] Hex64Code;
}

// </Snippet1>

