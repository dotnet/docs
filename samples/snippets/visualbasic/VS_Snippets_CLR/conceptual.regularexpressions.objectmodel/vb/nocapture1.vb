' Visual Basic .NET Document
Option Strict On

' <Snippet11> 
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "aaa(bbb)*ccc"
        Dim input As String = "aaaccc"
        Dim match As Match = Regex.Match(input, pattern)
        Console.WriteLine("Match value: {0}", match.Value)
        If match.Groups(1).Success Then
            Console.WriteLine("Group 1 value: {0}", match.Groups(1).Value)
        Else
            Console.WriteLine("The first capturing group has no match.")
        End If
    End Sub
End Module
' The example displays the following output:
'       Match value: aaaccc
'       The first capturing group has no match.
' </Snippet11>
