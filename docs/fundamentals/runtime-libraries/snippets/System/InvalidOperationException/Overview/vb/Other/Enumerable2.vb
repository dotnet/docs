' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Linq

Module Example1
    Public Sub Main()
        Dim dbQueryResults() As Integer = {1, 2, 3, 4}
        Dim moreThan4 = dbQueryResults.Where(Function(num) num > 4)

        If moreThan4.Any() Then
            Console.WriteLine("Average value of numbers greater than 4: {0}:",
                             moreThan4.Average())
        Else
            ' Handle empty collection. 
            Console.WriteLine("The dataset has no values greater than 4.")
        End If
    End Sub
End Module
' The example displays the following output:
'       The dataset has no values greater than 4.
' </Snippet7>
