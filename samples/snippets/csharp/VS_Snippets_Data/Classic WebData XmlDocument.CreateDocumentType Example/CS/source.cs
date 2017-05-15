// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    //Create the XmlDocument.
    XmlDocument doc = new XmlDocument();

    //Create a document type node and  
    //add it to the document.
    XmlDocumentType doctype;
    doctype = doc.CreateDocumentType("book", null, null, "<!ELEMENT book ANY>");
    doc.AppendChild(doctype);

    //Create the root element and 
    //add it to the document.
    doc.AppendChild(doc.CreateElement("book"));

    Console.WriteLine("Display the modified XML...");
    doc.Save(Console.Out);
  }
}
   // </Snippet1>

