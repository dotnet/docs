//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
 
     // Create an XmlWriter to write XML fragments.
     XmlWriterSettings settings = new XmlWriterSettings();
     settings.ConformanceLevel = ConformanceLevel.Fragment;
     settings.Indent = true;
     XmlWriter writer = XmlWriter.Create(Console.Out, settings);
     
     // Write an XML fragment.
     writer.WriteStartElement("book");
     writer.WriteElementString("title", "Pride And Prejudice");
     writer.WriteEndElement();
     writer.Flush();

     // Write another XML fragment.
     writer.WriteStartElement("cd");
     writer.WriteElementString("title", "Americana");
     writer.WriteEndElement();
     writer.Flush();  

     // Close the writer.
     writer.Close();
  }
}
//</snippet1>