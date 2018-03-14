'<snippet1>
Imports System

Module Application

    Sub Main()
        ' Create some DateTime objects.
        Dim one As DateTime = DateTime.UtcNow

        Dim two As DateTime = DateTime.Now

        Dim three As DateTime = one

        ' Compare the DateTime objects and display the results.
        Dim result As Boolean = one.Equals(two)

        Console.WriteLine("The result of comparing DateTime object one and two is: {0}.", result)

        result = one.Equals(three)

        Console.WriteLine("The result of comparing DateTime object one and three is: {0}.", result)

    End Sub
End Module

' This code example displays the following:
'
' The result of comparing DateTime object one and two is: False.
' The result of comparing DateTime object one and three is: True.
'</snippet1>