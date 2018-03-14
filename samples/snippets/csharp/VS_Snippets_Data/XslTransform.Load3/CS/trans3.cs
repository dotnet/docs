//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Sample
{
  private const String filename = "books.xml";
  private const String stylesheet = "titles.xsl";

  public static void Main()
  {
    //Create the reader to load the stylesheet. 
    //Move the reader to the xsl:stylesheet node.
    XmlTextReader reader = new XmlTextReader(stylesheet);
    reader.Read();
    reader.Read();

    //Create the XslTransform object and load the stylesheet.
    XslTransform xslt = new XslTransform();
    xslt.Load(reader);

    //Load the file to transform.
    XPathDocument doc = new XPathDocument(filename);
             
    //Create an XmlTextWriter which outputs to the console.
    XmlTextWriter writer = new XmlTextWriter(Console.Out);

    //Transform the file and send the output to the console.
    xslt.Transform(doc, null, writer);
    writer.Close();  

  }
}
//</snippet1>