        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http:'someuri"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim atomWriter As XmlWriter = XmlWriter.Create("AtomItem.xml")
        Dim formatter As Atom10ItemFormatter = New Atom10ItemFormatter(item)
        formatter.WriteTo(atomWriter)
        atomWriter.Close()