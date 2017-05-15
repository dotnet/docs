' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic

Module Example

    Sub Main

        Dim numbers As New Stack(Of String)
        numbers.Push("one")
        numbers.Push("two")
        numbers.Push("three")
        numbers.Push("four")
        numbers.Push("five")

        ' A stack can be enumerated without disturbing its contents.
        For Each number As String In numbers
            Console.WriteLine(number)
        Next

        Console.WriteLine(vbLf & "Popping '{0}'", numbers.Pop())
        Console.WriteLine("Peek at next item to pop: {0}", _
            numbers.Peek())    
        Console.WriteLine("Popping '{0}'", numbers.Pop())

        ' Create another stack, using the ToArray method and the
        ' constructor that accepts an IEnumerable(Of T). Note that
        ' the order of items on the new stack is reversed.
        Dim stack2 As New Stack(Of String)(numbers.ToArray())

        Console.WriteLine(vbLf & "Contents of the first copy:")
        For Each number As String In stack2
            Console.WriteLine(number)
        Next
        
        ' Create an array twice the size of the stack, compensating
        ' for the fact that Visual Basic allocates an extra array 
        ' element. Copy the elements of the stack, starting at the
        ' middle of the array. 
        Dim array2((numbers.Count * 2) - 1) As String
        numbers.CopyTo(array2, numbers.Count)
        
        ' Create a second stack, using the constructor that accepts an
        ' IEnumerable(Of T). The elements are reversed, with the null
        ' elements appearing at the end of the stack when enumerated.
        Dim stack3 As New Stack(Of String)(array2)

        Console.WriteLine(vbLf & _
            "Contents of the second copy, with duplicates and nulls:")
        For Each number As String In stack3
            Console.WriteLine(number)
        Next

        Console.WriteLine(vbLf & "stack2.Contains(""four"") = {0}", _
            stack2.Contains("four"))

        Console.WriteLine(vbLf & "stack2.Clear()")
        stack2.Clear()
        Console.WriteLine(vbLf & "stack2.Count = {0}", _
            stack2.Count)
    End Sub
End Module

' This code example produces the following output:
'
'five
'four
'three
'two
'one
'
'Popping 'five'
'Peek at next item to pop: four
'Popping 'four'
'
'Contents of the first copy:
'one
'two
'three
'
'Contents of the second copy, with duplicates and nulls:
'one
'two
'three
'
'
'
'
'stack2.Contains("four") = False
'
'stack2.Clear()
'
'stack2.Count = 0
'</Snippet1>
