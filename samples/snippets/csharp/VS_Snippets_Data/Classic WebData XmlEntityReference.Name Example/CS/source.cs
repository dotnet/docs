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

    // Display information on the entity reference node.
    XmlEntityReference entref = (XmlEntityReference) doc.DocumentElement.LastChild.FirstChild;
    Console.WriteLine("Name of the entity reference:  {0}", entref.Name);
    Console.WriteLine("The entity replacement text:  {0}", entref.InnerText);
  }
}
   // </Snippet1>

