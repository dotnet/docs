using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Sample
{

 public static void Main()
 {

// <Snippet1>
//Create a new XslTransform object.
XslTransform xslt = new XslTransform();

//Load the stylesheet.
xslt.Load("http://server/favorite.xsl");

//Create a new XPathDocument and load the XML data to be transformed.
XPathDocument mydata = new XPathDocument("inputdata.xml");

//Create an XmlTextWriter which outputs to the console.
XmlWriter writer = new XmlTextWriter(Console.Out);

//Transform the data and send the output to the console.
xslt.Transform(mydata,null,writer, null);
   // </Snippet1>

 }
}
