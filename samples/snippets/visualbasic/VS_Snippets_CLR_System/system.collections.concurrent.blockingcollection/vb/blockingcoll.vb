'<snippet1>
Imports System.Threading.Tasks
Imports System.Collections.Concurrent
Imports System.Threading

Class BlockingCollectionDemo
    Shared Sub Main()
        AddTakeDemo.BC_AddTakeCompleteAdding()
        TryTakeDemo.BC_TryTake()
        ToAnyDemo.BC_ToAny()
        ConsumingEnumerableDemo.BC_GetConsumingEnumerable()
        ' Keep the console window open in debug mode
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub
End Class

Class AddTakeDemo

    ' Demonstrates:
    ' BlockingCollection<T>.Add()
    ' BlockingCollection<T>.Take()
    ' BlockingCollection<T>.CompleteAdding()
    Shared Sub BC_AddTakeCompleteAdding()
        Using bc As New BlockingCollection(Of Integer)()

            ' Spin up a Task to populate the BlockingCollection 
            Using t1 As Task = Task.Factory.StartNew(
                Sub()
                    bc.Add(1)
                    bc.Add(2)
                    bc.Add(3)
                    bc.CompleteAdding()
                End Sub)
                ' Spin up a Task to consume the BlockingCollection
                Using t2 As Task = Task.Factory.StartNew(
                Sub()
                    Try
                        ' Consume the BlockingCollection
                        While True
                            Console.WriteLine(bc.Take())
                        End While
                    Catch generatedExceptionName As InvalidOperationException
                        ' An InvalidOperationException means that Take() was called on a completed collection
                        Console.WriteLine("That's All!")
                    End Try
                End Sub)

                    Task.WaitAll(t1, t2)
                End Using
            End Using
        End Using
    End Sub



End Class

'<snippet2>
'Imports System.Collections.Concurrent
' Imports System.Threading
'Imports System.Threading.Tasks

Class TryTakeDemo
    ' Demonstrates:
    ' BlockingCollection<T>.Add()
    ' BlockingCollection<T>.CompleteAdding()
    ' BlockingCollection<T>.TryTake()
    ' BlockingCollection<T>.IsCompleted
    Shared Sub BC_TryTake()
        ' Construct and fill our BlockingCollection
        Using bc As New BlockingCollection(Of Integer)()
            Dim NUMITEMS As Integer = 10000
            For i As Integer = 0 To NUMITEMS - 1
                bc.Add(i)
            Next
            bc.CompleteAdding()
            Dim outerSum As Integer = 0

            ' Delegate for consuming the BlockingCollection and adding up all items
            Dim action As Action =
                Sub()
                    Dim localItem As Integer
                    Dim localSum As Integer = 0

                    While bc.TryTake(localItem)
                        localSum += localItem
                    End While
                    Interlocked.Add(outerSum, localSum)
                End Sub

            ' Launch three parallel actions to consume the BlockingCollection
            Parallel.Invoke(action, action, action)

            Console.WriteLine("Sum[0..{0}) = {1}, should be {2}", NUMITEMS, outerSum, ((NUMITEMS * (NUMITEMS - 1)) / 2))
            Console.WriteLine("bc.IsCompleted = {0} (should be true)", bc.IsCompleted)
        End Using
    End Sub

End Class
'</snippet2>

'<snippet3>
'Imports System.Threading.Tasks
'Imports System.Collections.Concurrent

' Demonstrates:
' Bounded BlockingCollection<T>
' BlockingCollection<T>.TryAddToAny()
' BlockingCollection<T>.TryTakeFromAny()
Class ToAnyDemo
    Shared Sub BC_ToAny()
        Dim bcs As BlockingCollection(Of Integer)() = New BlockingCollection(Of Integer)(1) {}
        bcs(0) = New BlockingCollection(Of Integer)(5)
        ' collection bounded to 5 items
        bcs(1) = New BlockingCollection(Of Integer)(5)
        ' collection bounded to 5 items
        ' Should be able to add 10 items w/o blocking
        Dim numFailures As Integer = 0
        For i As Integer = 0 To 9
            If BlockingCollection(Of Integer).TryAddToAny(bcs, i) = -1 Then
                numFailures += 1
            End If
        Next
        Console.WriteLine("TryAddToAny: {0} failures (should be 0)", numFailures)

        ' Should be able to retrieve 10 items
        Dim numItems As Integer = 0
        Dim item As Integer
        While BlockingCollection(Of Integer).TryTakeFromAny(bcs, item) <> -1
            numItems += 1
        End While
        Console.WriteLine("TryTakeFromAny: retrieved {0} items (should be 10)", numItems)
    End Sub
End Class
'</snippet3>

'<snippet4>
'Imports System.Threading.Tasks
'Imports System.Collections.Concurrent

' Demonstrates:
' BlockingCollection<T>.Add()
' BlockingCollection<T>.CompleteAdding()
' BlockingCollection<T>.GetConsumingEnumerable()

Class ConsumingEnumerableDemo
    Shared Sub BC_GetConsumingEnumerable()
        Using bc As New BlockingCollection(Of Integer)()

            ' Kick off a producer task
            Task.Factory.StartNew(
                Sub()
                    For i As Integer = 0 To 9
                        bc.Add(i)
                        ' sleep 100 ms between adds
                        Thread.Sleep(100)
                    Next

                    ' Need to do this to keep foreach below from hanging
                    bc.CompleteAdding()
                End Sub)
            ' Now consume the blocking collection with foreach.
            ' Use bc.GetConsumingEnumerable() instead of just bc because the
            ' former will block waiting for completion and the latter will
            ' simply take a snapshot of the current state of the underlying collection.
            For Each item In bc.GetConsumingEnumerable()
                Console.WriteLine(item)
            Next
        End Using
    End Sub
End Class
'</snippet4>
'</snippet1>



