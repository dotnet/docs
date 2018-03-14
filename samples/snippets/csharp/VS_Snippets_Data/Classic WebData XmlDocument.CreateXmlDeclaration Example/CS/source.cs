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

    //Create an XML declaration. 
    XmlDeclaration xmldecl;
    xmldecl = doc.CreateXmlDeclaration("1.0",null,null);

    //Add the new node to the document.
    XmlElement root = doc.DocumentElement;
    doc.InsertBefore(xmldecl, root);
        
    Console.WriteLine("Display the modified XML...");        
    doc.Save(Console.Out);
  }
}
   // </Snippet1>

