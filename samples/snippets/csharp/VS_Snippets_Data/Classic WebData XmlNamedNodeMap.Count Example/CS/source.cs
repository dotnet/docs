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

     Console.WriteLine("Display all the attributes for this book...");
     for (int i=0; i < attrColl.Count; i++)
     {
        Console.WriteLine("{0} = {1}", attrColl.Item(i).Name, attrColl.Item(i).Value);
     }         
    
  }
}
 // </Snippet1>

