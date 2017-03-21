        Dim feedFormatter As New Rss20FeedFormatter()
        Dim rssReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        If feedFormatter.CanRead(rssReader) Then
            feedFormatter.ReadFrom(rssReader)
            rssReader.Close()
        End If