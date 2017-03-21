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