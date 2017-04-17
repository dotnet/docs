' Visual Basic .NET Document
Option Strict On

Imports System.Net
Imports System.Threading.Tasks

Class Example
    ' <Snippet11>
    Public Shared Function DownloadStringAsync(url As Uri) As Task(Of String)
        Dim tcs As New TaskCompletionSource(Of String)()
        Dim wc As New WebClient()
        AddHandler wc.DownloadStringCompleted, Sub(s,e) 
                If e.Error IsNot Nothing Then 
                   tcs.TrySetException(e.Error)
                ElseIf e.Cancelled Then 
                   tcs.TrySetCanceled()
                Else 
                   tcs.TrySetResult(e.Result)
                End If   
            End Sub
        wc.DownloadStringAsync(url)
        Return tcs.Task
   End Function
   ' </Snippet11>
End Class

