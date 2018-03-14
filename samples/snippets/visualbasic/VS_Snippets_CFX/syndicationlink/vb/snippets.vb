Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Syndication

Public Class Snippets
    Public Shared Sub Snippet0()
        '<Snippet0>
        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)

        Dim link As SyndicationLink = New SyndicationLink(New Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000)
        feed.Links.Add(link)
        '</Snippet0>
    End Sub

    Public Shared Sub Snippet1()
        '<Snippet1>
        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)

        Dim link As SyndicationLink = New SyndicationLink(New Uri("http://server/link"))
        feed.Links.Add(link)
        '</Snippet1>

    End Sub

    Public Shared Sub Snippet4()
        '<Snippet4>
        Dim link As SyndicationLink = SyndicationLink.CreateAlternateLink(New Uri("http://server/link"))
        '</Snippet4>
    End Sub

    Public Shared Sub Snippet5()
        '<Snippet5>
        Dim link As SyndicationLink = SyndicationLink.CreateAlternateLink(New Uri("http://server/link"), "text/html")
        '</Snippet5>
    End Sub

    Public Shared Sub Snippet6()
        '<Snippet6>
        Dim link As SyndicationLink = SyndicationLink.CreateMediaEnclosureLink(New Uri("http://server/link"), "audio/mpeg", 100000)
        '</Snippet6>
    End Sub

    Public Shared Sub Snippet7()
        '<Snippet7>
        Dim link As SyndicationLink = SyndicationLink.CreateSelfLink(New Uri("http://server/link"))
        '</Snippet7>
    End Sub

    Public Shared Sub Snippet8()
        '<Snippet8>
        Dim link As SyndicationLink = SyndicationLink.CreateSelfLink(New Uri("http://server/link"), "text/html")
        '</Snippet8>
    End Sub

End Class
