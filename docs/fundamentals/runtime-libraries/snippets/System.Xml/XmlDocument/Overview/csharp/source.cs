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
    doc.LoadXml("<?xml version='1.0' ?>" +
                "<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    //Display the document element.
    Console.WriteLine(doc.DocumentElement.OuterXml);
 }
}
   // </Snippet1>
