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
    doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" +
                "<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" +
                "<misc/>" +
                "</book>"); 

    //Create an entity reference node. The child count should be 0 
    //since the node has not been expanded.
    XmlEntityReference entityref = doc.CreateEntityReference("h");
    Console.WriteLine(entityref.ChildNodes.Count ); 

    //After the the node has been added to the document, its parent node
    //is set and the entity reference node is expanded.  It now has a child
    //node containing the entity replacement text. 
    doc.DocumentElement.LastChild.AppendChild(entityref);
    Console.WriteLine(entityref.FirstChild.InnerText);

    //Create and insert an undefined entity reference node.  When the entity
    //reference node is expanded, because the entity reference is undefined
    //the child is an empty text node.
    XmlEntityReference entityref2 = doc.CreateEntityReference("p");
    doc.DocumentElement.LastChild.AppendChild(entityref2);
    Console.WriteLine(entityref2.FirstChild.InnerText);
    
  }
}
   // </Snippet1>

