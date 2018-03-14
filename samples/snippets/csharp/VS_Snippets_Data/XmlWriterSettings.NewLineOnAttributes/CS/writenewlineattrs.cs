using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
  
    XmlWriter writer = null;

    try {
//<snippet1>
XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;
settings.OmitXmlDeclaration = true;
settings.NewLineOnAttributes = true;
       
writer = XmlWriter.Create(Console.Out, settings);

writer.WriteStartElement("order");
writer.WriteAttributeString("orderID", "367A54");
writer.WriteAttributeString("date", "2001-05-03");
writer.WriteElementString("price", "19.95");
writer.WriteEndElement();
	
writer.Flush();
//</snippet1>
     } 
     finally  {
        if (writer != null)
          writer.Close();
     }
  } 
} 