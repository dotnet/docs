' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b(\S+)\s?"
        Dim input As String = "This is the first sentence of the first paragraph. " + _
                              "This is the second sentence." + vbCrLf + _
                              "This is the only sentence of the second paragraph."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Groups(1))
        Next
    End Sub
End Module
' The example displays the following output:
'    This
'    is
'    the
'    first
'    sentence
'    of
'    the
'    first
'    paragraph.
'    This
'    is
'    the
'    second
'    sentence.
'    This
'    is
'    the
'    only
'    sentence
'    of
'    the
'    second
'    paragraph.
' </Snippet11>
