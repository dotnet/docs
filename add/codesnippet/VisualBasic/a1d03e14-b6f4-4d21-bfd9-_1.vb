        Dim feed As SyndicationFeed = New SyndicationFeed("Test Feed", "This is a test feed", New Uri("http:'Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)
        items.Add(item)
        feed.Items = items

        Dim atomWriter As XmlWriter = XmlWriter.Create("Atom.xml")
        Dim atomFormatter As Atom10FeedFormatter = New Atom10FeedFormatter(feed)
        atomFormatter.WriteTo(atomWriter)
        atomWriter.Close()