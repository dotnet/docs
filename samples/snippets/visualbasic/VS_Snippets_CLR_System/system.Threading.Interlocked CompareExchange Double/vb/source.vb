'<Snippet1>
' This example demonstrates a thread-safe method that adds to a
' running total.  
Imports System.Threading

Public Class ThreadSafe
    ' Field totalValue contains a running total that can be updated
    ' by multiple threads. It must be protected from unsynchronized 
    ' access.
    Private totalValue As Double = 0.0

    ' The Total property returns the running total.
    Public ReadOnly Property Total As Double
        Get
            Return totalValue
        End Get
    End Property

    ' AddToTotal safely adds a value to the running total.
    Public Function AddToTotal(ByVal addend As Double) As Double
        Dim initialValue, computedValue As Double
        Do
            ' Save the current running total in a local variable.
            initialValue = totalValue

            ' Add the new value to the running total.
            computedValue = initialValue + addend

            ' CompareExchange compares totalValue to initialValue. If
            ' they are not equal, then another thread has updated the
            ' running total since this loop started. CompareExchange
            ' does not update totalValue. CompareExchange returns the
            ' contents of totalValue, which do not equal initialValue,
            ' so the loop executes again.
        Loop While initialValue <> Interlocked.CompareExchange( _
            totalValue, computedValue, initialValue)
        ' If no other thread updated the running total, then 
        ' totalValue and initialValue are equal when CompareExchange
        ' compares them, and computedValue is stored in totalValue.
        ' CompareExchange returns the value that was in totalValue
        ' before the update, which is equal to initialValue, so the 
        ' loop ends.

        ' The function returns computedValue, not totalValue, because
        ' totalValue could be changed by another thread between
        ' the time the loop ends and the function returns.
        Return computedValue
    End Function
End Class

Public Class Test
    ' Create an instance of the ThreadSafe class to test.
    Private Shared ts As New ThreadSafe()
    Private Shared control As Double

    Private Shared r As New Random()
    Private Shared mre As New ManualResetEvent(false)

    <MTAThread> _
    Public Shared Sub Main()
        ' Create two threads, name them, and start them. The
        ' threads will block on mre.
        Dim t1 As New Thread(AddressOf TestThread)
        t1.Name = "Thread 1"
        t1.Start()
        Dim t2 As New Thread(AddressOf TestThread)
        t2.Name = "Thread 2"
        t2.Start()

        ' Now let the threads begin adding random numbers to 
        ' the total.
        mre.Set()
        
        ' Wait until all the threads are done.
        t1.Join()
        t2.Join()

        Console.WriteLine("Thread safe: {0}  Ordinary Double: {1}", ts.Total, control)
    End Sub

    Private Shared Sub TestThread()
        ' Wait until the signal.
        mre.WaitOne()

        For i As Integer = 1 to 1000000
            ' Add to the running total in the ThreadSafe instance, and
            ' to an ordinary double.
            '
            Dim testValue As Double = r.NextDouble
            control += testValue
            ts.AddToTotal(testValue)
        Next
    End Sub
End Class

' On a dual-processor computer, this code example produces output 
' similar to the following:
'
'Thread safe: 998068.049623744  Ordinary Double: 759775.417190589
'</Snippet1>