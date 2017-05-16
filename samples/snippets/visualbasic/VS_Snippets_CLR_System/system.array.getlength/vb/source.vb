' The following example demonstrates using the Array.GetLength method.

' <Snippet1>
Imports System

Public Class SamplesArray
    Public Shared Sub Main()
        ' make a single dimension array
        Dim MyArray1 As Array = Array.CreateInstance(GetType(Integer), 5)

        ' make a 3 dimensional array
        Dim MyArray2 As Array = Array.CreateInstance(GetType(Integer), 5, 3, 2)

        ' make an array container
        Dim BossArray As Array = Array.CreateInstance(GetType(Array), 2)
        BossArray.SetValue(MyArray1, 0)
        BossArray.SetValue(MyArray2, 1)

        Dim i As Integer = 0
        Dim j As Integer
        Dim rank As Integer
        For Each anArray As Array In BossArray
            rank = anArray.Rank
            If rank > 1
                Console.WriteLine("Lengths of {0:d} dimension array[{1:d}]", rank, i)
                ' show the lengths of each dimension
                For j = 0 To rank - 1
                    Console.WriteLine("    Length of dimension({0:d}) = {1:d}", j, anArray.GetLength(j))
                Next j
            Else
                Console.WriteLine("Lengths of single dimension array[{0:d}]", i)
            End If
            ' show the total length of the entire array or all dimensions
            Console.WriteLine("    Total length of the array = {0:d}", anArray.Length)
            Console.WriteLine()
            i = i + 1
        Next anArray
    End Sub
End Class

'This code produces the following output:
'
'Lengths of single dimension array[0]
'    Total length of the array = 5
'
'Lengths of 3 dimension array[1]
'    Length of dimension(0) = 5
'    Length of dimension(1) = 3
'    Length of dimension(2) = 2
'    Total length of the array = 30
' </Snippet1>
