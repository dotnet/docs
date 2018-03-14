// <Snippet1>
 using System;
 using System.IO;
 using System.Xml;
 
 public class Sample
 {
   public static void Main()
   {
     
     // Create the XmlDocument.
     XmlDocument doc = new XmlDocument();
     doc.LoadXml("<items/>");

     // Create a document fragment.
     XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
 
     // Set the contents of the document fragment.
     docFrag.InnerXml ="<item>widget</item>";
 
     // Create a deep clone.  The cloned node
     // includes child nodes.
     XmlNode deep = docFrag.CloneNode(true);
     Console.WriteLine("Name: " + deep.Name);
     Console.WriteLine("OuterXml: " + deep.OuterXml);

     // Create a shallow clone.  The cloned node does
     // not include any child nodes.
     XmlNode shallow = docFrag.CloneNode(false);
     Console.WriteLine("Name: " + shallow.Name);
     Console.WriteLine("OuterXml: " + shallow.OuterXml);    
 
   }
 }
// </Snippet1>

