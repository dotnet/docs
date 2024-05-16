' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Linq

Module Example2
    Public Sub Main()
        Dim dbQueryResults() As Integer = {1, 2, 3, 4}

        Dim firstNum = dbQueryResults.First(Function(n) n > 4)

        Console.WriteLine("The first value greater than 4 is {0}",
                        firstNum)
    End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.InvalidOperationException: 
'       Sequence contains no matching element
'       at System.Linq.Enumerable.First[TSource](IEnumerable`1 source, Func`2 predicate)
'       at Example.Main()
' </Snippet8>
