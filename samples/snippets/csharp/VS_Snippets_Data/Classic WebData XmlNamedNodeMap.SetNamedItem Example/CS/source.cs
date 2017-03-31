// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
     XmlDocument doc = new XmlDocument();
     doc.LoadXml("<book genre='novel' publicationdate='1997'> " +
                 "  <title>Pride And Prejudice</title>" +
                 "</book>");      
 
     XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;

     // Add a new attribute to the collection.
     XmlAttribute attr = doc.CreateAttribute("style");
     attr.Value = "hardcover";
     attrColl.SetNamedItem(attr);

     Console.WriteLine("Display the modified XML...");
     Console.WriteLine(doc.OuterXml);
    
  }
}
 // </Snippet1>

