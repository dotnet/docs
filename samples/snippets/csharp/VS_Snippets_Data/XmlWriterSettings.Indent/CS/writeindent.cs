//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Text;

public class Sample {

  public static void Main() {
  
    XmlWriter writer = null;

    try {

       // Create an XmlWriterSettings object with the correct options. 
       XmlWriterSettings settings = new XmlWriterSettings();
       settings.Indent = true;
       settings.IndentChars = ("\t");
       settings.OmitXmlDeclaration = true;

       // Create the XmlWriter object and write some content.
       writer = XmlWriter.Create("data.xml", settings);
       writer.WriteStartElement("book");
       writer.WriteElementString("item", "tesing");
       writer.WriteEndElement();
	
       writer.Flush();

     } 
     finally  {
        if (writer != null)
          writer.Close();
     }
  } 
} 
//</snippet1>