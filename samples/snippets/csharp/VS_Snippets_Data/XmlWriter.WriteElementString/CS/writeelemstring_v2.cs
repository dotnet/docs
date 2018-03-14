//<snippet1>
using System;
using System.IO;
using System.Xml;
 
 public class Sample
 {
   private const string m_Document = "sampledata.xml";
 
   public static void Main() {
   
      XmlWriter writer = null;

      try {
     
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        writer = XmlWriter.Create (m_Document, settings);
           
        writer.WriteComment("sample XML fragment");
     
        // Write an element (this one is the root).
        writer.WriteStartElement("book");
 
        // Write the namespace declaration.
        writer.WriteAttributeString("xmlns", "bk", null, "urn:samples");
    
        // Write the genre attribute.
        writer.WriteAttributeString("genre", "novel");
         
        // Write the title.
        writer.WriteStartElement("title");
        writer.WriteString("The Handmaid's Tale");
        writer.WriteEndElement();
               
        // Write the price.
        writer.WriteElementString("price", "19.95");
      
        // Lookup the prefix and write the ISBN element.
        string prefix = writer.LookupPrefix("urn:samples");
        writer.WriteStartElement(prefix, "ISBN", "urn:samples");
        writer.WriteString("1-861003-78");
        writer.WriteEndElement();

        // Write the style element (shows a different way to handle prefixes).
        writer.WriteElementString("style", "urn:samples", "hardcover");
 
        // Write the close tag for the root element.
        writer.WriteEndElement();
               
        // Write the XML to file and close the writer.
        writer.Flush();
        writer.Close();
      }

      finally {
        if (writer != null)
           writer.Close();
     } 
   }
 
 }
//</snippet1>