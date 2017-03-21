        Dim feed As SyndicationFeed = New SyndicationFeed("Test Feed", "This is a test feed", New Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        Dim rssWriter As XmlWriter = XmlWriter.Create("RSS.xml")
        Dim rssFormatter As Rss20FeedFormatter = New Rss20FeedFormatter(feed)