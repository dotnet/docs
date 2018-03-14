// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {

    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book xmlns:bk='urn:samples'>" +
                "<bk:ISBN>1-861001-57-5</bk:ISBN>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    // Display information on the ISBN element.
    XmlElement elem = (XmlElement) doc.DocumentElement.FirstChild;
    Console.Write("{0} = {1}", elem.Name, elem.InnerText);
    Console.WriteLine("\t namespaceURI=" + elem.NamespaceURI);

  }
}
   // </Snippet1>

