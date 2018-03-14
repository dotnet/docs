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
    doc.LoadXml("<bookstore>" +
                "<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>" +
                "</bookstore>");

    //Create a reader.
    XmlTextReader reader = new XmlTextReader("cd.xml");
    reader.MoveToContent(); //Move to the cd element node.

    //Create a node representing the cd element node.
    XmlNode cd = doc.ReadNode(reader);

    //Insert the new node into the document.
    doc.DocumentElement.AppendChild(cd); 
    
    Console.WriteLine("Display the modified XML...");
    doc.Save(Console.Out);

  }
}
// </Snippet1>

