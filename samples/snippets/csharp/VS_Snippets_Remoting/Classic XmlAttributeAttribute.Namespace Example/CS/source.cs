using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Car
{
   [XmlAttribute(Namespace = "Make")]
   public string MakerName;

   [XmlAttribute(Namespace = "Model")]
   public string ModelName;
}

// </Snippet1>

