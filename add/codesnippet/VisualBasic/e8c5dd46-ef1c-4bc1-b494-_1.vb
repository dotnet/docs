        Dim feed As MySyndicationFeed = New MySyndicationFeed("Test Feed", "This is a test feed", New Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        Dim rssWriter As XmlWriter = XmlWriter.Create("Rss.xml")
        Dim rssFormatter As Rss20FeedFormatter(Of MySyndicationFeed) = New Rss20FeedFormatter(Of MySyndicationFeed)(feed, True)