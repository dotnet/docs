        Dim rssReader As XmlReader = XmlReader.Create("http://contoso/Feeds/RSS/MyFeed")
        Dim rssFormatter As New Rss20FeedFormatter()
        rssFormatter.ReadFrom(rssReader)
        rssReader.Close()