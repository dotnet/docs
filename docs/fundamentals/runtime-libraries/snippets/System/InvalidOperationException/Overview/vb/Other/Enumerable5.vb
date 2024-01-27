' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Linq

Module Example4
    Public Sub Main()
        Dim dbQueryResults() As Integer = {1, 2, 3, 4}

        Dim singleObject = dbQueryResults.Single(Function(value) value > 4)

        ' Display results.
        Console.WriteLine("{0} is the only value greater than 4",
                         singleObject)
    End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.InvalidOperationException: 
'       Sequence contains no matching element
'       at System.Linq.Enumerable.Single[TSource](IEnumerable`1 source, Func`2 predicate)
'       at Example.Main()
' </Snippet10>
