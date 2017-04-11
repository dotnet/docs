Imports System
Imports System.Collections.Specialized
Imports System.Net
Imports System.Collections
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Web

Public Class Snippets
    Public Shared Sub Snippet1()
    End Sub

    Public Shared Sub Snippet2()
        '<Snippet2>
        Dim current As WebOperationContext = WebOperationContext.Current
        Dim headers As WebHeaderCollection = current.IncomingRequest.Headers

        For Each name As String In headers
            Console.WriteLine(name + " " + headers.Get(name))
        Next
        '</Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        '<Snippet3>
        Dim current As WebOperationContext = WebOperationContext.Current
        Console.WriteLine("Incoming Response")
        Console.WriteLine("ContentLength: " + current.IncomingResponse.ContentLength)
        Console.WriteLine("ContentType: " + current.IncomingResponse.ContentType)
        Console.WriteLine("StatusCode: " + current.IncomingResponse.StatusCode)
        '</Snippet3>
    End Sub

    Public Shared Sub Snippet4()
        '<Snippet4>
        WebOperationContext.Current.OutgoingRequest.Headers.Add("Slug", "title")
        WebOperationContext.Current.OutgoingRequest.Method = "GET"
        WebOperationContext.Current.OutgoingRequest.ContentType = "application/octet-stream"
        '</Snippet4>
    End Sub
End Class
