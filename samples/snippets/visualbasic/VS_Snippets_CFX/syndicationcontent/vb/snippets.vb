Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Syndication

Public Class Snippets
    Public Shared Sub Snippet0()
        '<Snippet0>
        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)

        feed.Copyright = New TextSyndicationContent("Copyright 2007")
        feed.Description = New TextSyndicationContent("This is a sample feed")

        Dim textContent As TextSyndicationContent = New TextSyndicationContent("Some text content")
        Dim item As SyndicationItem = New SyndicationItem("Item Title", textContent, New Uri("http://server/items"), "ItemID", DateTime.Now)
        '</Snippet0>
    End Sub

    Public Shared Sub Snippet1()
        '<Snippet1>
        Dim textContent As TextSyndicationContent = New TextSyndicationContent("Some text content")
        '</Snippet1>

        '<Snippet2>
        Dim textContent2 As TextSyndicationContent = New TextSyndicationContent("Some text content", TextSyndicationContentKind.Plaintext)
        '</Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        '<Snippet3>
        Dim urlContent As UrlSyndicationContent = New UrlSyndicationContent(New Uri("http://localhost/content"), "text/html")
        '</Snippet3>
    End Sub
End Class
