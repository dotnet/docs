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