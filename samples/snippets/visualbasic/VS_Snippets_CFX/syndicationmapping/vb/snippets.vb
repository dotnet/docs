Imports System
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web
Imports System.Xml
Imports System.Runtime.Serialization

<DataContract()> _
Public Class SomeData
    Public Sub SomeData()

    End Sub
End Class

Public Class Snippets
    Public Sub Snippet0()
        '<Snippet0>
        Dim feed As New SyndicationFeed("My Feed Title", "My Feed Description", New Uri("http://MyFeedURI"))
        feed.Copyright = New TextSyndicationContent("Copyright 2007")
        feed.Language = "EN-US"
        feed.LastUpdatedTime = DateTime.Now
        feed.Generator = "Sample Code"
        feed.Id = "FeedID"
        feed.ImageUrl = New Uri("http://server/image.jpg")

        Dim category As New SyndicationCategory("MyCategory")
        category.Label = "categoryLabel"
        category.Name = "categoryName"
        category.Scheme = "categoryScheme"
        feed.Categories.Add(category)

        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http://MyItemURI"))
        item.Authors.Add(New SyndicationPerson("Jesper.Aaberg@contoso.com", "Jesper Aaberg", "http://Contoso/Aaberg"))
        item.Categories.Add(category)
        item.Contributors.Add(New SyndicationPerson("Lene.Aaling@contoso.com", "Lene Aaling", "http://Contoso/Aaling"))
        item.Copyright = New TextSyndicationContent("Copyright 2007")
        item.Id = "ItemID"
        item.LastUpdatedTime = DateTime.Now
        item.PublishDate = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("Item Summary")
        Dim items As New Collection(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        SerializeFeed(feed)
        '</Snippet0>
    End Sub
    Public Sub Snippet1()
        Dim feed As New SyndicationFeed("My Feed Title", "My Feed Description", New Uri("http://MyFeedURI"))

        '<Snippet1>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http://MyItemURI"))
        item.Authors.Add(New SyndicationPerson("Jesper.Aaberg@contoso.com", "Jesper Aaberg", "http://Contoso/Aaberg"))
        item.Authors.Add(New SyndicationPerson("Syed.Abbas@contoso.com", "Syed Abbas", "http://Contoso/Abbas"))

        Dim category As New SyndicationCategory("MyCategory")
        category.Label = "categoryLabel"
        category.Name = "categoryName"
        category.Scheme = "categoryScheme"

        Dim category2 As New SyndicationCategory("MyCategoryTwo")
        category2.Label = "categoryLabel"
        category2.Name = "categoryName"
        category2.Scheme = "categoryScheme"

        item.Categories.Add(category)
        item.Categories.Add(category2)
        item.Contributors.Add(New SyndicationPerson("Lene.Aaling@contoso.com", "Lene Aaling", "http://Contoso/Aaling"))
        item.Contributors.Add(New SyndicationPerson("Kim.Abercrombie@contoso.com", "Kim Abercrombie", "http://Contoso/Abercrombie"))
        item.Copyright = New TextSyndicationContent("Copyright 2007")
        item.Id = "ItemID"
        item.LastUpdatedTime = DateTime.Now
        item.PublishDate = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("Item Summary")
        Dim items As New Collection(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        SerializeItem(item)
        '</Snippet1>
    End Sub

    Public Sub Snippet2()
        '<Snippet2>
        Dim feed As New SyndicationFeed("My Feed Title", "My Feed Description", New Uri("http://MyFeedURI"))
        feed.Authors.Add(New SyndicationPerson("Jesper.Aaberg@contoso.com", "Jesper Aaberg", "http://Contoso/Aaberg"))
        feed.Authors.Add(New SyndicationPerson("Syed.Abbas@contoso.com", "Syed Abbas", "http://Contoso/Abbas"))

        feed.Contributors.Add(New SyndicationPerson("Lene.Aaling@contoso.com", "Lene Aaling", "http://Contoso/Aaling"))
        feed.Contributors.Add(New SyndicationPerson("Kim.Abercrombie@contoso.com", "Kim Abercrombie", "http://Contoso/Abercrombie"))

        SerializeFeed(feed)
        '</Snippet2>
    End Sub

    Public Sub Snippet3()
        '<Snippet3>
        Dim feed As New SyndicationFeed("My Feed Title", "My Feed Description", New Uri("http://MyFeedURI"))
        feed.Links.Add(New SyndicationLink(New Uri("http://contoso/MyLink"), "alternate", "My Link Title", "text/html", 2048))

        SerializeFeed(feed)
        '</Snippet3>
    End Sub

    Public Sub Snippet4()

        '<Snippet4>
        Dim feed As New SyndicationFeed("My Feed Title", "My Feed Description", New Uri("http://MyFeedURI"))

        Dim category As New SyndicationCategory("MyCategory")
        category.Label = "categoryLabel"
        category.Name = "categoryName"
        category.Scheme = "categoryScheme"
        feed.Categories.Add(category)

        SerializeFeed(feed)
        '</Snippet4>
    End Sub

    Public Sub Snippet5()
        '<Snippet5>
        Dim htmlItem As New SyndicationItem()
        htmlItem.Content = New TextSyndicationContent("<html> some html </html>", TextSyndicationContentKind.Html)

        SerializeItem(htmlItem)
        '</Snippet5>
    End Sub

    Public Sub Snippet6()

        '<Snippet6>
        Dim txtItem As New SyndicationItem()
        txtItem.Content = New TextSyndicationContent("Some Plain Text", TextSyndicationContentKind.Plaintext)

        SerializeItem(txtItem)
        '</Snippet6>
    End Sub

    Public Sub Snippet7()
        '<Snippet7>
        Dim xhtmlItem As New SyndicationItem()
        xhtmlItem.Content = New TextSyndicationContent("<html> some xhtml </html>", TextSyndicationContentKind.XHtml)

        SerializeItem(xhtmlItem)
        '</Snippet7>
    End Sub

    Public Sub Snippet8()

        '<Snippet8>
        Dim urlItem As New SyndicationItem()
        urlItem.Content = New UrlSyndicationContent(New Uri("http://Contoso/someUrl"), "audio")

        SerializeItem(urlItem)
        '</Snippet8>
    End Sub

    Public Sub Snippet9()
        '<Snippet9>
        Dim xmlItem As New SyndicationItem()

        xmlItem.Title = New TextSyndicationContent("Xml Item Title")
        xmlItem.Content = New XmlSyndicationContent("mytype", New SyndicationElementExtension(New SomeData()))

        SerializeItem(xmlItem)
        '</Snippet9>
    End Sub

    '<Snippet10>
    Public Sub SerializeFeed(ByVal feed As SyndicationFeed)

        Dim atomFormatter As Atom10FeedFormatter = feed.GetAtom10Formatter()
        Dim rssFormatter As Rss20FeedFormatter = feed.GetRss20Formatter()

        Dim atomWriter As XmlWriter = XmlWriter.Create("atom.xml")
        Dim rssWriter As XmlWriter = XmlWriter.Create("rss.xml")
        atomFormatter.WriteTo(atomWriter)
        rssFormatter.WriteTo(rssWriter)
        atomWriter.Close()
        rssWriter.Close()
    End Sub
    '</Snippet10>

    '<Snippet11>
    Public Sub SerializeItem(ByVal item As SyndicationItem)
        Dim atomFormatter As Atom10ItemFormatter = item.GetAtom10Formatter()
        Dim rssFormatter As Rss20ItemFormatter = item.GetRss20Formatter()

        Dim atomWriter As XmlWriter = XmlWriter.Create("atom.xml")
        Dim rssWriter As XmlWriter = XmlWriter.Create("rss.xml")
        atomFormatter.WriteTo(atomWriter)
        rssFormatter.WriteTo(rssWriter)
        atomWriter.Close()
        rssWriter.Close()
    End Sub
    '</Snippet11>


End Class
