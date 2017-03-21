        Dim feedFormatter As New Atom10FeedFormatter()
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        If feedFormatter.CanRead(atomReader) Then
            feedFormatter.ReadFrom(atomReader)
            atomReader.Close()
        End If