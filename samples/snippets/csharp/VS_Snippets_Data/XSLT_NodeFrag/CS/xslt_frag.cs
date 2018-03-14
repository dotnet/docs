using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

public class Sample
{

   public static void Main()
   {
//<snippet1>
// Load an XPathDocument.
XPathDocument doc = new XPathDocument("books.xml");

// Locate the node fragment.
XPathNavigator nav = doc.CreateNavigator();
XPathNavigator myBook = nav.SelectSingleNode("descendant::book[@ISBN = '0-201-63361-2']");

// Create a new object with just the node fragment.
XmlReader reader = myBook.ReadSubtree();
reader.MoveToContent();

// Load the style sheet.
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("single.xsl");

// Transform the node fragment.
xslt.Transform(reader, XmlWriter.Create(Console.Out, xslt.OutputSettings));
//</snippet1>
  }
}