using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
 
 public class Sample
 {
   private const String stylesheet = @"c:\tmp\output.xsl";
   private const String myURL = @"http://localhost/data";
    
   public static void Main () {
   
       XmlTextReader reader = new XmlTextReader(stylesheet);
       TransformFile(reader, myURL);
   }
 
   // Perform an XSLT transformation where xsltReader is an XmlReader containing
   // a stylesheet and secureURI is a trusted URI that can be used to create Evidence.
//<snippet1>

   public static void TransformFile (XmlReader xsltReader, String secureURL) {
    
    // Load the stylesheet using a default XmlUrlResolver and Evidence 
    // created using the trusted URL.
    XslTransform xslt = new XslTransform();
    xslt.Load(xsltReader, new XmlUrlResolver(), XmlSecureResolver.CreateEvidenceForUrl(secureURL));

    // Transform the file.
    xslt.Transform("books.xml", "books.html", new XmlUrlResolver());
   } 
//</snippet1> 
 
 }