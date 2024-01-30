' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example10
    Public Sub Main()
        Dim values() As Single = {10.01, 2.88, 2.88, 2.88, 9.0}
        Dim result As Single = 27.65
        Dim total As Single
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
'      The sum of the values (27.65) does not equal the total (27.65).   
'
' If the index items in the Console.WriteLine statement are changed to {0:R},
' the example displays the following output:
'       The sum of the values (27.639999999999997) does not equal the total (27.64).   
' </Snippet6>
