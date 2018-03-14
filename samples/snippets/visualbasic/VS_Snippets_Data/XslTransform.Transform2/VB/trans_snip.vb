Imports System
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

public class Sample
  
  public shared sub Main()

'<snippet1>
  Dim doc as XmlDocument = new XmlDocument()
  doc.Load("books.xml")

  ' Modify the XML file.
  Dim root as XmlElement = doc.DocumentElement
  root.FirstChild.LastChild.InnerText = "12.95"

  ' Create an XPathNavigator to use for the transform.
  Dim nav as XPathNavigator = root.CreateNavigator()
  
  ' Transform the file.
  Dim xslt as XslTransform = new XslTransform()
  xslt.Load("output.xsl")
  Dim writer as XmlTextWriter = new XmlTextWriter("books.html", nothing)
  xslt.Transform(nav,nothing, writer, nothing)
'</snippet1>
  end sub
end class
