' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Threading

Module Example15
    <ThreadStatic> Dim previous As Double = 0.0
    <ThreadStatic> Dim perThreadCtr As Integer = 0
    <ThreadStatic> Dim perThreadTotal As Double = 0.0
    Dim source As New CancellationTokenSource()
    Dim countdown As New CountdownEvent(1)
    Dim randLock As New Object()
    Dim numericLock As New Object()
    Dim rand As New Random()
    Dim totalValue As Double = 0.0
    Dim totalCount As Integer = 0

    Public Sub Main()
        Thread.CurrentThread.Name = "Main"

        Dim token As CancellationToken = source.Token
        For threads As Integer = 1 To 10
            Dim newThread As New Thread(AddressOf GetRandomNumbers)
            newThread.Name = threads.ToString()
            newThread.Start(token)
        Next
        GetRandomNumbers(token)

        countdown.Signal()
        ' Make sure all threads have finished.
        countdown.Wait()

        Console.WriteLine()
        Console.WriteLine("Total random numbers generated: {0:N0}", totalCount)
        Console.WriteLine("Total sum of all random numbers: {0:N2}", totalValue)
        Console.WriteLine("Random number mean: {0:N4}", totalValue / totalCount)
    End Sub

    Private Sub GetRandomNumbers(o As Object)
        Dim token As CancellationToken = CType(o, CancellationToken)
        Dim result As Double = 0.0
        countdown.AddCount(1)

        Try
            For ctr As Integer = 1 To 2000000
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
                perThreadCtr += 1
                perThreadTotal += result
            Next

            Console.WriteLine("Thread {0} finished execution.",
                           Thread.CurrentThread.Name)
            Console.WriteLine("Random numbers generated: {0:N0}", perThreadCtr)
            Console.WriteLine("Sum of random numbers: {0:N2}", perThreadTotal)
            Console.WriteLine("Random number mean: {0:N4}", perThreadTotal / perThreadCtr)
            Console.WriteLine()

            ' Update overall totals.
            SyncLock numericLock
                totalCount += perThreadCtr
                totalValue += perThreadTotal
            End SyncLock
        Catch e As OperationCanceledException
            Console.WriteLine("Corruption in Thread {1}", e.GetType().Name, Thread.CurrentThread.Name)
        Finally
            countdown.Signal()
            source.Dispose()
        End Try
    End Sub
End Module
' The example displays output like the following:
'       Thread 6 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,491.05
'       Random number mean: 0.5002
'       
'       Thread 10 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,329.64
'       Random number mean: 0.4997
'       
'       Thread 4 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,166.89
'       Random number mean: 0.5001
'       
'       Thread 8 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,628.37
'       Random number mean: 0.4998
'       
'       Thread Main finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,920.89
'       Random number mean: 0.5000
'       
'       Thread 3 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,370.45
'       Random number mean: 0.4997
'       
'       Thread 7 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,330.92
'       Random number mean: 0.4997
'       
'       Thread 9 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,172.79
'       Random number mean: 0.5001
'       
'       Thread 5 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 1,000,079.43
'       Random number mean: 0.5000
'       
'       Thread 1 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,817.91
'       Random number mean: 0.4999
'       
'       Thread 2 finished execution.
'       Random numbers generated: 2,000,000
'       Sum of random numbers: 999,930.63
'       Random number mean: 0.5000
'       
'       
'       Total random numbers generated: 22,000,000
'       Total sum of all random numbers: 10,998,238.98
'       Random number mean: 0.4999
' </Snippet3>

