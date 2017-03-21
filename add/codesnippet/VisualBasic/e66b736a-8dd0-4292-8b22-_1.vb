        Dim content As New TextSyndicationContent("Item Content")
        Dim uri As New Uri("http:' Item/Alternate/Link")
        Dim item As New SyndicationItem("Item Title", content, uri, "itemID", DateTimeOffset.Now)