'<Snippet1>
Imports System
Imports System.Management

' This example demonstrates how
' to perform an asynchronous instance enumeration.

Public Class EnumerateInstancesAsync

    Public Sub New()

        Me.isCompleted = False

        ' Enumerate asynchronously using Object Searcher
        ' ===============================================

        ' Instantiate an object searcher with the query
        Dim searcher As ManagementObjectSearcher
        searcher = New ManagementObjectSearcher( _
            New SelectQuery("Win32_Service"))

        ' Create a results watcher object, 
        ' and handler for results and completion
        Dim results As ManagementOperationObserver
        results = New ManagementOperationObserver

        ' Attach handler to events for
        ' results and completion
        AddHandler results.ObjectReady, _
            AddressOf Me.NewObject
        AddHandler results.Completed, _
            AddressOf Me.Done

        ' Call the asynchronous overload of
        ' Get() to start the enumeration
        searcher.Get(results)

        ' Do something else while results 
        ' arrive(asynchronously)
        Do While (Me.Completed.Equals(False))

            System.Threading.Thread.Sleep(1000)
        Loop

        Me.Reset()

    End Sub

    Private isCompleted As Boolean

    Private Sub NewObject(ByVal sender As Object, _
        ByVal e As ObjectReadyEventArgs)

        Console.WriteLine("Service : {0}, State = {1}", _
         e.NewObject("Name"), e.NewObject("State"))
    End Sub

    Private ReadOnly Property Completed() As Boolean
        Get
            Return isCompleted
        End Get
    End Property

    Private Sub Reset()

        isCompleted = False
    End Sub

    Private Sub Done(ByVal sender As Object, _
        ByVal e As CompletedEventArgs)

        isCompleted = True
    End Sub


    Public Shared Function _
        Main(ByVal args() As String) As Integer

        Dim example As New EnumerateInstancesAsync

        Return 0

    End Function

End Class
'</Snippet1>