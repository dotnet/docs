        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        ' Add a custom attribute.
        Dim xqName As XmlQualifiedName = New XmlQualifiedName("CustomAttribute")
        feed.AttributeExtensions.Add(xqName, "Value")

        Dim sp As SyndicationPerson = New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:'jesper/aaberg")
        feed.Authors.Add(sp)

        Dim category As SyndicationCategory = New SyndicationCategory("FeedCategory", "CategoryScheme", "CategoryLabel")
        feed.Categories.Add(category)

        feed.Contributors.Add(New SyndicationPerson("Lene@contoso.com", "Lene Aaling", "http:'Lene/Aaling"))
        feed.Copyright = New TextSyndicationContent("Copyright 2007")
        feed.Description = New TextSyndicationContent("This is a sample feed")

        ' Add a custom element.
        Dim doc As XmlDocument = New XmlDocument()
        Dim feedElement As XmlElement = doc.CreateElement("CustomElement")
        feedElement.InnerText = "Some text"
        feed.ElementExtensions.Add(feedElement)

        feed.Generator = "Sample Code"
        feed.Id = "FeedID"
        feed.ImageUrl = New Uri("http:'server/image.jpg")

        Dim textContent As TextSyndicationContent = New TextSyndicationContent("Some text content")
        Dim item As SyndicationItem = New SyndicationItem("Item Title", textContent, New Uri("http:'server/items"), "ItemID", DateTime.Now)

        Dim items As Collection(Of SyndicationItem) = New Collection(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        feed.Language = "en-us"
        feed.LastUpdatedTime = DateTime.Now

        Dim link As SyndicationLink = New SyndicationLink(New Uri("http:'server/link"), "alternate", "Link Title", "text/html", 1000)
        feed.Links.Add(link)

        Dim atomWriter As XmlWriter = XmlWriter.Create("atom.xml")
        Dim atomFormatter As Atom10FeedFormatter = New Atom10FeedFormatter(feed)
        atomFormatter.WriteTo(atomWriter)
        atomWriter.Close()

        Dim rssWriter As XmlWriter = XmlWriter.Create("rss.xml")
        Dim rssFormatter As Rss20FeedFormatter = New Rss20FeedFormatter(feed)
        rssFormatter.WriteTo(rssWriter)
        rssWriter.Close()