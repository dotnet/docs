'<Snippet1>
Imports System
Imports System.Threading

Public Class Example

    ' A semaphore that can satisfy at most two concurrent
    ' requests.
    '
    Private Shared _pool As New Semaphore(2, 2)

    <MTAThread> _
    Public Shared Sub Main()
        ' Create and start two threads, A and B. 
        '
        Dim tA As New Thread(AddressOf ThreadA)
        tA.Start()

        Dim tB As New Thread(AddressOf ThreadB)
        tB.Start()

    End Sub

    Private Shared Sub ThreadA()
        ' Thread A enters the semaphore and simulates a task
        ' that lasts a second.
        '
        _pool.WaitOne()
        Console.WriteLine("Thread A entered the semaphore.")

        Thread.Sleep(1000)

        Try
            _pool.Release()
            Console.WriteLine("Thread A released the semaphore.")
        Catch ex As Exception
            Console.WriteLine("Thread A: {0}", ex.Message)
        End Try
    End Sub

    Private Shared Sub ThreadB()
        ' Thread B simulates a task that lasts half a second,
        ' then enters the semaphore.
        '
        Thread.Sleep(500)

        _pool.WaitOne()
        Console.WriteLine("Thread B entered the semaphore.")
        
        ' Due to a programming error, Thread B releases the
        ' semaphore twice. To fix the program, delete one line.
        _pool.Release()
        _pool.Release()
        Console.WriteLine("Thread B exits successfully.")
    End Sub
End Class
' This code example produces the following output:
'
' Thread A entered the semaphore.
' Thread B entered the semaphore.
' Thread B exits successfully.
' Thread A: Adding the given count to the semaphore would cause it to exceed its maximum count.
'
'</Snippet1>
