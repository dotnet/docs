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
     //Use indenting for readability.
     writer.Formatting = Formatting.Indented;

     //Write the XML delcaration 
     writer.WriteStartDocument();

     //Write the ProcessingInstruction node.
     String PItext="type=\"text/xsl\" href=\"book.xsl\"";
     writer.WriteProcessingInstruction("xml-stylesheet", PItext);

     //Write the DocumentType node.
     writer.WriteDocType("book", null , null, "<!ENTITY h \"hardcover\">");
        
     //Write a Comment node.
     writer.WriteComment("sample XML");
    
     //Write the root element.
     writer.WriteStartElement("book");

     //Write the genre attribute.
     writer.WriteAttributeString("genre", "novel");
    
     //Write the ISBN attribute.
     writer.WriteAttributeString("ISBN", "1-8630-014");

     //Write the title.
     writer.WriteElementString("title", "The Handmaid's Tale");
              
     //Write the style element.
     writer.WriteStartElement("style");
     writer.WriteEntityRef("h");
     writer.WriteEndElement(); 

     //Write the price.
     writer.WriteElementString("price", "19.95");

     //Write CDATA.
     writer.WriteCData("Prices 15% off!!");

     //Write the close tag for the root element.
     writer.WriteEndElement();
             
     writer.WriteEndDocument();

     //Write the XML to file and close the writer.
     writer.Flush();
     writer.Close();  

     //Load the file into an XmlDocument to ensure well formed XML.
     XmlDocument doc = new XmlDocument();
     //Preserve white space for readability.
     doc.PreserveWhitespace = true;
     //Load the file.
     doc.Load(filename);  
    
     //Display the XML content to the console.
     Console.Write(doc.InnerXml);  

  }

}
   // </Snippet1>

