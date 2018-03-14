// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
     XmlDocument doc = new XmlDocument();
     doc.Load("2books.xml");
                         
     // Get and display all the book titles.
     XmlElement root = doc.DocumentElement;
     XmlNodeList elemList = root.GetElementsByTagName("title");
     for (int i=0; i < elemList.Count; i++)
     {   
        Console.WriteLine(elemList[i].InnerXml);
     } 
    
  }
}
   // </Snippet1>

