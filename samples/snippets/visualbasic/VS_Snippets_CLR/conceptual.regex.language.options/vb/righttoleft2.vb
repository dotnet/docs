' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.Text.RegularExpressions

Module RTL2Example
    Public Sub Main()
        Dim inputs() As String = {"1 May, 1917", "June 16, 2003"}
        Dim pattern As String = "(?<=\d{1,2}\s)\w+,\s\d{4}"

        For Each input As String In inputs
            Dim match As Match = Regex.Match(input, pattern, RegexOptions.RightToLeft)
            If match.Success Then
                Console.WriteLine("The date occurs in {0}.", match.Value)
            Else
                Console.WriteLine("{0} does not match.", input)
            End If
        Next
    End Sub
End Module

' The example displays the following output:
'       The date occurs in May, 1917.
'       June 16, 2003 does not match.
' </Snippet18>
