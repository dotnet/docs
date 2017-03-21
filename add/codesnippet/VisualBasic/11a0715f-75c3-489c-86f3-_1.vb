        Dim items As Collection(Of SyndicationItem) = New Collection(Of SyndicationItem)()
        Dim item1 As SyndicationItem = New SyndicationItem()
        item1.Title = New TextSyndicationContent("Item 1")
        item1.Summary = New TextSyndicationContent("This is Item 1's summary")
        item1.Authors.Add(New SyndicationPerson("Jesper@contoso.com", "Jesper Aaberg", "http:'contoso/jesper"))
        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1")

        Dim item2 As SyndicationItem = New SyndicationItem()
        item2.Title = New TextSyndicationContent("Item 2")
        item2.Summary = New TextSyndicationContent("This is Item 2's summary")
        item2.Authors.Add(New SyndicationPerson("lene@contoso.com", "Lene Aaling", "http:'contoso/lene"))
        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2")

        Dim feed As SyndicationFeed = New SyndicationFeed(items)