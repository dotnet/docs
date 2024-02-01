' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example16
    Dim source As New CancellationTokenSource()
    Dim randLock As New Object()
    Dim numericLock As New Object()
    Dim rand As New Random()
    Dim totalValue As Double = 0.0
    Dim totalCount As Integer = 0

    Public Sub Main()
        Dim tasks As New List(Of Task)()

        For ctr As Integer = 1 To 10
            Dim token As CancellationToken = source.Token
            Dim taskNo As Integer = ctr
            tasks.Add(Task.Run(
                   Sub()
                       Dim previous As Double = 0.0
                       Dim taskCtr As Integer = 0
                       Dim taskTotal As Double = 0.0
                       Dim result As Double = 0.0

                       For n As Integer = 1 To 2000000
                           ' Make sure there's no corruption of Random.
                           token.ThrowIfCancellationRequested()

                           SyncLock randLock
                               result = rand.NextDouble()
                           End SyncLock
                           ' Check for corruption of Random instance.
                           If result = previous AndAlso result = 0 Then
                               source.Cancel()
                           Else
                               previous = result
                           End If
                           taskCtr += 1
                           taskTotal += result
                       Next

                       ' Show result.
                       Console.WriteLine("Task {0} finished execution.", taskNo)
                       Console.WriteLine("Random numbers generated: {0:N0}", taskCtr)
                       Console.WriteLine("Sum of random numbers: {0:N2}", taskTotal)
                       Console.WriteLine("Random number mean: {0:N4}", taskTotal / taskCtr)
                       Console.WriteLine()

                       ' Update overall totals.
                       SyncLock numericLock
                           totalCount += taskCtr
                           totalValue += taskTotal
                       End SyncLock
                   End Sub, token))
        Next

        Try
            Task.WaitAll(tasks.ToArray())
            Console.WriteLine()
            Console.WriteLine("Total random numbers generated: {0:N0}", totalCount)
            Console.WriteLine("Total sum of all random numbers: {0:N2}", totalValue)
            Console.WriteLine("Random number mean: {0:N4}", totalValue / totalCount)
        Catch e As AggregateException
            For Each inner As Exception In e.InnerExceptions
                Dim canc As TaskCanceledException = TryCast(inner, TaskCanceledException)
                If canc IsNot Nothing Then
                    Console.WriteLine("Task #{0} cancelled.", canc.Task.Id)
                Else
                    Console.WriteLine("Exception: {0}", inner.GetType().Name)
                End If
            Next
        Finally
            source.Dispose()
        End Try
    End Sub
End Module
' The example displays output like the following:
'       Task 1 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,502.47
'       Random number mean: 0.5003
'       
'       Task 0 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,445.63
'       Random number mean: 0.5002
'       
'       Task 2 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,556.04
'       Random number mean: 0.5003
'       
'       Task 3 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,178.87
'       Random number mean: 0.5001
'       
'       Task 4 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,819.17
'       Random number mean: 0.4999
'       
'       Task 5 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,190.58
'       Random number mean: 0.5001
'       
'       Task 6 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,720.21
'       Random number mean: 0.4999
'       
'       Task 7 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,000.96
'       Random number mean: 0.4995
'       
'       Task 8 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,499.33
'       Random number mean: 0.4997
'       
'       Task 9 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,193.25
'       Random number mean: 0.5001
'       
'       Task 10 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,960.82
'       Random number mean: 0.5000
'       
'       
'       Total random numbers generated: 22,000,000
'       Total sum of all random numbers: 11,000,067.33
'       Random number mean: 0.5000
' </Snippet4>

