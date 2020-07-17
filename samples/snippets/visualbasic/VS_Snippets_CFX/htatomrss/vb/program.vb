Imports System.Xml
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web
Imports System.Collections.Generic

' <Snippet0>
<ServiceContract()> _
<ServiceKnownType(GetType(Atom10FeedFormatter))> _
<ServiceKnownType(GetType(Rss20FeedFormatter))> _
Public Interface IBlog
    <OperationContract()> _
    <WebGet(UriTemplate:="GetBlog?format={format}")> _
    Function GetBlog(ByVal format As String) As SyndicationFeedFormatter
End Interface
' </Snippet0>
' <Snippet1>
Public Class BlogService
    implements IBlog

    Public Function GetBlog(ByVal format As String) As SyndicationFeedFormatter Implements IBlog.GetBlog
        ' <Snippet2>
        Dim feed As New SyndicationFeed("My Blog Feed", "This is a test feed", New Uri("http://SomeURI"))
        feed.Authors.Add(New SyndicationPerson("someone@microsoft.com"))
        feed.Categories.Add(New SyndicationCategory("How To Sample Code"))
        feed.Description = New TextSyndicationContent("This is a sample that demonstrates how to expose a feed through RSS and Atom with WCF")
        ' </Snippet2>
        ' <Snippet3>
        Dim item1 As New SyndicationItem( _
            "Item One", _
            "This is the content for item one", _
            New Uri("http://localhost/Content/One"), _
            "ItemOneID", _
            DateTime.Now)

        Dim item2 As New SyndicationItem( _
            "Item Two", _
            "This is the content for item two", _
            New Uri("http://localhost/Content/Two"), _
            "ItemTwoID", _
            DateTime.Now)

        Dim item3 As New SyndicationItem( _
            "Item Three", _
            "This is the content for item three", _
            New Uri("http://localhost/Content/three"), _
            "ItemThreeID", _
            DateTime.Now)
        ' </Snippet3>
        ' <Snippet4>
        Dim items As New List(Of SyndicationItem)()
        items.Add(item1)
        items.Add(item2)
        items.Add(item3)

        feed.Items = items
        ' </Snippet4>

        ' <Snippet5>
        If (format = "rss") Then
            Return New Rss20FeedFormatter(feed)
        Else
            Return New Atom10FeedFormatter(feed)
        End If
        ' </Snippet5>
    End Function
End Class
' </Snippet1>

Module Program

    Sub Main()
        ' <Snippet6>
        Dim address As New Uri("http://localhost:8000/BlogService/")
        Dim svcHost As New WebServiceHost(GetType(BlogService), address)
        ' </Snippet6>
        Try
            ' <Snippet8>
            svcHost.Open()
            Console.WriteLine("Service is running")

            Console.WriteLine("Loading feed in Atom 1.0 format.")
            Dim atomReader As XmlReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog?format=atom")
            Dim atomFeed As SyndicationFeed = SyndicationFeed.Load(atomReader)
            Console.WriteLine(atomFeed.Title.Text)
            Console.WriteLine("Items:")
            For Each item As SyndicationItem In atomFeed.Items
                Console.WriteLine("Title: {0}", item.Title.Text)
                Console.WriteLine("Content: {0}", CType(item.Content, TextSyndicationContent).Text)
            Next

            Console.WriteLine("Loading feed in RSS 2.0 format.")
            Dim rssReader As XmlReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog?format=rss")
            Dim rssFeed As SyndicationFeed = SyndicationFeed.Load(rssReader)
            Console.WriteLine(rssFeed.Title.Text)
            Console.WriteLine("Items:")
            For Each item As SyndicationItem In rssFeed.Items
                Console.WriteLine("Title: {0}", item.Title.Text)
                Console.WriteLine("Content: {0}", CType(item.Content, TextSyndicationContent).Text)
            Next


            Console.WriteLine("Press <ENTER> to quit...")
            Console.ReadLine()
            svcHost.Close()
            ' </Snippet8>
        Catch ce As CommunicationException
            Console.WriteLine("An exception occurred: {0}", ce.Message)
            svcHost.Abort()
        End Try
    End Sub

End Module
