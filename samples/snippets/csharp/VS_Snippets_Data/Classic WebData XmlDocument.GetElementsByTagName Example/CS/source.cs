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
    doc.Load("books.xml");

    //Display all the book titles.
    XmlNodeList elemList = doc.GetElementsByTagName("title");
    for (int i=0; i < elemList.Count; i++)
    {   
      Console.WriteLine(elemList[i].InnerXml);
    }  

  }
}
   // </Snippet1>

