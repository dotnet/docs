// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    //Create an XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.Load("2elems.xml");
 
    //Create an attribute.
    XmlAttribute attr;
    attr = doc.CreateAttribute("bk","genre","urn:samples");
    attr.Value = "novel";

    //Add the attribute to the first book.
    XmlElement currNode = (XmlElement) doc.DocumentElement.FirstChild;
    currNode.SetAttributeNode(attr);

    //An attribute cannot be added to two different elements.  
    //You must clone the attribute and add it to the second book.
    XmlAttribute attr2;
    attr2 = (XmlAttribute) attr.CloneNode(true);
    currNode = (XmlElement) doc.DocumentElement.LastChild;
    currNode.SetAttributeNode(attr2);

    Console.WriteLine("Display the modified XML...\r\n");
    XmlTextWriter writer = new XmlTextWriter(Console.Out);
    writer.Formatting = Formatting.Indented;
    doc.WriteContentTo(writer);

  }
}
// </Snippet1>

