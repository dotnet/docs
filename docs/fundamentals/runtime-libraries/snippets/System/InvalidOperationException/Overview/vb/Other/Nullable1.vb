' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Linq

Module Example13
    Public Sub Main()
        Dim queryResult = New Integer?() {1, 2, Nothing, 4}
        Dim map = queryResult.Select(Function(nullableInt) CInt(nullableInt))

        ' Display list.
        For Each num In map
            Console.Write("{0} ", num)
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays thIe following output:
'    1 2
'    Unhandled Exception: System.InvalidOperationException: Nullable object must have a value.
'       at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
'       at Example.<Main>b__0(Nullable`1 nullableInt)
'       at System.Linq.Enumerable.WhereSelectArrayIterator`2.MoveNext()
'       at Example.Main()
' </Snippet4>
