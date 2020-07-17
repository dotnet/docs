' <Snippet12>
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web
Imports System.Collections.ObjectModel
Imports System.Collections.Generic

' <Snippet0>
<ServiceContract()> _
Public Interface IBlog
    <OperationContract()> _
    <WebGet> _
    Function GetBlog() As Rss20FeedFormatter
End Interface
' </Snippet0>

' <Snippet1>
Public Class BlogService
    Implements IBlog

    Public Function GetBlog() As Rss20FeedFormatter Implements IBlog.GetBlog
        ' <Snippet2>
        Dim feed As SyndicationFeed = New SyndicationFeed("My Blog Feed", "This is a test feed", New Uri("http://SomeURI"))
        feed.Authors.Add(New SyndicationPerson("someone@microsoft.com"))
        feed.Categories.Add(New SyndicationCategory("How To Sample Code"))
        feed.Description = New TextSyndicationContent("This is a how to sample that demonstrates how to expose a feed using RSS with WCF")
        ' </Snippet2>

        ' <Snippet3>
        Dim item1 As SyndicationItem = New SyndicationItem( _
            "Item One", _
            "This is the content for item one", _
            New Uri("http://localhost/Content/One"), _
            "ItemOneID", _
            DateTime.Now)

        Dim item2 As SyndicationItem = New SyndicationItem( _
            "Item Two", _
            "This is the content for item two", _
            New Uri("http://localhost/Content/Two"), _
            "ItemTwoID", _
            DateTime.Now)

        Dim item3 As SyndicationItem = New SyndicationItem( _
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
        Return New Rss20FeedFormatter(feed)
        ' </Snippet5>
    End Function
End Class
' </Snippet1>


Module Program

    Sub Main()
        ' <Snippet6>
        Dim baseAddress As New Uri("http://localhost:8000/BlogService")
        Dim svcHost As New WebServiceHost(GetType(BlogService), baseAddress)
        ' </Snippet6>

        Try
            ' <Snippet8>
            svcHost.Open()
            Console.WriteLine("Service is running")

            Dim reader As XmlReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog")
            Dim feed As SyndicationFeed = SyndicationFeed.Load(reader)
            Console.WriteLine(feed.Title.Text)
            Console.WriteLine("Items:")
            For Each item As SyndicationItem In feed.Items
                Console.WriteLine("Title: {0}", item.Title.Text)
                Console.WriteLine("Summary: {0}", item.Summary.Text)
            Next
            Console.WriteLine("Press <enter> to quit...")
            Console.ReadLine()
            svcHost.Close()
            ' </Snippet8>
        Catch ce As CommunicationException
            Console.WriteLine("An exception occurred: {0}", ce.Message)
            svcHost.Abort()
        End Try
    End Sub
End Module
' </Snippet12>
