' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b(\p{Lu}{2})(\d{2})?(\p{Lu}{2})\b"
        Dim inputs() As String = {"AA22ZZ", "AABB"}
        For Each input As String In inputs
            Dim match As Match = Regex.Match(input, pattern)
            If match.Success Then
                Console.WriteLine("Match in {0}: {1}", input, match.Value)
                If match.Groups.Count > 1 Then
                    For ctr As Integer = 1 To match.Groups.Count - 1
                        If match.Groups(ctr).Success Then
                            Console.WriteLine("Group {0}: {1}", _
                                              ctr, match.Groups(ctr).Value)
                        Else
                            Console.WriteLine("Group {0}: <no match>", ctr)
                        End If
                    Next
                End If
            End If
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       Match in AA22ZZ: AA22ZZ
'       Group 1: AA
'       Group 2: 22
'       Group 3: ZZ
'       
'       Match in AABB: AABB
'       Group 1: AA
'       Group 2: <no match>
'       Group 3: BB
' </Snippet5>
