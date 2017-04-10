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

     // Remove the publicationdate attribute.
     attrColl.RemoveNamedItem("publicationdate");

     Console.WriteLine("Display the modified XML...");
     Console.WriteLine(doc.OuterXml);
    
  }
}
 // </Snippet1>

