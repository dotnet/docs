//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
  
     // Create a writer to write XML to the console.
     XmlWriterSettings settings = new XmlWriterSettings();
     settings.Indent = true;
     XmlWriter writer = XmlWriter.Create(Console.Out, settings);

     // Write the root element.
     writer.WriteStartElement("order");

     // Write an element with attributes.
     writer.WriteStartElement("item");
     writer.WriteAttributeString("date", "2/19/01");
     writer.WriteAttributeString("orderID", "136A5");

     // Write a full end element. Because this element has no
     // content, calling WriteEndElement would have written a
     // short end tag '/>'.
     writer.WriteFullEndElement();

     writer.WriteEndElement();
             
     // Write the XML to file and close the writer
     writer.Close();  
  }
}
//</snippet1>