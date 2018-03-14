using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Class1
{
// <Snippet1>
public void DisplayAttributes(XmlReader reader)
{
  if (reader.HasAttributes)
  {
    Console.WriteLine("Attributes of <" + reader.Name + ">");
    for (int i = 0; i < reader.AttributeCount; i++)
    {
      reader.MoveToAttribute(i);
      Console.Write(" {0}={1}", reader.Name, reader.Value);
    }
    reader.MoveToElement(); //Moves the reader back to the element node.
  }
}
// </Snippet1>
}
