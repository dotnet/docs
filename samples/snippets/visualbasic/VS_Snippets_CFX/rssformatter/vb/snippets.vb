Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Syndication
Imports System.Collections.ObjectModel
Imports System.Xml

Public Class Snippets

    Public Shared Sub Snippet0()
        ' <Snippet0>
        ' <Snippet1>
        Dim feed As SyndicationFeed = New SyndicationFeed("Test Feed", "This is a test feed", New Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        Dim rssWriter As XmlWriter = XmlWriter.Create("RSS.xml")
        Dim rssFormatter As Rss20FeedFormatter = New Rss20FeedFormatter(feed)
        ' </Snippet1>
        rssFormatter.WriteTo(rssWriter)
        rssWriter.Close()
        ' </Snippet0>
    End Sub

    Public Shared Sub Snippet2()
        ' <Snippet2>
        Dim feed As SyndicationFeed = New SyndicationFeed("Test Feed", "This is a test feed", New Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        Dim rssWriter As XmlWriter = XmlWriter.Create("RSS.xml")
        Dim rssFormatter As Rss20FeedFormatter = New Rss20FeedFormatter(feed, True)
        ' </Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        ' <Snippet3>
        ' <Snippet4>
        Dim feed As MySyndicationFeed = New MySyndicationFeed("Test Feed", "This is a test feed", New Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        Dim rssWriter As XmlWriter = XmlWriter.Create("Rss.xml")
        Dim rssFormatter As Rss20FeedFormatter(Of MySyndicationFeed) = New Rss20FeedFormatter(Of MySyndicationFeed)(feed)
        ' </Snippet4>
        rssFormatter.WriteTo(rssWriter)
        rssWriter.Close()
        ' </Snippet3>
    End Sub

    Public Shared Sub Snippet5()
        ' <Snippet5>
        Dim feed As MySyndicationFeed = New MySyndicationFeed("Test Feed", "This is a test feed", New Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now)
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = feed
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        Dim rssWriter As XmlWriter = XmlWriter.Create("Rss.xml")
        Dim rssFormatter As Rss20FeedFormatter(Of MySyndicationFeed) = New Rss20FeedFormatter(Of MySyndicationFeed)(feed, True)
        ' </Snippet5>
    End Sub


    Public Shared Sub Snippet7()
        ' <Snippet7>
        ' <Snippet8>
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim rssWriter As XmlWriter = XmlWriter.Create("RssItem.xml")
        Dim formatter As Rss20ItemFormatter = New Rss20ItemFormatter(item)
        ' </Snippet8>
        formatter.WriteTo(rssWriter)
        rssWriter.Close()
        ' </Snippet7>
    End Sub

    Public Shared Sub Snippet9()
        ' <Snippet9>
        Dim item As SyndicationItem = New SyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim rssWriter As XmlWriter = XmlWriter.Create("RssItem.xml")
        Dim formatter As Rss20ItemFormatter = New Rss20ItemFormatter(item, True)
        ' </Snippet9>
    End Sub

    Public Shared Sub Snippet10()
        ' <Snippet10>
        ' <Snippet11>
        Dim item As MySyndicationItem = New MySyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim rssWriter As XmlWriter = XmlWriter.Create("RssItem.xml")
        Dim formatter As Rss20ItemFormatter(Of MySyndicationItem) = New Rss20ItemFormatter(Of MySyndicationItem)(item)
        ' </Snippet11>
        formatter.WriteTo(rssWriter)
        rssWriter.Close()
        ' </Snippet10>
    End Sub

    Public Shared Sub Snippet12()
        ' <Snippet12>
        Dim item As MySyndicationItem = New MySyndicationItem("Test Item", "This is the content for Test Item", New Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now)

        item.Links.Add(New SyndicationLink(New Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100))
        item.PublishDate = New DateTime(1968, 2, 23)
        item.LastUpdatedTime = DateTime.Today
        item.SourceFeed = New SyndicationFeed()
        item.Summary = New TextSyndicationContent("This the item summary")

        Dim rssWriter As XmlWriter = XmlWriter.Create("RssItem.xml")
        Dim formatter As Rss20ItemFormatter(Of MySyndicationItem) = New Rss20ItemFormatter(Of MySyndicationItem)(item, True)
        ' </Snippet12>
    End Sub

    Public Shared Sub Snippet13()
        ' <Snippet13>
        Dim rssReader As XmlReader = XmlReader.Create("http://contoso/Feeds/RSS/MyFeed")
        Dim rssFormatter As New Rss20FeedFormatter()
        rssFormatter.ReadFrom(rssReader)
        rssReader.Close()
        ' </Snippet13>
    End Sub

    Public Shared Sub Snippet14()
        ' <Snippet14>
        Dim myFeedRssFormatter As New Rss20FeedFormatter(GetType(MySyndicationFeed))
        Dim rssReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        myFeedRssFormatter.ReadFrom(rssReader)
        rssReader.Close()
        ' </Snippet14>
    End Sub

    Public Shared Sub Snippet15()
        ' <Snippet15>
        Dim feedFormatter As New Rss20FeedFormatter()
        Dim rssReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        If feedFormatter.CanRead(rssReader) Then
            feedFormatter.ReadFrom(rssReader)
            rssReader.Close()
        End If
        ' </Snippet15>
    End Sub
End Class
