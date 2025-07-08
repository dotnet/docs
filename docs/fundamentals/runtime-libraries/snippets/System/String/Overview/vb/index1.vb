' Visual Basic .NET Document
Option Strict On
' <Snippet4>
Module Example12
    Public Sub Main()
        Dim s1 As String = "This string consists of a single short sentence."
        Dim nWords As Integer = 0

        s1 = s1.Trim()
        For ctr As Integer = 0 To s1.Length - 1
            If Char.IsPunctuation(s1(ctr)) Or Char.IsWhiteSpace(s1(ctr)) Then
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
' </Snippet4>
