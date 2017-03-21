Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.NewLineOnAttributes = True
Dim writer As XmlWriter = XmlWriter.Create("books.xml", settings)