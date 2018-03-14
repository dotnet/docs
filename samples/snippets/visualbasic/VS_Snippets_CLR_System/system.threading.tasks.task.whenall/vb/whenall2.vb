' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections.Generic
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tasks(9) As Task(Of Long)
      For ctr As Integer = 1 To 10
         Dim delayInterval As Integer = 18 * ctr
         tasks(ctr - 1) =Task.Run(Async Function()
                                     Dim total As Long = 0
                                     Await Task.Delay(delayInterval)
                                     Dim rnd As New Random()
                                     ' Generate 1,000 random numbers.
                                     For n As Integer = 1 To 1000
                                        total += rnd.Next(0, 1000)
                                     Next
                                     Return total
                                  End Function)
      Next
      Dim continuation = Task.WhenAll(tasks)
      Try
         continuation.Wait()
      Catch ae As AggregateException
      End Try
         
      If continuation.Status = TaskStatus.RanToCompletion Then
         Dim grandTotal As Long = 0
         For Each result in continuation.Result
            grandTotal += result
            Console.WriteLine("Mean: {0:N2}, n = 1,000", result/1000)
         Next
         Console.WriteLine()
         Console.WriteLine("Mean of Means: {0:N2}, n = 10,000",
                           grandTotal/10000)
      ' Display information on faulted tasks.
      Else 
         For Each t In tasks
            Console.WriteLine("Task {0}: {1}", t.Id, t.Status)
         Next
      End If
   End Sub
End Module
' The example displays output like the following:
'       Mean: 506.38, n = 1,000
'       Mean: 501.01, n = 1,000
'       Mean: 505.36, n = 1,000
'       Mean: 492.00, n = 1,000
'       Mean: 508.36, n = 1,000
'       Mean: 503.99, n = 1,000
'       Mean: 504.95, n = 1,000
'       Mean: 508.58, n = 1,000
'       Mean: 490.23, n = 1,000
'       Mean: 501.59, n = 1,000
'
'       Mean of Means: 502.00, n = 10,000
' </Snippet2>
