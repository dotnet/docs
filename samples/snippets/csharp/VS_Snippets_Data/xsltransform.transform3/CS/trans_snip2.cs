using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

public class Sample
{

   public static void Main()
   {
//<snippet1>
//Create the XslTransform object.
XslTransform xslt = new XslTransform();

//Load the stylesheet.
xslt.Load("output.xsl");

//Transform the file.
xslt.Transform("books.xml", "books.html");
//</snippet1>
  }
}