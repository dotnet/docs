
    Dim nt As NameTable  = New NameTable()
    Dim book As object = nt.Add("book")
    Dim price As object = nt.Add("price")

    ' Create the reader.
    Dim settings As XmlReaderSettings = New XmlReaderSettings()
    settings.NameTable = nt
    Dim reader As XmlReader = XmlReader.Create("books.xml", settings)

    reader.MoveToContent()
    reader.ReadToDescendant("book")

     If (System.Object.ReferenceEquals(book, reader.Name)) 
         ' Do additional processing.
     End If
 