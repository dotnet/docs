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

    // Create a document fragment.
    XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
 
    // Set the contents of the document fragment.
    docFrag.InnerXml ="<item>widget</item>";

    // Display the document fragment.
    Console.WriteLine(docFrag.InnerXml);
  
  }
}
   // </Snippet1>

