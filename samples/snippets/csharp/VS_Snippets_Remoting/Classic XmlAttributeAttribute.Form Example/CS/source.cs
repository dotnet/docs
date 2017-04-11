using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// <Snippet1>
public class Vehicle
{
   [XmlAttribute(Form = XmlSchemaForm.Qualified)]
   public string Maker;
 
   [XmlAttribute(Form = XmlSchemaForm.Unqualified)]
   public string ModelID;
}

// </Snippet1>

