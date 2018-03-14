' Visual Basic .NET Document
Option Strict On

'How to: Cancel by Registering a Callback
'<snippet8>
Imports System.Net
Imports System.Threading
Imports System.Threading.Tasks

Class CancelWithCallback
   Shared Sub Main()
      Dim cts As New CancellationTokenSource()

      ' Start cancelable task.
      Dim t As Task = Task.Run(Sub() DoWork(cts.Token))

      Console.WriteLine("Press 'c' to cancel.")
      Dim ch As Char = Console.ReadKey(True).KeyChar
      If ch = "c"c Then
         cts.Cancel()
      End If
      Console.WriteLine("Press any key to exit.")
      Console.ReadKey()
      cts.Dispose()
   End Sub

   Shared Sub DoWork(ByVal token As CancellationToken)
      Dim wc As New WebClient()

      ' Create an event handler to receive the result.
      AddHandler wc.DownloadStringCompleted, Sub(obj, e)
            ' Check status of WebClient, not external token
            If e.Cancelled = False Then
               Console.WriteLine(e.Result + vbCrLf + "Press any key.")
            Else
               Console.WriteLine("Download was canceled.")
            End If
         End Sub

      token.Register(Sub() wc.CancelAsync())

      Console.WriteLine("Starting request")
      wc.DownloadStringAsync(New Uri("http://www.contoso.com"))
   End Sub
End Class
'</snippet8>
