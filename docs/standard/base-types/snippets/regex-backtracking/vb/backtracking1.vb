' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example1
    Public Sub Run()
        Dim input As String = "needing a reed"
        Dim pattern As String = "e{2}\w\b"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("{0} found at position {1}",
                              match.Value, match.Index)
        Next
    End Sub
End Module
' The example displays the following output:
'       eed found at position 11
' </Snippet1>
