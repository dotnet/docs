        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim rssWriter As XmlWriter = XmlWriter.Create("RssItem.xml")
        Dim formatter As Rss20ItemFormatter = New Rss20ItemFormatter(item)