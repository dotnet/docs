Imports System.Collections.Generic
Imports System.Diagnostics

'<snippet02>
Imports System.Threading
Imports System.Threading.Tasks

Class SpinLockDemo2

    Const N As Integer = 100000
    Shared _queue = New Queue(Of Data)()
    Shared _lock = New Object()
    Shared _spinlock = New SpinLock()

    Class Data
        Public Name As String
        Public Number As Double
    End Class
    Shared Sub Main()

        ' First use a standard lock for comparison purposes.
        UseLock()
        _queue.Clear()
        UseSpinLock()

        Console.WriteLine("Press a key")
        Console.ReadKey()

    End Sub

    Private Shared Sub UpdateWithSpinLock(ByVal d As Data, ByVal i As Integer)

        Dim lockTaken As Boolean = False
        Try
            _spinlock.Enter(lockTaken)
            _queue.Enqueue(d)
        Finally

            If lockTaken Then
                _spinlock.Exit(False)
            End If
        End Try
    End Sub

    Private Shared Sub UseSpinLock()


        Dim sw = Stopwatch.StartNew()

        Parallel.Invoke(
               Sub()
                   For i As Integer = 0 To N - 1
                       UpdateWithSpinLock(New Data() With {.Name = i.ToString(), .Number = i}, i)
                   Next
               End Sub,
                Sub()
                    For i As Integer = 0 To N - 1
                        UpdateWithSpinLock(New Data() With {.Name = i.ToString(), .Number = i}, i)
                    Next
                End Sub
            )
        sw.Stop()
        Console.WriteLine("elapsed ms with spinlock: {0}", sw.ElapsedMilliseconds)
    End Sub

    Shared Sub UpdateWithLock(ByVal d As Data, ByVal i As Integer)

        SyncLock (_lock)
            _queue.Enqueue(d)
        End SyncLock
    End Sub

    Private Shared Sub UseLock()

        Dim sw = Stopwatch.StartNew()

        Parallel.Invoke(
                Sub()
                    For i As Integer = 0 To N - 1
                        UpdateWithLock(New Data() With {.Name = i.ToString(), .Number = i}, i)
                    Next
                End Sub,
               Sub()
                   For i As Integer = 0 To N - 1
                       UpdateWithLock(New Data() With {.Name = i.ToString(), .Number = i}, i)
                   Next
               End Sub
                )
        sw.Stop()
        Console.WriteLine("elapsed ms with lock: {0}", sw.ElapsedMilliseconds)
    End Sub
End Class
'</snippet02>

