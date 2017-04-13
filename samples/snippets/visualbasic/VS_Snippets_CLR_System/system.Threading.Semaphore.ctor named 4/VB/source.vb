'<Snippet1>
Imports System
Imports System.Threading

Public Class Example

    <MTAThread> _
    Public Shared Sub Main()
        ' The value of this variable is set by the semaphore
        ' constructor. It is True if the named system semaphore was
        ' created, and False if the named semaphore already existed.
        '
        Dim semaphoreWasCreated As Boolean

        ' Create a Semaphore object that represents the named 
        ' system semaphore "SemaphoreExample". The semaphore has a
        ' maximum count of five, and an initial count of two. The
        ' Boolean value that indicates creation of the underlying 
        ' system object is placed in semaphoreWasCreated.
        '
        Dim sem As New Semaphore(2, 5, "SemaphoreExample", _
            semaphoreWasCreated)

        If semaphoreWasCreated Then
            ' If the named system semaphore was created, its count is
            ' set to the initial count requested in the constructor.
            ' In effect, the current thread has entered the semaphore
            ' three times.
            ' 
            Console.WriteLine("Entered the semaphore three times.")
        Else
            ' If the named system semaphore was not created,  
            ' attempt to enter it three times. If another copy of
            ' this program is already running, only the first two
            ' requests can be satisfied. The third blocks.
            '
            sem.WaitOne()
            Console.WriteLine("Entered the semaphore once.")
            sem.WaitOne()
            Console.WriteLine("Entered the semaphore twice.")
            sem.WaitOne()
            Console.WriteLine("Entered the semaphore three times.")
        End If

        ' The thread executing this program has entered the 
        ' semaphore three times. If a second copy of the program
        ' is run, it will block until this program releases the 
        ' semaphore at least once.
        '
        Console.WriteLine("Enter the number of times to call Release.")
        Dim n As Integer
        If Integer.TryParse(Console.ReadLine(), n) Then
            sem.Release(n)
        End If

        Dim remaining As Integer = 3 - n
        If (remaining) > 0 Then
            Console.WriteLine("Press Enter to release the remaining " _
                & "count ({0}) and exit the program.", remaining)
            Console.ReadLine()
            sem.Release(remaining)
        End If

    End Sub 
End Class 
'</Snippet1>