' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic

Module Example8
    Public Sub Main()
        Dim numbers As New List(Of Integer)({1, 2, 3, 4, 5})
        Dim temp As New List(Of Integer)()

        ' Square each number and store it in a temporary collection.
        For Each number In numbers
            Dim square As Integer = CInt(Math.Pow(number, 2))
            temp.Add(square)
        Next

        ' Combine the numbers into a single array.
        Dim combined(numbers.Count + temp.Count - 1) As Integer
        Array.Copy(numbers.ToArray(), 0, combined, 0, numbers.Count)
        Array.Copy(temp.ToArray(), 0, combined, numbers.Count, temp.Count)

        ' Iterate the array.
        For Each value In combined
            Console.Write("{0}    ", value)
        Next
    End Sub
End Module
' The example displays the following output:
'       1    2    3    4    5    1    4    9    16    25
' </Snippet3>
