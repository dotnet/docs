' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Imports System.Text.RegularExpressions

Module RTL1Example
    Public Sub Main()
        Dim pattern As String = "\bb\w+\s"
        Dim input As String = "build band tab"
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.RightToLeft)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
    End Sub
End Module
' The example displays the following output:
'       'band ' found at position 6.
'       'build ' found at position 0.
' </Snippet17>
