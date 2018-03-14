' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet3>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim source As New CancellationTokenSource()
      
      Dim t = Task.Run(Async Function()
                                Await Task.Delay(1000, source.Token)
                                Return 42
                       End Function)
      source.Cancel()
      Try
         t.Wait()
      Catch ae As AggregateException
         For Each e In ae.InnerExceptions
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
         Next
      End Try
      Console.Write("Task t Status: {0}", t.Status)
      If t.Status = TaskStatus.RanToCompletion Then
         Console.Write(", Result: {0}", t.Result)
      End If
      source.Dispose()
   End Sub
End Module
' The example displays the following output:
'       TaskCanceledException: A task was canceled.
'       Task t Status: Canceled
' </Snippet3>
