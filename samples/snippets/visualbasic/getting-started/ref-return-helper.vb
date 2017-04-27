Imports Sentence

' <Snippet1>
Module Example
    Dim sentence As Sentence

    Public Sub Main()
        sentence = New Sentence("A time to see the world is now.")
        Dim original = sentence.GetSentence()
        Dim found = False
        Dim returns = RefHelper(sentence.FindNext("A", found), "A good", found)
        If returns.Item2 Then
            Console.WriteLine($"Changed '{original}' to '{sentence.GetSentence()}'")
        Else
            Console.WriteLine($"'{returns.Item1}' not found in '{sentence.GetSentence()}'")
        End If
        Console.ReadLine()
    End Sub

    Private Function RefHelper(ByRef stringFound As String, replacement As String, success As Boolean) _
                    As (String, Boolean)
        Dim originalString = stringFound
        If success Then stringFound = replacement
        Return (originalString, success)
    End Function
End Module
' The example displays the following output:
'         Changed 'A time to see the world is now.' to 'A good time to see the world is now.'
' </Snippet1>


