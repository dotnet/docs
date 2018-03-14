' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim cts As New CancellationTokenSource
      Dim token As CancellationToken = cts.Token
      
      Task.Run( Sub()
                   cts.Cancel
                   If token.IsCancellationRequested Then
                      Console.WriteLine("Cancellation requested in Task {0}.", 
                                        Task.CurrentId)
                   End If      
                End Sub, token)
      Dim t2 As Task = Task.Run( Sub()
                                    For ctr As Integer = 0 To Int32.MaxValue
                                    Next
                                    Console.WriteLine("Task {0} finished.",
                                                      Task.CurrentId)
                                 End Sub)
      Try
         t2.Wait(token)
      Catch e As OperationCanceledException
         Console.WriteLine("OperationCanceledException in Task {0}: The operation was cancelled.",
                           t2.Id)
      Finally
         cts.Dispose()
      End Try
   End Sub
End Module
' The example displays the following output:
'       Cancellation requested in Task 1.
'       OperationCanceledException in Task 2: The operation was cancelled.
' </Snippet2>
