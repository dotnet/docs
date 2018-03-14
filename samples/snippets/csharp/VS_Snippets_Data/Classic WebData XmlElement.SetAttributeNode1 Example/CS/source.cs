// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {

    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    XmlElement root = doc.DocumentElement;

    // Add a new attribute.
    XmlAttribute attr = root.SetAttributeNode("genre", "urn:samples");
    attr.Value="novel";

    Console.WriteLine("Display the modified XML...");
    Console.WriteLine(doc.InnerXml);

  }
}
   // </Snippet1>

