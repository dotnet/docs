' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module Example3
    Public Sub Run()
        Dim pattern As String = "^(a+)+$"
        Dim inputs() As String = {"aaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaa!"}
        Dim rgx As New Regex(pattern)
        Dim sw As Stopwatch

        For Each input As String In inputs
            sw = Stopwatch.StartNew()
            Dim match As Match = rgx.Match(input)
            sw.Stop()
            If match.Success Then
                Console.WriteLine("Matched {0} in {1}", match.Value, sw.Elapsed)
            Else
                Console.WriteLine("No match found in {0}", sw.Elapsed)
            End If
        Next
    End Sub
End Module
'    Matched aaaaaaaaaaaaaaaaaaaaaaaaaaa in 00:00:00.0018281
'    No match found in 00:00:05.1882144
' </Snippet3>
