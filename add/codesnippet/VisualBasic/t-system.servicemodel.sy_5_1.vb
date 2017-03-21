        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)

        feed.Copyright = New TextSyndicationContent("Copyright 2007")
        feed.Description = New TextSyndicationContent("This is a sample feed")

        Dim textContent As TextSyndicationContent = New TextSyndicationContent("Some text content")
        Dim item As SyndicationItem = New SyndicationItem("Item Title", textContent, New Uri("http://server/items"), "ItemID", DateTime.Now)