' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Linq

Module Example
   Public Sub Main()
      Dim data() As Integer = { 1, 2, 3, 4 }
      Dim average = data.Where(Function(num) num > 4).Average()
      Console.Write("The average of numbers greater than 4 is {0}",
                    average)
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.InvalidOperationException: Sequence contains no elements
'       at System.Linq.Enumerable.Average(IEnumerable`1 source)
'       at Example.Main()
' </Snippet6>
