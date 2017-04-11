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
    doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" +
                "<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "<style>&h;</style>" +
                "</book>");

    // Display information on the DocumentType node.
    XmlDocumentType doctype = doc.DocumentType;
    Console.WriteLine("Name of the document type:  {0}", doctype.Name);
    Console.WriteLine("The internal subset of the document type:  {0}", doctype.InternalSubset);

  }
}
   // </Snippet1>

