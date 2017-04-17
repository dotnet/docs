// <Snippet1>
using System;
using System.IO;
using System.Xml;
 
public class Sample {

  public static void Main() {
   
    // Create and load the XML document.
    XmlDocument doc = new XmlDocument();
    string xmlString = "<book><title>Oberon's Legacy</title></book>";
    doc.Load(new StringReader(xmlString));
  
    // Create an XML declaration. 
    XmlDeclaration xmldecl;
    xmldecl = doc.CreateXmlDeclaration("1.0",null,null);
    xmldecl.Encoding="UTF-8";
    xmldecl.Standalone="yes";     
      
    // Add the new node to the document.
    XmlElement root = doc.DocumentElement;
    doc.InsertBefore(xmldecl, root);
    
    // Display the modified XML document 
    Console.WriteLine(doc.OuterXml);
      
  }
}
   // </Snippet1>

