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

    // Display the DocumentType.
    Console.WriteLine(doc.DocumentType.OuterXml);

  }
}
   // </Snippet1>

