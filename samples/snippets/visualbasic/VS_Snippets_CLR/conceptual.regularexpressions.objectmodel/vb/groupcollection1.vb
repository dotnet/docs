' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b(\w+)\s(\d{1,2}),\s(\d{4})\b"
        Dim input As String = "Born: July 28, 1989"
        Dim match As Match = Regex.Match(input, pattern)
        If match.Success Then
            For ctr As Integer = 0 To match.Groups.Count - 1
                Console.WriteLine("Group {0}: {1}", ctr, match.Groups(ctr).Value)
            Next
        End If
    End Sub
End Module
' The example displays the following output:
'       Group 0: July 28, 1989
'       Group 1: July
'       Group 2: 28
'       Group 3: 1989
' </Snippet10>
