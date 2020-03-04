// <Snippet1>
using System;
using System.Xml;
 
public class Sample {

  public static void Main() {
      
        // Create a new document containing information about a book
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<book>" +
                    "  <title>Oberon's Legacy</title>" +
                    "  <price>5.95</price>" +
                    "</book>");

        // Create a new element node for the ISBN of the book
        // It is possible to supply a prefix for this node, and specify a qualified namespace.
        XmlNode newElem;
        newElem = doc.CreateNode(XmlNodeType.Element, "g", "ISBN", "https://global.ISBN/list");
        newElem.InnerText = "1-861001-57-5";

        // Add the new element to the document
        XmlElement root = doc.DocumentElement;
        root.AppendChild(newElem);

        // Display the modified XML document
        Console.WriteLine(doc.OuterXml);

        //Output: 
        // <book><title>Oberon's Legacy</title><price>5.95</price><g:ISBN xmlns:g="https://global.ISBN/list">1-861001-57-5</g:ISBN></book>
   }
 }
// </Snippet1>
