Imports System
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web
Imports System.Collections.ObjectModel
Imports System.Collections.Generic

Public Class Snippets
    Public Shared Sub Snippet9()
        '<Snippet9>
        Dim serviceAddress As New Uri("http://localhost:8000/BlogService/GetBlog")
        '</Snippet9>
    End Sub

    Public Shared Sub Snippet10()
        '<Snippet10>
        Dim reader As XmlReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog")
        Dim feed As SyndicationFeed = SyndicationFeed.Load(reader)
        '</Snippet10>
        '<Snippet11>
        Console.WriteLine(feed.Title.Text)
        Console.WriteLine("Items:")
        For Each item As SyndicationItem In feed.Items
            Console.WriteLine("Title:  {0}", item.Title.Text)
            Console.WriteLine("Summary:  {0}", item.Summary.Text)
        Next
        '</Snippet11>
    End Sub
End Class
