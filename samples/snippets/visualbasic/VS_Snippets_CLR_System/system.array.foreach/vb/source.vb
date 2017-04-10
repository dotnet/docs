' The following example demonstrates using the ForEach method.

'<Snippet1>
Imports System

Public Class SamplesArray
    Public Shared Sub Main()
        ' create a three element array of integers
        Dim intArray() As Integer = New Integer() {2, 3, 4}

        ' set a delegate for the ShowSquares method
        Dim action As New Action(Of Integer)(AddressOf ShowSquares)

        Array.ForEach(intArray, action)
    End Sub

    Private Shared Sub ShowSquares(val As Integer)
        Console.WriteLine("{0:d} squared = {1:d}", val, val*val)
    End Sub
End Class

' This code produces the following output:
'
' 2 squared = 4
' 3 squared = 9
' 4 squared = 16

'</Snippet1>
