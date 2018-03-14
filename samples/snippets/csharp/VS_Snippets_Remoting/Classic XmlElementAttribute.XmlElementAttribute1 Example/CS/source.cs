using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Transportation
{
   [XmlElement("Cars")]
   public string Vehicles;
}

// </Snippet1>

