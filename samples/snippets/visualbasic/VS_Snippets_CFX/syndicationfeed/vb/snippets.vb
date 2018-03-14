Imports System
Imports System.Xml
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Syndication
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Public Class Snippets
    Public Shared Sub Snippet0()
        ' <Snippet0>
        ' <Snippet49>
        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        ' </Snippet49>
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
        ' </Snippet0>
    End Sub

    Public Shared Sub Snippet3()
        ' <Snippet3>
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
        ' </Snippet3>
    End Sub

    Public Shared Sub Snippet4()
        ' <Snippet4>
        Dim feed As SyndicationFeed = New SyndicationFeed("My Data Feed", "This is a sample feed", New Uri("http:'localhost/MyDataService"))
        ' </Snippet4>
    End Sub

    Public Shared Sub Snippet5()
        ' <Snippet5>
        Dim items As Collection(Of SyndicationItem) = New Collection(Of SyndicationItem)()
        Dim item1 As SyndicationItem = New SyndicationItem()
        item1.Title = New TextSyndicationContent("Item 1")
        item1.Summary = New TextSyndicationContent("This is Item 1's summary")
        item1.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:'contoso/jesper"))
        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1")
        Dim item2 As SyndicationItem = New SyndicationItem()
        item2.Title = New TextSyndicationContent("Item 2")
        item2.Summary = New TextSyndicationContent("This is Item 2's summary")
        item2.Authors.Add(New SyndicationPerson("lene@contoso.com", "Lene Aaling", "http:'contoso/lene"))
        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2")

        Dim feed As SyndicationFeed = New SyndicationFeed("My Data Feed", "This is a sample feed", New Uri("http:'localhost/MyDataService"), items)
        ' </Snippet5>
    End Sub

    Public Shared Sub Snippet6()
        ' <Snippet6>
        Dim feed As SyndicationFeed = New SyndicationFeed("My Data Feed", "This is a sample feed", New Uri("http:'localhost/MyDataService"), "Feed ID", DateTime.Now)
        ' </Snippet6>
    End Sub

    Public Shared Sub Snippet7()
        ' <Snippet7>
        Dim items As Collection(Of SyndicationItem) = New Collection(Of SyndicationItem)()

        Dim item1 As SyndicationItem = New SyndicationItem()
        item1.Title = New TextSyndicationContent("Item 1")
        item1.Summary = New TextSyndicationContent("This is Item 1's summary")
        item1.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:'contoso/jesper"))
        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1")

        Dim item2 As SyndicationItem = New SyndicationItem()
        item2.Title = New TextSyndicationContent("Item 2")
        item2.Summary = New TextSyndicationContent("This is Item 2's summary")
        item2.Authors.Add(New SyndicationPerson("lene@contoso.com", "Lene Aaling", "http:'contoso/lene"))
        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2")

        Dim feed As SyndicationFeed = New SyndicationFeed("My Data Feed", "This is a sample feed", New Uri("http:'localhost/MyDataService"), "Feed ID", DateTime.Now, items)
        ' </Snippet7>
    End Sub

    Public Shared Sub Snippet8()
        ' <Snippet8>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:'contoso/jesper"))
        ' </Snippet8>
    End Sub

    Public Shared Sub Snippet9()
        ' <Snippet9>
        Dim reader As XmlReader = XmlReader.Create("http:'localhost/feeds/serializedFeed.xml")
        Dim feed As SyndicationFeed = SyndicationFeed.Load(reader)
        '</Snippet9>
    End Sub

    Public Shared Sub Snippet10()
        '<Snippet10>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Categories.Add(New SyndicationCategory("MyFeedCategory"))
        '</Snippet10>
    End Sub

    Public Shared Sub Snippet11()
        '<Snippet11>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Contributors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:'contoso/jesper"))
        '</Snippet11>
    End Sub

    Public Shared Sub Snippet12()
        '<Snippet12>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Copyright = New TextSyndicationContent("Copyright 2007")
        '</Snippet12>
    End Sub

    Public Shared Sub Snippet13()
        '<Snippet13>
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
        '</Snippet13>
    End Sub
    Public Shared Sub Snippet39()
        ' <Snippet39>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Generator = "Generator Name or Description"
        ' </Snippet39>
    End Sub

    Public Shared Sub Snippet40()
        ' <Snippet40>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Id = "SyndicationFeedId"
        ' </Snippet40>
    End Sub

    Public Shared Sub Snippet41()
        ' <Snippet41>
        Dim feed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.ImageUrl = New Uri("http:'contoso/images/TestFeedImage")
        ' </Snippet41>
    End Sub

    Public Shared Sub Snippet42()
        ' <Snippet42>
        Dim items = New List(Of SyndicationItem)()

        Dim item1 = New SyndicationItem()
        item1.Title = New TextSyndicationContent("Item 1")
        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1")
        items.Add(item1)

        Dim item2 = New SyndicationItem()
        item2.Title = New TextSyndicationContent("Item 2")
        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2")
        items.Add(item2)

        Dim feed = New SyndicationFeed()
        feed.Items = items
        ' </Snippet42>
    End Sub

    Public Shared Sub Snippet43()
        ' <Snippet43>
        Dim feed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Language = "en-us"
        ' </Snippet43>
    End Sub

    Public Shared Sub Snippet44()
        ' <Snippet44>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.LastUpdatedTime = DateTimeOffset.Now
        ' </Snippet44>
    End Sub

    Public Shared Sub Snippet45()
        ' <Snippet45>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        feed.Links.Add(New SyndicationLink(New Uri("http:'server/link"), "alternate", "Link Title", "text/html", 1000))
        ' </Snippet45>
    End Sub

    Public Shared Sub Snippet46()
        ' <Snippet46>
        Dim feed As New SyndicationFeed()
        feed.Title = New TextSyndicationContent("My Feed Title")
        ' </Snippet46>
    End Sub


    Public Shared Sub Snippet47()
        ' <Snippet47>
        Dim feed As New SyndicationFeed()
        Dim clonedFeed As SyndicationFeed = feed.Clone(True)
        ' </Snippet47>
    End Sub

    Public Shared Sub Snippet48()
        ' <Snippet48>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        Dim baseUri As Uri = feed.BaseUri
        ' </Snippet48>
    End Sub

    Public Shared Sub Snippet50()
        ' <Snippet50>
        Dim items As New List(Of SyndicationItem)()
        Dim item1 = New SyndicationItem()
        item1.Title = New TextSyndicationContent("Item 1")
        item1.Summary = New TextSyndicationContent("This is Item 1's summary")
        item1.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:'contoso/jesper"))
        item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1")
        items.Add(item1)

        Dim item2 = New SyndicationItem()
        item2.Title = New TextSyndicationContent("Item 2")
        item2.Summary = New TextSyndicationContent("This is Item 2's summary")
        item2.Authors.Add(New SyndicationPerson("lene@contoso.com", "Lene Aaling", "http:'contoso/lene"))
        item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2")
        items.Add(item2)

        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now, items)
        ' </Snippet50>
    End Sub

    Public Shared Sub Snippet51()
        ' <Snippet51>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        ' ...
        Dim xmlWriter As XmlWriter = xmlWriter.Create("TestRSSFile.xml")
        feed.SaveAsRss20(XmlWriter)
        ' </Snippet51>
    End Sub

    Public Shared Sub Snippet52()
        ' <Snippet52>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        ' ...
        Dim xmlWriter As XmlWriter = xmlWriter.Create("TestAtomFile.xml")
        feed.SaveAsAtom10(XmlWriter)
        ' </Snippet52>
    End Sub

    Public Shared Function GetXmlObjectSerializer() As XmlObjectSerializer
        Dim dummy As Object = New Object()
        Return CType(dummy, XmlObjectSerializer)
    End Function

End Class
