// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    // Create the XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<items/>");

    // Create a document fragment.
    XmlDocumentFragment docFrag = doc.CreateDocumentFragment();

    // Display the owner document of the document fragment.
    Console.WriteLine(docFrag.OwnerDocument.OuterXml);

    // Add nodes to the document fragment. Notice that the
    // new element is created using the owner document of 
    // the document fragment.
    XmlElement elem = doc.CreateElement("item");
    elem.InnerText = "widget";
    docFrag.AppendChild(elem);

    Console.WriteLine("Display the document fragment...");
    Console.WriteLine(docFrag.OuterXml);
  }
}
   // </Snippet1>

