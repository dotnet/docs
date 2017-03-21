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