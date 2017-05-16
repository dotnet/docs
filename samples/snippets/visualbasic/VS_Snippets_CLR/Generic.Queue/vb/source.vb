' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Module Example

    Sub Main

        Dim numbers As New Queue(Of String)
        numbers.Enqueue("one")
        numbers.Enqueue("two")
        numbers.Enqueue("three")
        numbers.Enqueue("four")
        numbers.Enqueue("five")

        ' A queue can be enumerated without disturbing its contents.
        For Each number As String In numbers
            Console.WriteLine(number)
        Next

        Console.WriteLine(vbLf & "Dequeuing '{0}'", numbers.Dequeue())
        Console.WriteLine("Peek at next item to dequeue: {0}", _
            numbers.Peek())    
        Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue())

        ' Create a copy of the queue, using the ToArray method and the
        ' constructor that accepts an IEnumerable(Of T).
        Dim queueCopy As New Queue(Of String)(numbers.ToArray())

        Console.WriteLine(vbLf & "Contents of the first copy:")
        For Each number As String In queueCopy
            Console.WriteLine(number)
        Next
        
        ' Create an array twice the size of the queue, compensating
        ' for the fact that Visual Basic allocates an extra array 
        ' element. Copy the elements of the queue, starting at the
        ' middle of the array. 
        Dim array2((numbers.Count * 2) - 1) As String
        numbers.CopyTo(array2, numbers.Count)
        
        ' Create a second queue, using the constructor that accepts an
        ' IEnumerable(Of T).
        Dim queueCopy2 As New Queue(Of String)(array2)

        Console.WriteLine(vbLf & _
            "Contents of the second copy, with duplicates and nulls:")
        For Each number As String In queueCopy2
            Console.WriteLine(number)
        Next

        Console.WriteLine(vbLf & "queueCopy.Contains(""four"") = {0}", _
            queueCopy.Contains("four"))

        Console.WriteLine(vbLf & "queueCopy.Clear()")
        queueCopy.Clear()
        Console.WriteLine(vbLf & "queueCopy.Count = {0}", _
            queueCopy.Count)
    End Sub
End Module

' This code example produces the following output:
'
'one
'two
'three
'four
'five
'
'Dequeuing 'one'
'Peek at next item to dequeue: two
'
'Dequeuing 'two'
'
'Contents of the copy:
'three
'four
'five
'
'Contents of the second copy, with duplicates and nulls:
'
'
'
'three
'four
'five
'
'queueCopy.Contains("four") = True
'
'queueCopy.Clear()
'
'queueCopy.Count = 0
'</Snippet1>
