// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {

    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    XmlElement root = doc.DocumentElement;

    // Check to see if the element has a genre attribute.
    if (root.HasAttribute("genre")){
      XmlAttribute attr = root.GetAttributeNode("genre");
      Console.WriteLine(attr.Value);
   }

  }
}
   // </Snippet1>

