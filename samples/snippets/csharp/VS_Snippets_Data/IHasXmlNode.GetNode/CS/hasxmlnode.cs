//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

public class Sample
{
  public static void Main()
  {
     XmlDocument doc = new XmlDocument();
     doc.Load("books.xml");
                         
     // Create an XPathNavigator and select all books by Plato.
     XPathNavigator nav = doc.CreateNavigator();
     XPathNodeIterator ni = nav.Select("descendant::book[author/name='Plato']");
     ni.MoveNext();

     // Get the first matching node and change the book price.
     XmlNode book = ((IHasXmlNode)ni.Current).GetNode();
     book.LastChild.InnerText = "12.95";
     Console.WriteLine(book.OuterXml);
    
  }
}
//</snippet1>