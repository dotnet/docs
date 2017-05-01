// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main(){
  
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");      

    //Create an attribute collection and remove an attribute
    //from the collection.
    XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;
    attrColl.RemoveAt(0);

    Console.WriteLine("Display the modified XML...\r\n");
    Console.WriteLine(doc.OuterXml);  
  }
}
   // </Snippet1>

