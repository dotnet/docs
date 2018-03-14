' Visual Basic .NET Document
'
' Example for Task.Run(Func<T>, CancellationToken)
Option Strict On

' <Snippet9>
Imports System.Collections.Generic
Imports System.Numerics
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim tasks As New List(Of Task(Of BigInteger()))
      Dim source As New CancellationTokenSource
      Dim token As CancellationToken = source.Token
      For ctr As Integer = 0 To 1
         Dim start As Integer = ctr
         tasks.Add(Task.Run(Function()
                               Dim sequence(99) As BigInteger
                               sequence(0) = start
                               sequence(1) = 1
                               For index As Integer = 2 To sequence.GetUpperBound(0)
                                  token.ThrowIfCancellationRequested()
                                  sequence(index) = sequence(index - 1) + sequence(index - 2)
                               Next
                               Return sequence
                            End Function, token))
      Next
      If rnd.Next(0, 2) = 1 Then source.Cancel
      Try
         Task.WaitAll(tasks.ToArray())
         For Each t In tasks
            Console.WriteLine("{0}, {1}...{2:N0}", t.Result(0), t.Result(1),
                              t.Result(99))
         Next
      Catch e As AggregateException
         For Each ex In e.InnerExceptions
            Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message)
         Next
      End Try
   End Sub
End Module
' The example displays either the following output:
'    0, 1...218,922,995,834,555,169,026
'    1, 1...354,224,848,179,261,915,075
' or the following output:
'    TaskCanceledException: A task was canceled.
'    TaskCanceledException: A task was canceled.
' </Snippet9>
