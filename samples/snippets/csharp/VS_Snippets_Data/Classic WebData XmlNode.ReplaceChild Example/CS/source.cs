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

    //Create a new title element.
    XmlElement elem = doc.CreateElement("title");
    elem.InnerText="The Handmaid's Tale";

    //Replace the title element.
    root.ReplaceChild(elem, root.FirstChild);

    Console.WriteLine("Display the modified XML...");
    doc.Save(Console.Out);

  }
}
   // </Snippet1>

