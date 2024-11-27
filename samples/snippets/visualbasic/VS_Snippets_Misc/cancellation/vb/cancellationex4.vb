' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Net
Imports System.Net.Http
Imports System.Threading

Class Example4
    Private Shared Sub Main4()
        Dim cts As New CancellationTokenSource()

        StartWebRequest(cts.Token)

        ' cancellation will cause the web 
        ' request to be cancelled
        cts.Cancel()
    End Sub

    Private Shared Sub StartWebRequest(token As CancellationToken)
        Dim client As New HttpClient()

        token.Register(Sub()
                           client.CancelPendingRequests()
                           Console.WriteLine("Request cancelled!")
                       End Sub)

        Console.WriteLine("Starting request.")
        client.GetStringAsync(New Uri("http://www.contoso.com"))
    End Sub
End Class
' </Snippet4>
