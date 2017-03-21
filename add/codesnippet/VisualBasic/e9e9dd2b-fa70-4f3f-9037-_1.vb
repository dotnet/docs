' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)
        
Dim reader As XmlReader = XmlReader.Create("books.xml")
reader.MoveToContent()
        
' Execute the transformation.
xslt.Transform(reader, writer)
writer.Close()
reader.Close()