Imports System
Imports System.Xml
Imports System.Collections.ObjectModel
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web

Public Class Snippets
    Public Shared Sub Snippet9()

        '<Snippet9>
        Dim atomReader As XmlReader = XmlReader.Create("http://localhost:8000/BlogService/GetBlog?format=atom")
        '</Snippet9>
        '<Snippet10>
        Dim feed As SyndicationFeed = SyndicationFeed.Load(atomReader)
        '</Snippet10>
        '<Snippet11>
        Console.WriteLine(feed.Title.Text)
        Console.WriteLine("Items:")
        For Each item As SyndicationItem In feed.Items
            Console.WriteLine("Title: {0}", item.Title.Text)
            Console.WriteLine("Content: {0}", (CType(item.Content, TextSyndicationContent).Text))
        Next
        '</Snippet11>
    End Sub
End Class
