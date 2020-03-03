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

    //Load the document with the last book node.
    XmlTextReader reader = new XmlTextReader("books.xml");
    reader.WhitespaceHandling = WhitespaceHandling.None;
    reader.MoveToContent();
    reader.Read();
    reader.Skip(); //Skip the first book.
    reader.Skip(); //Skip the second book.
    doc.Load(reader);

    doc.Save(Console.Out);
  }
}
// </Snippet1>
