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
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    //Create a deep clone.  The cloned node 
    //includes the child node.
    XmlDocument deep = (XmlDocument) doc.CloneNode(true);
    Console.WriteLine(deep.ChildNodes.Count);

    //Create a shallow clone.  The cloned node does not 
    //include the child node.
    XmlDocument shallow = (XmlDocument) doc.CloneNode(false);
    Console.WriteLine(shallow.Name + shallow.OuterXml);
    Console.WriteLine(shallow.ChildNodes.Count);
    
  }
}
   // </Snippet1>

