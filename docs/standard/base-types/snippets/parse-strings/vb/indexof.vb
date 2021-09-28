' Visual Basic .NET Document
Option Strict On

Module Example
    Public Sub Example1()
        ' <Snippet1>
        Dim input As String = "This is the first sentence in a string. " +
                            "More sentences will follow. For example, " +
                            "this is the third sentence. This is the " +
                            "fourth. And this is the fifth and final " +
                            "sentence."
        Dim sentences As New List(Of String)
        Dim start As Integer = 0
        Dim position As Integer

        ' Extract sentences from the string.
        Do
            position = input.IndexOf("."c, start)
            If position >= 0 Then
                sentences.Add(input.Substring(start, position - start + 1).Trim())
                start = position + 1
            End If
        Loop While position > 0

        ' Display the sentences.
        For Each sentence In sentences
            Console.WriteLine(sentence)
        Next
    End Sub

    ' The example displays the following output:
    '       This is the first sentence in a string.
    '       More sentences will follow.
    '       For example, this is the third sentence.
    '       This is the fourth.
    '       And this is the fifth and final sentence.
    ' </Snippet1>
End Module
