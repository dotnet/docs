using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

public class Sample
{

   public static void Main()
   {
//<snippet1>

// Create a resolver with default credentials.
XmlUrlResolver resolver = new XmlUrlResolver();
resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

// Create the XslTransform object.
XslTransform xslt = new XslTransform();

// Load the stylesheet.
xslt.Load("http://myServer/data/authors.xsl", resolver);

// Transform the file.
xslt.Transform("books.xml", "books.html", resolver);

//</snippet1>
  }
}