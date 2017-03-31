//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {

      XmlDocument doc = new XmlDocument();
      doc.Load("booksort.xml");

      //Create an XmlNamespaceManager for resolving namespaces.
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
      nsmgr.AddNamespace("bk", "urn:samples");

      //Select and display the value of all the ISBN attributes.
      XmlNodeList nodeList;
      XmlElement root = doc.DocumentElement;
      nodeList = root.SelectNodes("/bookstore/book/@bk:ISBN", nsmgr);
      foreach (XmlNode isbn in nodeList){
        Console.WriteLine(isbn.Value);
      }

   }

}
//</snippet1>