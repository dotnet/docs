' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)
        
' Execute the transformation.
xslt.Transform(New XPathDocument("books.xml"), writer)
writer.Close()