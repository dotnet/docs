' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic

Module Example7
    Public Sub Main()
        Dim numbers As New List(Of Integer)({1, 2, 3, 4, 5})
        Dim upperBound = numbers.Count - 1

        For ctr As Integer = 0 To upperBound
            Dim square As Integer = CInt(Math.Pow(numbers(ctr), 2))
            Console.WriteLine("{0}^{1}", numbers(ctr), square)
            Console.WriteLine("Adding {0} to the collection..." + vbCrLf,
                           square)
            numbers.Add(square)
        Next

        Console.WriteLine("Elements now in the collection: ")
        For Each number In numbers
            Console.Write("{0}    ", number)
        Next
    End Sub
End Module
' The example displays the following output:
'    1^1
'    Adding 1 to the collection...
'    
'    2^4
'    Adding 4 to the collection...
'    
'    3^9
'    Adding 9 to the collection...
'    
'    4^16
'    Adding 16 to the collection...
'    
'    5^25
'    Adding 25 to the collection...
'    
'    Elements now in the collection:
'    1    2    3    4    5    1    4    9    16    25
' </Snippet2>
