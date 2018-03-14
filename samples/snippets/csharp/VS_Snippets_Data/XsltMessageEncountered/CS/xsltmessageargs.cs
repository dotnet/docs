//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Sample {

  public static void Main() {

    // Create the XslCompiledTransform object and load the style sheet.
    XslCompiledTransform xslt = new XslCompiledTransform();
    xslt.Load("message.xsl");

    XsltArgumentList argList = new XsltArgumentList();
    argList.XsltMessageEncountered += new XsltMessageEncounteredEventHandler(MessageCallBack);
	
    // Load the file to transform.
    XPathDocument doc = new XPathDocument("books.xml");

    // Transform the file.
    xslt.Transform(doc, argList, XmlWriter.Create("output.xml"));

  }

  private static void MessageCallBack(object sender, XsltMessageEncounteredEventArgs e) {
    Console.WriteLine("Message received: {0}", e.Message);
  }

}
//</snippet1>