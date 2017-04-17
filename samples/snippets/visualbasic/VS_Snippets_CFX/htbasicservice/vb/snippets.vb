Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Web
Imports System.Text
Public Class Snippets
    Public Shared Sub Snippet4()
        Dim host As New WebServiceHost(GetType(Service), New Uri("http://localhost:8000/"))

        '<Snippet4>
        Dim sdb As ServiceDebugBehavior = host.Description.Behaviors.Find(Of ServiceDebugBehavior)()
        sdb.HttpHelpPageEnabled = False
        '</Snippet4>
    End Sub

    Public Shared Sub Snippet5()

        Dim host As New WebServiceHost(GetType(Service), New Uri("http://localhost:8000/"))

        '<Snippet5>
        host.Open()
        Console.WriteLine("Service is running")
        Console.WriteLine("Press enter to quit...")
        Console.ReadLine()
        host.Close()
        '</Snippet5>
    End Sub
End Class
