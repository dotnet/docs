Imports System
Imports System.Xml
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Syndication
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


Public Class Snippets
    Public Shared Sub Snippet0()
        '<Snippet0>
        '<Snippet2>          
        Dim item As SyndicationItem = New SyndicationItem("My Item", "This is some content", New Uri("http:' SomeServer/MyItem"), "Item ID", DateTime.Now)
        item.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:' contoso/jesper"))
        item.Categories.Add(New SyndicationCategory("Category One"))
        item.Contributors.Add(New SyndicationPerson("lene@contoso.com", "Lene Aaling", "http:' contoso/lene"))
        item.Copyright = New TextSyndicationContent("Copyright 2007")
        item.Links.Add(New SyndicationLink(New Uri("http:' OtherServer/Item"), "alternate", "Alternate Link", "text/html", 1000))
        item.PublishDate = New DateTime(2007, 2, 23)
        item.Summary = New TextSyndicationContent("this is a summary for my item")
        '</Snippet2>
        Dim xqName As XmlQualifiedName = New XmlQualifiedName("itemAttrib", "http:' FeedServer/tags")
        item.AttributeExtensions.Add(xqName, "ItemAttribValue")

        Dim feed As SyndicationFeed = New SyndicationFeed()
        Dim items As Collection(Of SyndicationItem) = New Collection(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items
        '</Snippet0>
    End Sub

    Public Shared Sub Snippet1()
        '<Snippet1>
        Dim item As SyndicationItem = New SyndicationItem("My Item", "This is some content", New Uri("http:' SomeServer/MyItem"))
        item.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:' contoso/jesper"))
        item.Categories.Add(New SyndicationCategory("Category One"))
        item.Contributors.Add(New SyndicationPerson("lene@contoso.com", "Lene Aaling", "http:' contoso/lene"))
        item.Copyright = New TextSyndicationContent("Copyright 2007")
        item.Links.Add(New SyndicationLink(New Uri("http:' OtherServer/Item"), "alternate", "Alternate Link", "text/html", 1000))
        item.PublishDate = New DateTime(2007, 2, 23)
        item.Summary = New TextSyndicationContent("this is a summary for my item")
        '</Snippet1>
    End Sub

    Public Shared Sub Snippet3()
        '<Snippet3>
        Dim content As TextSyndicationContent = New TextSyndicationContent("This is some text content")
        Dim altLink As Uri = New Uri("http:' someserver/item")
        Dim item As SyndicationItem = New SyndicationItem("Item Title", content, altLink, "Item ID", DateTime.Now)
        '</Snippet3>
    End Sub


    Public Shared Sub Snippet21()
        '<Snippet21>
        Dim reader As XmlReader = XmlReader.Create("http:' localhost/items/serializedItem.xml")
        Dim item As SyndicationItem = SyndicationItem.Load(reader)
        reader.Close()
        '</Snippet21>
    End Sub

    Public Shared Sub Snippet22()
        ' <Snippet22>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Authors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:' contoso/jesper"))
        ' </Snippet22>
    End Sub

    Public Shared Sub Snippet23()
        ' <Snippet23>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Categories.Add(New SyndicationCategory("MyFeedCategory"))
        ' </Snippet23>
    End Sub

    Public Shared Sub Snippet24()
        ' <Snippet24>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Content = New TextSyndicationContent("This is the content of the syndication item")
        ' </Snippet24>
    End Sub

    Public Shared Sub Snippet25()
        ' <Snippet25>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Contributors.Add(New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:' contoso/jesper"))
        ' </Snippet25>
    End Sub

    Public Shared Sub Snippet26()
        ' <Snippet26>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Copyright = New TextSyndicationContent("Copyright 2007 Contoso")
        ' </Snippet26>
    End Sub

    Public Shared Sub Snippet27()
        ' <Snippet27>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Id = "ItemID"
        ' </Snippet27>
    End Sub

    Public Shared Sub Snippet28()
        ' <Snippet28>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.LastUpdatedTime = DateTimeOffset.Now
        ' </Snippet28>
    End Sub

    Public Shared Sub Snippet29()
        ' <Snippet29>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Links.Add(New SyndicationLink(New Uri("http:' server/link"), "alternate", "Link Title", "text/html", 1000))
        ' </Snippet29>
    End Sub

    Public Shared Sub Snippet30()
        ' <Snippet30>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.PublishDate = DateTimeOffset.Now
        ' </Snippet30>
    End Sub

    Public Shared Sub Snippet31()
        ' <Snippet31>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"))
        item.Summary = New TextSyndicationContent("This is a syndication item summary")
        ' </Snippet31>
    End Sub

    Public Shared Sub Snippet32()
        ' <Snippet32>
        Dim item As New SyndicationItem()
        item.Title = New TextSyndicationContent("Item Title")
        ' </Snippet32>
    End Sub

    Public Shared Sub Snippet33()
        ' <Snippet33>
        Dim item As New SyndicationItem()
        item.BaseUri = New Uri("http:' SomeServer/MyItem")
        ' </Snippet33>
    End Sub

    Public Shared Sub Snippet34()
        ' <Snippet34>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        ' </Snippet34>
    End Sub

    Public Shared Sub Snippet35()
        ' <Snippet35>
        Dim content As New TextSyndicationContent("Item Content")
        Dim uri As New Uri("http:' Item/Alternate/Link")
        Dim item As New SyndicationItem("Item Title", content, uri, "itemID", DateTimeOffset.Now)
        ' </Snippet35>
    End Sub

    Public Shared Sub Snippet36()
        ' <Snippet36>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        item.AddPermalink(New Uri("http:' contoso/links/mylink"))
        ' </Snippet36>
    End Sub

    Public Shared Sub Snippet37()
        ' <Snippet37>
        Dim reader = XmlReader.Create("http:' localhost/items/serializedItem.xml")
        Dim myItem As MySyndicationItem = SyndicationItem.Load(Of MySyndicationItem)(reader)
        reader.Close()
        ' </Snippet37>
    End Sub

    Public Shared Sub Snippet38()
        ' <Snippet38>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim writer As XmlWriter = XmlWriter.Create("outfile.xml")
        item.SaveAsAtom10(writer)
        writer.Close()
        ' </Snippet38>
    End Sub

    Public Shared Sub Snippet39()
        ' <Snippet39>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim writer As XmlWriter = XmlWriter.Create("outfile.xml")
        item.SaveAsRss20(writer)
        writer.Close()
        ' </Snippet39>
    End Sub

    Public Shared Sub Snippet41()
        ' <Snippet41>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim clone As SyndicationItem = item.Clone()
        ' </Snippet41>
    End Sub

    Public Shared Sub Snippet42()
        '  <Snippet42>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim atomFormatter As Atom10ItemFormatter = item.GetAtom10Formatter()
        Dim writer As XmlWriter = XmlWriter.Create("output.xml")
        atomFormatter.WriteTo(writer)
        writer.Close()
        '  </Snippet42>
    End Sub

    Public Shared Sub Snippet43()
        '  <Snippet43>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim rssFormatter As Rss20ItemFormatter = item.GetRss20Formatter()
        Dim writer As XmlWriter = XmlWriter.Create("output.xml")
        rssFormatter.WriteTo(writer)
        writer.Close()
        '  </Snippet43>
    End Sub

    Public Shared Sub Snippet44()
        '  <Snippet44>
        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim rssFormatter As Rss20ItemFormatter = item.GetRss20Formatter(True)
        Dim writer As XmlWriter = XmlWriter.Create("output.xml")
        rssFormatter.WriteTo(writer)
        writer.Close()
        '  </Snippet44>
    End Sub

    Public Shared Function GetXmlObjectSerializer() As XmlObjectSerializer

        Dim dummy As Object = New Object()
        Return CType(dummy, XmlObjectSerializer)
    End Function

End Class
