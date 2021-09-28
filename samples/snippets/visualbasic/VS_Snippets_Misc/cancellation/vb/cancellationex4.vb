' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Net
Imports System.Threading

Class Example
    Private Shared Sub Main()
        Dim cts As New CancellationTokenSource()

        StartWebRequest(cts.Token)

        ' cancellation will cause the web 
        ' request to be cancelled
        cts.Cancel()
    End Sub

    Private Shared Sub StartWebRequest(token As CancellationToken)
        Dim wc As New WebClient()
        wc.DownloadStringCompleted += Function(s, e) Console.WriteLine("Request completed.")

        ' Cancellation on the token will 
        ' call CancelAsync on the WebClient.
        token.Register(Function()
                           wc.CancelAsync()
                           Console.WriteLine("Request cancelled!")

                       End Function)

        Console.WriteLine("Starting request.")
        wc.DownloadStringAsync(New Uri("http://www.contoso.com"))
    End Sub
End Class
' </Snippet4>
