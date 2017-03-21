        Dim itemFormatter As New Atom10ItemFormatter()
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Item")
        If itemFormatter.CanRead(atomReader) Then
            itemFormatter.ReadFrom(atomReader)
            atomReader.Close()
        End If