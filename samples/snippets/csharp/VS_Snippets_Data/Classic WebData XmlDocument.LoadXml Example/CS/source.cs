// <Snippet1>
using System;
using System.Xml;

public class Sample {

  public static void Main() {
 
    // Create the XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<item><name>wrench</name></item>");

   // Add a price element.
   XmlElement newElem = doc.CreateElement("price");
   newElem.InnerText = "10.95";
   doc.DocumentElement.AppendChild(newElem);

   XmlWriterSettings settings = new XmlWriterSettings();
   settings.Indent = true;
   // Save the document to a file and auto-indent the output.
   XmlWriter writer = XmlWriter.Create("data.xml", settings);
    doc.Save(writer);
  }
}
   // </Snippet1>

