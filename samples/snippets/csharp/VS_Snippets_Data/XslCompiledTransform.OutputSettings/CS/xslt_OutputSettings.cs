//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Sample {

  private const String filename = "books.xml";
  private const String stylesheet = "outputConsole.xsl";

  public static void Main() {

    // Create the XslTransform object and load the style sheet.
    XslCompiledTransform xslt = new XslCompiledTransform();
    xslt.Load(stylesheet);

    // Load the file to transform.
    XPathDocument doc = new XPathDocument(filename);

    // Create the writer.             
    XmlWriter writer = XmlWriter.Create(Console.Out, xslt.OutputSettings);

    // Transform the file and send the output to the console.
    xslt.Transform(doc, writer);
    writer.Close();

  }
}
//</snippet1>