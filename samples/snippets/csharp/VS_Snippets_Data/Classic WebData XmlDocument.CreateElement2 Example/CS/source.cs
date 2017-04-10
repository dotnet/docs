// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {

    // Create the XmlDocument.
    XmlDocument doc = new XmlDocument();
    string xmlData = "<book xmlns:bk='urn:samples'></book>";

    doc.Load(new StringReader(xmlData));

    // Create a new element and add it to the document.
    XmlElement elem = doc.CreateElement("bk", "genre", "urn:samples");
    elem.InnerText = "fantasy";
    doc.DocumentElement.AppendChild(elem);

    Console.WriteLine("Display the modified XML...");
    doc.Save(Console.Out);

  }
}
   // </Snippet1>

