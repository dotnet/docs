//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Net;

public class Sample
{
   private const String filename = "books.xml";
   private const String stylesheet = "sort.xsl";

   public static void Main()
   {
      //Create the XslTransform.
     XslTransform xslt = new XslTransform();

     //Create a resolver and set the credentials to use.
     XmlUrlResolver resolver = new XmlUrlResolver();
     resolver.Credentials = CredentialCache.DefaultCredentials;
  
     //Load the stylesheet.
     xslt.Load(stylesheet, resolver);

     //Load the XML data file.
     XPathDocument doc = new XPathDocument(filename);

     //Create the XmlTextWriter to output to the console.            
     XmlTextWriter writer = new XmlTextWriter(Console.Out);

     //Transform the file.
     xslt.Transform(doc, null, writer, null);
     writer.Close();
  }
}
//</snippet1>