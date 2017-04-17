using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// <Snippet1>
public class MyClass
{
   [XmlElement(Form = XmlSchemaForm.Unqualified)]
   public string ClassName;
}

// </Snippet1>

