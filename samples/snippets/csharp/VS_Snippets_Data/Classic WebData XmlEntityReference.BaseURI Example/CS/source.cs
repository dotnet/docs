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
    doc.Load("http://localhost/uri.xml");
                     
    //Display information on the entity reference node.
    XmlEntityReference entref = (XmlEntityReference) doc.DocumentElement.LastChild.FirstChild;
    Console.WriteLine("Name of the entity reference:  {0}", entref.Name);
    Console.WriteLine("Base URI of the entity reference:  {0}", entref.BaseURI);
    Console.WriteLine("The entity replacement text:  {0}", entref.InnerText);
  }
}
   // </Snippet1>

