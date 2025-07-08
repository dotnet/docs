' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Linq

Module Example5
    Public Sub Main()
        Dim dbQueryResults() As Integer = {1, 2, 3, 4}

        Dim singleObject = dbQueryResults.SingleOrDefault(Function(value) value > 2)

        If singleObject <> 0 Then
            Console.WriteLine("{0} is the only value greater than 2",
                             singleObject)
        Else
            ' Handle an empty collection.
            Console.WriteLine("No value is greater than 2")
        End If
    End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.InvalidOperationException: 
'       Sequence contains more than one matching element
'       at System.Linq.Enumerable.SingleOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
'       at Example.Main()
' </Snippet11>
