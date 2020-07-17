' Visual Basic .NET Document

' <Snippet1>
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Net

Class CancelWithCallback
    Shared Sub Main()
        Dim cts As New CancellationTokenSource()
        Dim token As CancellationToken = cts.Token

        ' Start cancelable task.
        Dim t As Task = Task.Run(
           Sub()
               Dim wc As New WebClient()

               ' Create an event handler to receive the result.
               AddHandler wc.DownloadStringCompleted,
                          Sub(obj, e)
                             ' Check status of WebClient, not external token.
                             If Not e.Cancelled Then
                                  Console.WriteLine("The download has completed:" + vbCrLf)
                                  Console.WriteLine(e.Result + vbCrLf + vbCrLf + "Press any key.")
                              Else
                                  Console.WriteLine("Download was canceled.")
                              End If
                          End Sub
               Using ctr As CancellationTokenRegistration = token.Register(Sub() wc.CancelAsync())
                   Console.WriteLine("Starting request..." + vbCrLf)
                   wc.DownloadStringAsync(New Uri("http://www.contoso.com"))
               End Using
           End Sub, token)

        Console.WriteLine("Press 'c' to cancel." + vbCrLf)
        Dim ch As Char = Console.ReadKey().KeyChar
        Console.WriteLine()

        If ch = "c"c Then
            cts.Cancel()
        End If
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
        cts.Dispose()
    End Sub
End Class
' </Snippet1>
