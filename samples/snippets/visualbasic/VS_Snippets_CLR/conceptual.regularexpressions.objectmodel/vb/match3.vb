' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "abc"
        Dim input As String = "abc123abc456abc789"
        Dim match As Match = Regex.Match(input, pattern)
        Do While match.Success
            Console.WriteLine("{0} found at position {1}.", _
                              match.Value, match.Index)
            match = match.NextMatch()
        Loop
    End Sub
End Module
' The example displays the following output:
'       abc found at position 0.
'       abc found at position 6.
'       abc found at position 12.
' </Snippet8>
