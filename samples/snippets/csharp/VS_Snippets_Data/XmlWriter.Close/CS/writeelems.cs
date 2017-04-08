//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {
  
  public static void Main() {
  
     // Create a writer to write XML to the console.
     XmlWriterSettings settings = new XmlWriterSettings();
     settings.Indent = true;
     settings.OmitXmlDeclaration = true;
     XmlWriter writer = XmlWriter.Create(Console.Out, settings);

     // Write the book element.
     writer.WriteStartElement("book");

     // Write the title element.
     writer.WriteStartElement("title");
     writer.WriteString("Pride And Prejudice");
     writer.WriteEndElement();

     // Write the close tag for the root element.
     writer.WriteEndElement();
             
     // Write the XML and close the writer.
     writer.Close();  

  }
}
//</snippet1>