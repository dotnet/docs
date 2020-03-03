'<snippet1>
Imports System.Collections.Concurrent
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks

Class Example
    ' Demonstrates:
    '   ConcurrentStack<T>.PushRange();
    '   ConcurrentStack<T>.TryPopRange();
    Shared Sub Main()
        Dim numParallelTasks As Integer = 4
        Dim numItems As Integer = 1000
        Dim stack = New ConcurrentStack(Of Integer)()

        ' Push a range of values onto the stack concurrently
        Task.WaitAll(Enumerable.Range(0, numParallelTasks).[Select](
                     Function(i) Task.Factory.StartNew(
                        Function(state)
                            Dim index As Integer = CInt(state)
                            Dim array As Integer() = New Integer(numItems - 1) {}

                            For j As Integer = 0 To numItems - 1
                                array(j) = index + j
                            Next

                            Console.WriteLine($"Pushing an array of ints from {array(0)} to {array(numItems - 1)}")
                            stack.PushRange(array)
                        End Function, i * numItems, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.[Default])).ToArray())


        Dim numTotalElements As Integer = 4 * numItems
        Dim resultBuffer As Integer() = New Integer(numTotalElements - 1) {}
        Task.WaitAll(Enumerable.Range(0, numParallelTasks).[Select](
                     Function(i) Task.Factory.StartNew(
                        Function(obj)
                            Dim index As Integer = CInt(obj)
                            Dim result As Integer = stack.TryPopRange(resultBuffer, index, numItems)
                            Console.WriteLine($"TryPopRange expected {numItems}, got {result}.")
                        End Function, i * numItems, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.[Default])).ToArray())

        For i As Integer = 0 To numParallelTasks - 1
            ' Create a sequence we expect to see from the stack taking the last number of the range we inserted
            Dim expected = Enumerable.Range(resultBuffer(i * numItems + numItems - 1), numItems)

            ' Take the range we inserted, reverse it, and compare to the expected sequence
            Dim areEqual = expected.SequenceEqual(resultBuffer.Skip(i * numItems).Take(numItems).Reverse())

            If areEqual Then
                Console.WriteLine($"Expected a range of {expected.First()} to {expected.Last()}. Got {resultBuffer(i * numItems + numItems - 1)} to {resultBuffer(i * numItems)}")
            Else
                Console.WriteLine($"Unexpected consecutive ranges.")
            End If
        Next
    End Sub
End Class
'</snippet1>