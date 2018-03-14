using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
 
 public class Sample
 {
   private const String stylesheet = @"c:\tmp\output.xsl";
       
   public static void Main () {
   
       XmlDocument doc = new XmlDocument();
       doc.Load(stylesheet);
       
       TransformFile(doc.CreateNavigator());
   }
 
   // Perform an XSLT transformation where xsltNav is an XPathNavigator containing
   // a stylesheet from an untrusted source.
//<snippet1>

   public static void TransformFile (XPathNavigator xsltNav) {
    
    // Load the stylesheet. 
    XslTransform xslt = new XslTransform();
    xslt.Load(xsltNav, null, null);

    // Transform the file.
    xslt.Transform("books.xml", "books.html", null);
   } 
//</snippet1> 
 
 }