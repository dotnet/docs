//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

public class Sample
{

    public static void Main()
    {

        XPathDocument doc = new XPathDocument("books.xml");
        XPathNavigator nav = doc.CreateNavigator();

        // Create a writer that outputs to the console.
        XmlWriter writer = XmlWriter.Create(Console.Out);

        // Write the start tag.
        writer.WriteStartElement("myBooks");

        // Write the first book.
        nav.MoveToChild("bookstore", "");
        nav.MoveToChild("book", "");
        writer.WriteNode(nav, false);

        // Close the start tag.
        writer.WriteEndElement();

        // Close the writer.
        writer.Close();

    }
}
//</snippet1>