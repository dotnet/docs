Imports System.ServiceModel.Syndication
Imports System.Collections.Generic
Imports System.Xml

Public Class Snippets
    Public Shared Sub Snippet0()
        ' <Snippet0>
        Dim feed As SyndicationFeed = New SyndicationFeed("Test Feed", "This is a test feed", New Uri("http:'Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)
        items.Add(item)
        feed.Items = items

        Dim atomWriter As XmlWriter = XmlWriter.Create("Atom.xml")
        Dim atomFormatter As Atom10FeedFormatter = New Atom10FeedFormatter(feed)
        atomFormatter.WriteTo(atomWriter)
        atomWriter.Close()
        ' </Snippet0>
    End Sub


    Public Shared Sub Snippet1()
        ' <Snippet1>
        Dim atomReader As XmlReader = XmlReader.Create("AtomFeed.xml")
        Dim atomFormatter As Atom10FeedFormatter = New Atom10FeedFormatter()
        atomFormatter.ReadFrom(atomReader)
        atomReader.Close()
        ' </Snippet1>
    End Sub


    Public Shared Sub Snippet2()
        ' <Snippet2>
        Dim feed As MySyndicationFeed = New MySyndicationFeed("Test Feed", "This is a test feed", New Uri("http:'Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http:'someuri"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)
        items.Add(item)
        feed.Items = items

        Dim atomWriter As XmlWriter = XmlWriter.Create("Atom.xml")
        Dim atomFormatter As Atom10FeedFormatter(Of MySyndicationFeed) = New Atom10FeedFormatter(Of MySyndicationFeed)(feed)
        atomFormatter.WriteTo(atomWriter)
        atomWriter.Close()
        ' </Snippet2>
    End Sub


    Public Shared Sub Snippet3()
        ' <Snippet3>
        Dim feed As MySyndicationFeed = New MySyndicationFeed("Test Feed", "This is a test feed", New Uri("http:'Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http:'someuri"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)
        items.Add(item)
        feed.Items = items

        Dim atomWriter As XmlWriter = XmlWriter.Create("Atom.xml")
        ' <Snippet5>
        Dim atomFormatter As Atom10FeedFormatter(Of MySyndicationFeed) = New Atom10FeedFormatter(Of MySyndicationFeed)(feed)
        ' </Snippet5>
        atomFormatter.WriteTo(atomWriter)
        atomWriter.Close()
        ' </Snippet3>
    End Sub

    Public Shared Sub Snippet7()
        ' <Snippet7>
        ' <Snippet8>
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http:'someuri"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim atomWriter As XmlWriter = XmlWriter.Create("AtomItem.xml")
        Dim formatter As Atom10ItemFormatter = New Atom10ItemFormatter(item)
        ' </Snippet8>
        formatter.WriteTo(atomWriter)
        atomWriter.Close()
        ' </Snippet7>
    End Sub

    Public Shared Sub Snippet9()
        ' <Snippet9>
        ' <Snippet10>
        Dim item As MySyndicationItem = New MySyndicationItem("Test Item", "This is the content for Test Item", New Uri("http:'localhost/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http:'someuri"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim atomWriter As XmlWriter = XmlWriter.Create("AtomItem.xml")
        Dim formatter As Atom10ItemFormatter(Of MySyndicationItem) = New Atom10ItemFormatter(Of MySyndicationItem)(item)
        ' </Snippet10>
        formatter.WriteTo(atomWriter)
        atomWriter.Close()
        ' </Snippet9>
    End Sub

    Public Shared Sub Snippet11()
        ' <Snippet11>
        Dim myFeedAtomFormatter As New Atom10FeedFormatter(GetType(MySyndicationFeed))
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        myFeedAtomFormatter.ReadFrom(atomReader)
        atomReader.Close()
        ' </Snippet11>
    End Sub

    Public Shared Sub Snippet12()
        ' <Snippet12>
        Dim feedFormatter As New Atom10FeedFormatter()
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        If feedFormatter.CanRead(atomReader) Then
            feedFormatter.ReadFrom(atomReader)
            atomReader.Close()
        End If
        ' </Snippet12>
    End Sub

    Public Shared Sub Snippet13()
        ' <Snippet13>
        Dim itemFormatter As New Atom10ItemFormatter()
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Item")
        If itemFormatter.CanRead(atomReader) Then
            itemFormatter.ReadFrom(atomReader)
            atomReader.Close()
        End If
        ' </Snippet13>
    End Sub

    Public Shared Sub Snippet14()
        ' <Snippet14>
        Dim item As New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now)

        Dim atomItemFormatter As New Atom10ItemFormatter(item)
        Dim atomWriter As XmlWriter = XmlWriter.Create("Atom.xml")
        atomItemFormatter.WriteTo(atomWriter)
        atomWriter.Close()
        ' </Snippet14>
    End Sub

    Public Shared Sub Snippet15()
        ' <Snippet15>
        Dim myItemAtomFormatter As New Atom10ItemFormatter(GetType(MySyndicationItem))
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Items")
        myItemAtomFormatter.ReadFrom(atomReader)
        atomReader.Close()
        ' </Snippet15>
    End Sub

End Class
