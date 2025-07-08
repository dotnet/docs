' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example11
    Public Sub Main()
        Dim values() As Double = {10.0, 2.88, 2.88, 2.88, 9.0}
        Dim result As Double = 27.64
        Dim total As Double
        For Each value In values
            total += value
        Next
        If total.Equals(result) Then
            Console.WriteLine("The sum of the values equals the total.")
        Else
            Console.WriteLine("The sum of the values ({0}) does not equal the total ({1}).",
                           total, result)
        End If
    End Sub
End Module
' The example displays the following output:
'      The sum of the values (36.64) does not equal the total (36.64).   
'
' If the index items in the Console.WriteLine statement are changed to {0:R},
' the example displays the following output:
'       The sum of the values (27.639999999999997) does not equal the total (27.64).   
' </Snippet6>
