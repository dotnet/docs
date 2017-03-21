        Dim myFeedRssFormatter As New Rss20FeedFormatter(GetType(MySyndicationFeed))
        Dim rssReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        myFeedRssFormatter.ReadFrom(rssReader)
        rssReader.Close()