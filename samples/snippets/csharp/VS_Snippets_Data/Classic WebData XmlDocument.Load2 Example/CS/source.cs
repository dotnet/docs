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

    //Load the the document with the last book node.
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

    public XmlDocument LoadDocument(bool generateXML)
    {
    <Snippet2>
    XmlDocument doc = new XmlDocument();
    doc.PreserveWhitespace = true;
    try { doc.Load("booksData.xml"); }
    catch (System.IO.FileNotFoundException)
        {
            doc.LoadXml("<?xml version=\"1.0\"?> \n" +
            "<books xmlns=\"http://www.contoso.com/books\"> \n" +
            "  <book genre=\"novel\" ISBN=\"1-861001-57-8\" publicationdate=\"1823-01-28\"> \n" +
            "    <title>Pride And Prejudice</title> \n" +
            "    <price>24.95</price> \n" +
            "  </book> \n" +
            "  <book genre=\"novel\" ISBN=\"1-861002-30-1\" publicationdate=\"1985-01-01\"> \n" +
            "    <title>The Handmaid's Tale</title> \n" +
            "    <price>29.95</price> \n" +
            "  </book> \n" +
            "</books>");             
        }
    </Snippet2>        
        return doc;
        }

