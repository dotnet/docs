// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main(){

    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    //Create an attribute.
    XmlAttribute attr;
    attr = doc.CreateAttribute("bk","genre","urn:samples");
    attr.Value = "novel";

    //Display the attribute's owner document. Note
    //that although the attribute has not been inserted
    //into the document, it still has an owner document.
    Console.WriteLine(attr.OwnerDocument.OuterXml);

   }
}
   // </Snippet1>

