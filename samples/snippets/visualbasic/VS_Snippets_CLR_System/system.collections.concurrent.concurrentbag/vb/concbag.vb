'<snippet1>
Imports System.Collections.Concurrent

Module ConcurrentBagDemo
    ' Demonstrates:
    ' ConcurrentBag<T>.Add()
    ' ConcurrentBag<T>.IsEmpty
    ' ConcurrentBag<T>.TryTake()
    ' ConcurrentBag<T>.TryPeek()
    Sub Main()
        ' Construct and populate the ConcurrentBag
        Dim cb As New ConcurrentBag(Of Integer)()
        cb.Add(1)
        cb.Add(2)
        cb.Add(3)

        ' Consume the items in the bag
        Dim item As Integer
        While Not cb.IsEmpty
            If cb.TryTake(item) Then
                Console.WriteLine(item)
            Else
                Console.WriteLine("TryTake failed for non-empty bag")
            End If
        End While

        ' Bag should be empty at this point
        If cb.TryPeek(item) Then
            Console.WriteLine("TryPeek succeeded for empty bag!")
        End If
    End Sub
End Module
'</snippet1>