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

      //Select the book node with the matching attribute value.
      XmlNode book;
      XmlElement root = doc.DocumentElement;
      book = root.SelectSingleNode("descendant::book[@bk:ISBN='1-861001-57-6']", nsmgr);

      Console.WriteLine(book.OuterXml);

  }
}
//</snippet1>