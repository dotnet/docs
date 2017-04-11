' How to: Use a Thread Pool
' 5426dae4c3f34e76a99819f7ca4baf3f

' <Snippet20>
Imports System.Threading

Module Module1

    Public Class Fibonacci
        Private _n As Integer
        Private _fibOfN
        Private _doneEvent As ManualResetEvent

        Public ReadOnly Property N() As Integer
            Get
                Return _n
            End Get
        End Property

        Public ReadOnly Property FibOfN() As Integer
            Get
                Return _fibOfN
            End Get
        End Property

        Sub New(ByVal n As Integer, ByVal doneEvent As ManualResetEvent)
            _n = n
            _doneEvent = doneEvent
        End Sub

        ' Wrapper method for use with the thread pool.
        Public Sub ThreadPoolCallBack(ByVal threadContext As Object)
            Dim threadIndex As Integer = CType(threadContext, Integer)
            Console.WriteLine("thread {0} started...", threadIndex)
            _fibOfN = Calculate(_n)
            Console.WriteLine("thread {0} result calculated...", threadIndex)
            _doneEvent.Set()
        End Sub

        Public Function Calculate(ByVal n As Integer) As Integer
            If n <= 1 Then
                Return n
            End If
            Return Calculate(n - 1) + Calculate(n - 2)
        End Function

    End Class


    <MTAThread()> 
    Sub Main()
        Const FibonacciCalculations As Integer = 9 ' 0 to 9

        ' One event is used for each Fibonacci object
        Dim doneEvents(FibonacciCalculations) As ManualResetEvent
        Dim fibArray(FibonacciCalculations) As Fibonacci
        Dim r As New Random()

        ' Configure and start threads using ThreadPool.
        Console.WriteLine("launching {0} tasks...", FibonacciCalculations)

        For i As Integer = 0 To FibonacciCalculations
            doneEvents(i) = New ManualResetEvent(False)
            Dim f = New Fibonacci(r.Next(20, 40), doneEvents(i))
            fibArray(i) = f
            ThreadPool.QueueUserWorkItem(AddressOf f.ThreadPoolCallBack, i)
        Next

        ' Wait for all threads in pool to calculate.
        WaitHandle.WaitAll(doneEvents)
        Console.WriteLine("All calculations are complete.")

        ' Display the results.
        For i As Integer = 0 To FibonacciCalculations
            Dim f As Fibonacci = fibArray(i)
            Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN)
        Next
    End Sub

End Module
' </Snippet20>
