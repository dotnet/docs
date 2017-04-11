'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

public class Sample

  private const filename as String = "books.xml"
  private const stylesheet as String = "titles.xsl"

  public shared sub Main()

    'Create the reader to load the stylesheet. 
    'Move the reader to the xsl:stylesheet node.
    Dim reader as XmlTextReader = new XmlTextReader(stylesheet)
    reader.Read()
    reader.Read()

    'Create the XslTransform object and load the stylesheet.
    Dim xslt as XslTransform = new XslTransform()
    xslt.Load(reader)

    'Load the file to transform.
    Dim doc as XPathDocument = new XPathDocument(filename)
             
    'Create an XmlTextWriter which outputs to the console.
    Dim writer as XmlTextWriter = new XmlTextWriter(Console.Out)

    'Transform the file and send the output to the console.
    xslt.Transform(doc, nothing, writer)
    writer.Close()  

  end sub
end class
'</snippet1>