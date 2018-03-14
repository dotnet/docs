'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

public class Sample 

  public shared sub Main() 
   
    ' Create a string containing the XSLT stylesheet.
    Dim xsltString as String 
    xsltString = "<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>" & _
    "   <xsl:template match='bookstore'>" & _
    "      <HTML>" & _
    "         <HEAD>" & _
    "            <TITLE>Book Titles</TITLE>" & _
    "       </HEAD>" & _
    "        <BODY>" & _
    "           <xsl:apply-templates select='book'/>" & _
    "        </BODY>" & _
    "     </HTML>" & _
    "   </xsl:template>" & _
    "  <xsl:template match='book'>" & _
    "     <P><xsl:value-of select='title'/></P>" & _
    "   </xsl:template>" & _
    "   </xsl:stylesheet>"

    ' Create the XslTransform object.
    Dim xslt as XslTransform = new XslTransform()

    ' Load the stylesheet.
    Dim rdr as StringReader = new StringReader(xsltString)
    xslt.Load(new XPathDocument(rdr), nothing, nothing)

    ' Transform the file and output an HTML string.
    Dim HTMLoutput as string
    Dim writer as StringWriter = new StringWriter()
    xslt.Transform(new XPathDocument("books.xml"), nothing, writer, nothing)
    HTMLoutput = writer.ToString()

  end sub
end class
'</snippet1>