' Visual Basic .NET Document
Option Strict On
' <Snippet5>
Module Example13
    Public Sub Main()
        Dim s1 As String = "This string consists of a single short sentence."
        Dim nWords As Integer = 0

        s1 = s1.Trim()
        For Each ch In s1
            If Char.IsPunctuation(ch) Or Char.IsWhiteSpace(ch) Then
                nWords += 1
            End If
        Next
        Console.WriteLine("The sentence{2}   {0}{2}has {1} words.",
                        s1, nWords, vbCrLf)
    End Sub
End Module
' The example displays the following output:
'       The sentence
'          This string consists of a single short sentence.
'       has 8 words.
' </Snippet5>
