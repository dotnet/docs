using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class MyClass
{
   [XmlElement(IsNullable = false)]
   public string Group;
}

// </Snippet1>

