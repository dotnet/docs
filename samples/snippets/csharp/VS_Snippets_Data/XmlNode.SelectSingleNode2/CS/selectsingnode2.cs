//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {

      XmlDocument doc = new XmlDocument();
      doc.Load("newbooks.xml");

      // Create an XmlNamespaceManager to resolve the default namespace.
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
      nsmgr.AddNamespace("bk", "urn:newbooks-schema");

      // Select the first book written by an author whose last name is Atwood.
      XmlNode book;
      XmlElement root = doc.DocumentElement;
     book = root.SelectSingleNode("descendant::bk:book[bk:author/bk:last-name='Atwood']", nsmgr);

      Console.WriteLine(book.OuterXml);

  }
}
//</snippet1>