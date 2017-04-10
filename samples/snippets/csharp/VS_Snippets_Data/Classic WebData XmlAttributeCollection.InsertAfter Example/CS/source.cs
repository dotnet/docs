// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main(){
  
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");      

    //Create a new attribute.
    XmlAttribute newAttr = doc.CreateAttribute("genre");
    newAttr.Value = "novel";

    //Create an attribute collection and add the new attribute
    //to the collection.
    XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;
    attrColl.InsertAfter(newAttr, attrColl[0]);

    Console.WriteLine("Display the modified XML...\r\n");
    Console.WriteLine(doc.OuterXml);  
  }
}
   // </Snippet1>

