'<snippet01>
'<snippet02>
Imports System.Collections.Generic

Module Example
    Public Sub Main()
        Dim numbers As New HashSet(Of Integer)()

        For i As Integer = 0 To 19
            numbers.Add(i)
        Next i

        ' Display all the numbers in the hash table.
        Console.Write("numbers contains {0} elements: ", numbers.Count)
        DisplaySet(numbers)

        ' Remove all odd numbers.
        numbers.RemoveWhere(AddressOf IsOdd)
        Console.Write("numbers contains {0} elements: ", numbers.Count)
        DisplaySet(numbers)

        ' Check if the hash table contains 0 and, if so, remove it.
        If numbers.Contains(0) Then
            numbers.Remove(0)
        End If
        Console.Write("numbers contains {0} elements: ", numbers.Count)
        DisplaySet(numbers)
    End Sub

    Private Function IsOdd(ByVal i As Integer) As Boolean
        Return ((i Mod 2) = 1)
    End Function

    Private Sub DisplaySet(ByVal coll As HashSet(Of Integer))
        Console.Write("{")
        For Each i As Integer In coll
            Console.Write(" {0}", i)
        Next
        Console.WriteLine(" }")
    End Sub
End Module
' The example displays the following output:
'    numbers contains 20 elements: { 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 }
'    numbers contains 10 elements: { 0 2 4 6 8 10 12 14 16 18 }
'    numbers contains 9 elements: { 2 4 6 8 10 12 14 16 18 }
'</snippet02>
'</snippet01>

