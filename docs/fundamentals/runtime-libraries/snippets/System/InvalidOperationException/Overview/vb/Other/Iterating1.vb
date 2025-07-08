' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic

Module Example6
    Public Sub Main()
        Dim numbers As New List(Of Integer)({1, 2, 3, 4, 5})
        For Each number In numbers
            Dim square As Integer = CInt(Math.Pow(number, 2))
            Console.WriteLine("{0}^{1}", number, square)
            Console.WriteLine("Adding {0} to the collection..." + vbCrLf,
                           square)
            numbers.Add(square)
        Next
    End Sub
End Module
' The example displays the following output:
'    1^1
'    Adding 1 to the collection...
'    
'    
'    Unhandled Exception: System.InvalidOperationException: Collection was modified; 
'       enumeration operation may not execute.
'       at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
'       at System.Collections.Generic.List`1.Enumerator.MoveNextRare()
'       at Example.Main()
' </Snippet1>

