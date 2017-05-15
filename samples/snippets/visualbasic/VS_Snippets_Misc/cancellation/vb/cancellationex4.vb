' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System
Imports System.Net
Imports System.Threading
Imports System.Threading.Tasks

Class Example
    Public Shared Event externalEvent(ByVal sender As Object, ByVal obj As Object)

    Public Sub Example1()
        Dim cts As New CancellationTokenSource()
        AddHandler externalEvent, Sub(sender, obj) cts.Cancel()

        Try
            Dim val As Integer = LongRunningFunc(cts.Token)
        Catch oce As OperationCanceledException
            'cleanup after cancellation if required...
            Console.WriteLine("Operation was canceled as expected.")
        Finally
           cts.Dispose()
        End Try
    End Sub

    Private Shared Function LongRunningFunc(ByVal token As CancellationToken) As Integer
        Console.WriteLine("Long running method")
        Dim total As Integer = 0
        For i As Integer = 0 To 1000000
            For j As Integer = 0 To 1000000
                total = total + total
            Next
            If token.IsCancellationRequested Then
                ' observe cancellation
                Console.WriteLine("Cancellation observed.")
                Throw New OperationCanceledException(token) ' acknowledge cancellation
            End If
        Next
        Console.WriteLine("Done looping")
        Return total
    End Function

    Shared Sub Main()
        Dim ex As New Example()
        Dim t As Thread
        t = New Thread(AddressOf ex.Example1)
        t.Start()

        Console.WriteLine("Press 'c' to cancel.")
        If Console.ReadKey(True).KeyChar = "c"c Then
            RaiseEvent externalEvent(ex, New EventArgs())

            Console.WriteLine("Press enter to exit.")
            Console.ReadLine()
        End If
    End Sub
End Class

Class MyCancelableObject

    Public Sub Cancel()
    End Sub

    Shared Sub ObjectCancellationMiniSnippetForOverview()


    End Sub
End Class
Class CancelWaitHandleMiniSnippetsForOverviewTopic

    Shared Sub CancelByCallback()
        Dim cts As New CancellationTokenSource()
        Dim token As CancellationToken = cts.Token
        Dim wc As New WebClient()

        ' To request cancellation on the token
        ' will call CancelAsync on the WebClient.
        token.Register(Sub() wc.CancelAsync())

        Console.WriteLine("Starting request")
        wc.DownloadStringAsync(New Uri("http://www.contoso.com"))
    End Sub
End Class
' </Snippet4>