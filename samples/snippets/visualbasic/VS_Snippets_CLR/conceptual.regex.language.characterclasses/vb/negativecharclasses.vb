' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\bth[^o]\w+\b"
        Dim input As String = "thought thing though them through thus " + _
                              "thorough this"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       thing
'       them
'       through
'       thus
'       this
' </Snippet2>
