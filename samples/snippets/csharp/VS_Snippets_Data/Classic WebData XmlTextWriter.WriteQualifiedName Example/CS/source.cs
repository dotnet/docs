// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  private const string filename = "sampledata.xml";

  public static void Main()
  {
     XmlTextWriter writer = null;

     writer = new XmlTextWriter (filename, null);
     // Use indenting for readability.
     writer.Formatting = Formatting.Indented;
        
     // Write the root element.
     writer.WriteStartElement("schema");

     // Write the namespace declarations.
     writer.WriteAttributeString("xmlns", null,"http://www.w3.org/2001/XMLSchema");
     writer.WriteAttributeString("xmlns","po",null,"http://contoso.com/po");

     writer.WriteStartElement("element");

     writer.WriteAttributeString("name", "purchaseOrder");

     // Write the type attribute.
     writer.WriteStartAttribute(null,"type", null);
     writer.WriteQualifiedName("PurchaseOrder", "http://contoso.com/po");
     writer.WriteEndAttribute();

     writer.WriteEndElement();

     // Write the close tag for the root element.
     writer.WriteEndElement();
             
     // Write the XML to file and close the writer.
     writer.Flush();
     writer.Close();  

     // Read the file back in and parse to ensure well formed XML.
     XmlDocument doc = new XmlDocument();
     // Preserve white space for readability.
     doc.PreserveWhitespace = true;
     // Load the file.
     doc.Load(filename);
    
     // Write the XML content to the console.
     Console.Write(doc.InnerXml);

  }

}
   // </Snippet1>

