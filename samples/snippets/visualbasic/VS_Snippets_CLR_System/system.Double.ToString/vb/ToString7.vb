' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
    Public Sub Main()
        Dim number As Double = 1764.3789

        ' Format as a currency value.
        Console.WriteLine(number.ToString("C"))

        ' Format as a numeric value with 3 decimal places.
        Console.WriteLine(number.ToString("N3"))
    End Sub
End Module
' The example displays the following output:
'       $1,764.38
'       1,764.379
' </Snippet7>
