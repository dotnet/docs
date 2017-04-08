//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

public class Sample {

  public static void Main() {
   
    // Create a string containing the XSLT stylesheet.
    String xsltString =
    @"<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
        <xsl:template match='bookstore'>
           <HTML>
              <HEAD>
                 <TITLE>Book Titles</TITLE>
             </HEAD>
             <BODY>
                <xsl:apply-templates select='book'/>
             </BODY>
          </HTML>
        </xsl:template>
        <xsl:template match='book'>
          <P><xsl:value-of select='title'/></P>
        </xsl:template>
        </xsl:stylesheet>";

    // Create the XslTransform object.
    XslTransform xslt = new XslTransform();

    // Load the stylesheet.
    StringReader rdr = new StringReader(xsltString);
    xslt.Load(new XPathDocument(rdr), null, null);

    // Transform the file and output an HTML string.
    string HTMLoutput;
    StringWriter writer = new StringWriter();
    xslt.Transform(new XPathDocument("books.xml"), null, writer, null);
    HTMLoutput = writer.ToString();

  }
}
//</snippet1>