//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
 
     XmlWriter writer = null;

     writer = XmlWriter.Create("sampledata.xml");
        
     // Write the root element.
     writer.WriteStartElement("book");

     // Write the xmlns:bk="urn:book" namespace declaration.
     writer.WriteAttributeString("xmlns","bk", null,"urn:book");
  
     // Write the bk:ISBN="1-800-925" attribute.
     writer.WriteAttributeString("ISBN", "urn:book", "1-800-925");

     writer.WriteElementString("price", "19.95");

     // Write the close tag for the root element.
     writer.WriteEndElement();
             
     // Write the XML to file and close the writer.
     writer.Flush();
     writer.Close();  

  }
}
//</snippet1>