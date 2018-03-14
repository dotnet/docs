'<snippet1>

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Class CS_Ranges
    ' Demonstrates:
    ' ConcurrentStack<T>.PushRange();
    ' ConcurrentStack<T>.TryPopRange();
    ' ConcurrentStack<T>.IsEmpty;
    Shared Sub Main()
        Dim errorCount As Integer = 0

        ' Construct a ConcurrentStack
        Dim cs As New ConcurrentStack(Of Integer)()

        ' Push some consecutively numbered ranges
        cs.PushRange(New Integer() {1, 2, 3, 4, 5, 6, 7})
        cs.PushRange(New Integer() {8, 9, 10})
        cs.PushRange(New Integer() {11, 12, 13, 14})
        cs.PushRange(New Integer() {15, 16, 17, 18, 19, 20})
        cs.PushRange(New Integer() {21, 22})
        cs.PushRange(New Integer() {23, 24, 25, 26, 27, 28, 29, 30})

        ' Now read them back, 3 at a time, concurrently
        Parallel.For(0, 10,
                       Sub(i)
                           Dim range As Integer() = New Integer(2) {}
                           If cs.TryPopRange(range) <> 3 Then
                               Console.WriteLine("CS: TryPopRange failed unexpectedly")
                               Interlocked.Increment(errorCount)
                           End If

                           ' Each range should be consecutive integers, if the range was extracted atomically
                           ' And it should be reverse of the original order...
                           If Not range.Skip(1).SequenceEqual(range.Take(range.Length - 1).[Select](Function(x) x - 1)) Then
                               Console.WriteLine("CS: Expected consecutive ranges. range[0]={0}, range[1]={1}", range(0), range(1))
                               Interlocked.Increment(errorCount)
                           End If
                       End Sub)

        ' We should have emptied the thing
        If Not cs.IsEmpty Then
            Console.WriteLine("CS: Expected IsEmpty to be true after emptying")
            errorCount += 1
        End If

        If errorCount = 0 Then
            Console.WriteLine(" OK!")
        End If
    End Sub
End Class
'</snippet1>

'<snippet2>
' Imports System.Collections.Concurrent
Class CS_Singles

    ' Demonstrates:
    ' ConcurrentStack<T>.Push();
    ' ConcurrentStack<T>.TryPeek();
    ' ConcurrentStack<T>.TryPop();
    ' ConcurrentStack<T>.Clear();
    ' ConcurrentStack<T>.IsEmpty;
    Shared Sub Main()
        Dim errorCount As Integer = 0

        ' Construct a ConcurrentStack
        Dim cs As New ConcurrentStack(Of Integer)()

        ' Push some elements onto the stack
        cs.Push(1)
        cs.Push(2)

        Dim result As Integer

        ' Peek at the top of the stack
        If Not cs.TryPeek(result) Then
            Console.WriteLine("CS: TryPeek() failed when it should have succeeded")
            errorCount += 1
        ElseIf result <> 2 Then
            Console.WriteLine("CS: TryPeek() saw {0} instead of 2", result)
            errorCount += 1
        End If

        ' Pop a number off of the stack
        If Not cs.TryPop(result) Then
            Console.WriteLine("CS: TryPop() failed when it should have succeeded")
            errorCount += 1
        ElseIf result <> 2 Then
            Console.WriteLine("CS: TryPop() saw {0} instead of 2", result)
            errorCount += 1
        End If

        ' Clear the stack, and verify that it is empty
        cs.Clear()
        If Not cs.IsEmpty Then
            Console.WriteLine("CS: IsEmpty not true after Clear()")
            errorCount += 1
        End If

        If errorCount = 0 Then
            Console.WriteLine(" OK!")
        End If
    End Sub
End Class
'</snippet2>