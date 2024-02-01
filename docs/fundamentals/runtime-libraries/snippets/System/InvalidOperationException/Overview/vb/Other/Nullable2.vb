' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Linq

Module Example14
    Public Sub Main()
        Dim queryResult = New Integer?() {1, 2, Nothing, 4}
        Dim numbers = queryResult.Select(Function(nullableInt) _
                                          CInt(nullableInt.GetValueOrDefault()))
        ' Display list.
        For Each number In numbers
            Console.Write("{0} ", number)
        Next
        Console.WriteLine()

        ' Use -1 to indicate a missing values.
        numbers = queryResult.Select(Function(nullableInt) _
                                      CInt(If(nullableInt.HasValue, nullableInt, -1)))
        ' Display list.
        For Each number In numbers
            Console.Write("{0} ", number)
        Next
        Console.WriteLine()

    End Sub
End Module
' The example displays the following output:
'       1 2 0 4
'       1 2 -1 4
' </Snippet5>
