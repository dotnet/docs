' Visual Basic .NET Document
'
' Check in to System.Threading.Tasks.Task.Run

Option Strict On

' Task.Run(Of TResult)(Func(Of TResult), CancellationToken)

' <Snippet8>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example

   Public Sub Main()
      Dim tasks As New List(Of Task(Of Integer))()
      Dim source As New CancellationTokenSource
      Dim token As CancellationToken = source.Token
      Dim completedIterations As Integer = 0
      
      For n As Integer = 0 To 19
         tasks.Add(Task.Run( Function()
                                Dim iterations As Integer= 0
                                For ctr As Long = 1 To 2000000
                                   If token.IsCancellationRequested Then
                                      Return iterations
                                   End If
                                   iterations += 1
                                Next
                                Interlocked.Increment(completedIterations)
                                If completedIterations >= 10 Then source.Cancel()
                                Return iterations
                             End Function, token))
      Next

      Try
         Task.WaitAll(tasks.ToArray())
      Catch e As AggregateException
         Console.WriteLine("Status of tasks:")
         Console.WriteLine()
         Console.WriteLine("{0,10} {1,20} {2,14:N0}", "Task Id",
                           "Status", "Iterations")
         For Each t In tasks
            Console.WriteLine("{0,10} {1,20} {2,14}",
                              t.Id, t.Status,
                              If(t.Status <> TaskStatus.Canceled,
                                 t.Result.ToString("N0"), "Not Started"))
         Next
      End Try
   End Sub
End Module
' The example displays output like the following:
'    Status of tasks:
'
'       Task Id               Status     Iterations
'             1      RanToCompletion      2,000,000
'             2      RanToCompletion      2,000,000
'             3      RanToCompletion      2,000,000
'             4      RanToCompletion      2,000,000
'             5      RanToCompletion      2,000,000
'             6      RanToCompletion      2,000,000
'             7      RanToCompletion      2,000,000
'             8      RanToCompletion      2,000,000
'             9      RanToCompletion      2,000,000
'            10      RanToCompletion      1,658,326
'            11      RanToCompletion      1,988,506
'            12      RanToCompletion      2,000,000
'            13      RanToCompletion      1,942,246
'            14      RanToCompletion        950,108
'            15      RanToCompletion      1,837,832
'            16      RanToCompletion      1,687,182
'            17      RanToCompletion        194,548
'            18             Canceled    Not Started
'            19             Canceled    Not Started
'            20             Canceled    Not Started
' </Snippet8>
