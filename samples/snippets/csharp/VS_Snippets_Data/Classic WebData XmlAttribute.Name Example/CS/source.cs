// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main(){
  
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book xmlns:bk='urn:samples' bk:genre='novel'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");      

    //Create an attribute collection.
    XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;

    Console.WriteLine("Display information on each of the attributes... \r\n");
    foreach (XmlAttribute attr in attrColl){
       Console.Write("{0} = {1}", attr.Name, attr.Value);
       Console.WriteLine("\t namespaceURI=" + attr.NamespaceURI);
    }
  }
}
   // </Snippet1>

