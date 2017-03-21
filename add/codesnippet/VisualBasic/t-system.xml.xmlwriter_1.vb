Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("books.xml", settings)