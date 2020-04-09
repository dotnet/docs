//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

public class Sample {

  private const String filename = "number.xml";
  private const String stylesheet = "calc.xsl";

  public static void Main() {

    // Compile the style sheet.
    XsltSettings xslt_settings = new XsltSettings();
    xslt_settings.EnableScript = true;
    XslCompiledTransform xslt = new XslCompiledTransform();
    xslt.Load(stylesheet, xslt_settings, new XmlUrlResolver());

    // Load the XML source file.
    XPathDocument doc = new XPathDocument(filename);

    // Create an XmlWriter.
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    settings.Indent = true;
    XmlWriter writer = XmlWriter.Create("output.xml", settings);

    // Execute the transformation.
    xslt.Transform(doc, writer);
    writer.Close();
  }
}
//</snippet1>