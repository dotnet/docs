
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