//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
 
    XmlReader reader = XmlReader.Create("test1.xml");
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    XmlWriter writer = XmlWriter.Create(Console.Out);

    while (reader.Read()) {
      if (reader.NodeType == XmlNodeType.Element) {
        writer.WriteStartElement(reader.Name.ToUpper());
        writer.WriteAttributes(reader, false);
        if (reader.IsEmptyElement) writer.WriteEndElement();
      }
      else if (reader.NodeType == XmlNodeType.EndElement) {
        writer.WriteEndElement();
      }
    }
    writer.Close();
    reader.Close();
  }
}
//</snippet1>