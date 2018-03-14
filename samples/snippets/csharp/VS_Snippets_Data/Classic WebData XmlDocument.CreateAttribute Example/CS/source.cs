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

    //Create an attribute.
    XmlAttribute attr = doc.CreateAttribute("publisher");
    attr.Value = "WorldWide Publishing";
          
    //Add the new node to the document. 
    doc.DocumentElement.SetAttributeNode(attr);
        
    Console.WriteLine("Display the modified XML...");        
    doc.Save(Console.Out);
  }
}
   // </Snippet1>

