'<Snippet1>
Imports System
Imports System.Threading

Public Class Example

    <MTAThread> _
    Public Shared Sub Main()
        ' Create a Semaphore object that represents the named 
        ' system semaphore "SemaphoreExample3". The semaphore has a
        ' maximum count of five. The initial count is also five. 
        ' There is no point in using a smaller initial count,
        ' because the initial count is not used if this program
        ' doesn't create the named system semaphore, and with 
        ' this method overload there is no way to tell. Thus, this
        ' program assumes that it is competing with other
        ' programs for the semaphore.
        '
        Dim sem As New Semaphore(5, 5, "SemaphoreExample3")

        ' Attempt to enter the semaphore three times. If another 
        ' copy of this program is already running, only the first
        ' two requests can be satisfied. The third blocks. Note 
        ' that in a real application, timeouts should be used
        ' on the WaitOne calls, to avoid deadlocks.
        '
        sem.WaitOne()
        Console.WriteLine("Entered the semaphore once.")
        sem.WaitOne()
        Console.WriteLine("Entered the semaphore twice.")
        sem.WaitOne()
        Console.WriteLine("Entered the semaphore three times.")

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