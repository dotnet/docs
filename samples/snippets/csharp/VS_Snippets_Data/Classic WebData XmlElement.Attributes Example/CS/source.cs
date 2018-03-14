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

    // Change the value of the first attribute.
    root.Attributes[0].Value="fiction";

    Console.WriteLine("Display the modified XML...");
    Console.WriteLine(doc.InnerXml);
  }
}
   // </Snippet1>

