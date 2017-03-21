        Dim items As New List(Of SyndicationItem)()

        Dim item1 As New SyndicationItem()
        item1.Title = New TextSyndicationContent("Item 1")
        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1")
        items.Add(item1)

        Dim item2 As New SyndicationItem()
        item2.Title = New TextSyndicationContent("Item 2")
        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2")
        items.Add(item2)

        Dim feed As New SyndicationFeed(items)
        feed.Description = New TextSyndicationContent("This is a feed description")