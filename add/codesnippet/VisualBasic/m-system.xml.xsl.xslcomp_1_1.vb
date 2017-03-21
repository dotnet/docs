' Enable XSLT debugging.
Dim xslt As New XslCompiledTransform(true)

' Load the style sheet.
xslt.Load("output.xsl")

' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent=true
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)

' Execute the transformation.
xslt.Transform("books.xml", writer)
writer.Close()