// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Sample
{
  private const String filename = "books.xml";
  private const String stylesheet = "output.xsl";

  public static void Main()
  {
    //Load the stylesheet.
    XslTransform xslt = new XslTransform();
    xslt.Load(stylesheet);

    //Load the file to transform.
    XPathDocument doc = new XPathDocument(filename);
             
    //Create an XmlTextWriter which outputs to the console.
    XmlTextWriter writer = new XmlTextWriter(Console.Out);

    //Transform the file and send the output to the console.
    xslt.Transform(doc, null, writer, null);
    writer.Close();

  }
}
   // </Snippet1>

