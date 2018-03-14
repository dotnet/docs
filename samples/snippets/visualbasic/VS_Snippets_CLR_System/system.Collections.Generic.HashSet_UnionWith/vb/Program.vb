'<snippet01>
Imports System
Imports System.Collections.Generic

Class Program

    '<snippet02>
    Shared Sub Main()

        Dim evenNumbers As HashSet(Of Integer) = New HashSet(Of Integer)()
        Dim oddNumbers As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 0 To 4

            ' Populate evenNumbers with only even numbers.
            evenNumbers.Add(i * 2)

            ' Populate oddNumbers with only odd numbers.
            oddNumbers.Add((i * 2) + 1)
        Next i

        Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count)
        DisplaySet(evenNumbers)

        Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count)
        DisplaySet(oddNumbers)

        ' Create a new HashSet populated with even numbers.
        Dim numbers As HashSet(Of Integer) = New HashSet(Of Integer)(evenNumbers)
        Console.WriteLine("numbers UnionWith oddNumbers...")
        numbers.UnionWith(oddNumbers)

        Console.Write("numbers contains {0} elements: ", numbers.Count)
        DisplaySet(numbers)
    End Sub

    '</snippet02>

    Private Shared Sub DisplaySet(ByVal coll As HashSet(Of Integer))
        Console.Write("{")
        For Each i As Integer In coll
            Console.Write(" {0}", i)
        Next i
        Console.WriteLine(" }")
    End Sub

End Class
' This example produces output similar to the following:
' evenNumbers contains 5 elements: { 0 2 4 6 8 }
' oddNumbers contains 5 elements: { 1 3 5 7 9 }
' numbers UnionWith oddNumbers...
' numbers contains 10 elements: { 0 2 4 6 8 1 3 5 7 9 }
'</snippet01>

