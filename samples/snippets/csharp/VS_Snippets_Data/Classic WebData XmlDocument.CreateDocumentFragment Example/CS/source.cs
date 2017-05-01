// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    //Create the XmlDocument.
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("<items/>");

    //Create a document fragment.
    XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
 
    //Set the contents of the document fragment.
    docFrag.InnerXml ="<item>widget</item>";

   //Add the children of the document fragment to the
   //original document.
   doc.DocumentElement.AppendChild(docFrag);

   Console.WriteLine("Display the modified XML...");
   Console.WriteLine(doc.OuterXml);
  
  }
}
   // </Snippet1>

