' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example4
    Public Sub Main()
        Dim tasks As New List(Of Task)()
        Dim rnd As New Random()
        Dim total As Long = 0
        Dim n As Integer = 0

        For taskCtr As Integer = 0 To 9
            tasks.Add(Task.Run(Sub()
                                   Dim values(9999) As Integer
                                   Dim taskTotal As Integer = 0
                                   Dim taskN As Integer = 0
                                   Dim ctr As Integer = 0
                                   Monitor.Enter(rnd)
                                   ' Generate 10,000 random integers.
                                   For ctr = 0 To 9999
                                       values(ctr) = rnd.Next(0, 1001)
                                   Next
                                   Monitor.Exit(rnd)
                                   taskN = ctr
                                   For Each value In values
                                       taskTotal += value
                                   Next

                                   Console.WriteLine("Mean for task {0,2}: {1:N2} (N={2:N0})",
                                                  Task.CurrentId, taskTotal / taskN,
                                                  taskN)
                                   Interlocked.Add(n, taskN)
                                   Interlocked.Add(total, taskTotal)
                               End Sub))
        Next

        Try
            Task.WaitAll(tasks.ToArray())
            Console.WriteLine()
            Console.WriteLine("Mean for all tasks: {0:N2} (N={1:N0})",
                           (total * 1.0) / n, n)
        Catch e As AggregateException
            For Each ie In e.InnerExceptions
                Console.WriteLine("{0}: {1}", ie.GetType().Name, ie.Message)
            Next
        End Try
    End Sub
End Module
' The example displays output like the following:
'       Mean for task  1: 499.04 (N=10,000)
'       Mean for task  2: 500.42 (N=10,000)
'       Mean for task  3: 499.65 (N=10,000)
'       Mean for task  8: 502.59 (N=10,000)
'       Mean for task  5: 502.75 (N=10,000)
'       Mean for task  4: 494.88 (N=10,000)
'       Mean for task  7: 499.22 (N=10,000)
'       Mean for task 10: 496.45 (N=10,000)
'       Mean for task  6: 499.75 (N=10,000)
'       Mean for task  9: 502.79 (N=10,000)
'
'       Mean for all tasks: 499.75 (N=100,000)
' </Snippet1>
