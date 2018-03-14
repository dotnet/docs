// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {

    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "</book>");

    XmlNode root = doc.DocumentElement;

    //Create a new node.
    XmlElement elem = doc.CreateElement("price");
    elem.InnerText="19.95";

    //Add the node to the document.
    root.InsertAfter(elem, root.FirstChild);

    Console.WriteLine("Display the modified XML...");
    doc.Save(Console.Out);

  }
}
   // </Snippet1>

