' Visual Basic .NET Document
'
' Check in to System.Threading.Tasks.Task.Run

Option Strict On

' Task.Run(Of TResult)(Func(Of TResult), CancellationToken)

' <Snippet7>
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
                                   token.ThrowIfCancellationRequested()
                                   iterations += 1
                                Next
                                Interlocked.Increment(completedIterations)
                                If completedIterations >= 10 Then source.Cancel()
                                Return iterations
                             End Function, token))
      Next

      Console.WriteLine("Waiting for the first 10 tasks to complete... ")
      Try
         Task.WaitAll(tasks.ToArray())
      Catch e As AggregateException
         Console.WriteLine("Status of tasks:")
         Console.WriteLine()
         Console.WriteLine("{0,10} {1,20} {2,14}", "Task Id",
                           "Status", "Iterations")
         For Each t In tasks
            Console.WriteLine("{0,10} {1,20} {2,14}",
                              t.Id, t.Status,
                              If(t.Status <> TaskStatus.Canceled,
                                 t.Result.ToString("N0"), "n/a"))
         Next
      End Try
   End Sub
End Module
' The example displays output like the following:
'    Waiting for the first 10 tasks to complete...
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
'            10             Canceled            n/a
'            11             Canceled            n/a
'            12             Canceled            n/a
'            13             Canceled            n/a
'            14             Canceled            n/a
'            15             Canceled            n/a
'            16      RanToCompletion      2,000,000
'            17             Canceled            n/a
'            18             Canceled            n/a
'            19             Canceled            n/a
'            20             Canceled            n/a
' </Snippet7>
