Module SQO
    Sub Main(ByVal args As String())
        Example1()
    End Sub

    Sub Example1()
        ' <Snippet1>
        Dim sentence = "the quick brown fox jumps over the lazy dog"
        ' Split the string into individual words to create a collection.
        Dim words = sentence.Split(" "c)

        Dim query = From word In words 
                    Group word.ToUpper() By word.Length Into gr = Group 
                    Order By Length _
                    Select Length, GroupedWords = gr

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(String.Format("Words of length {0}:", obj.Length))
            For Each word As String In obj.GroupedWords
                output.AppendLine(word)
            Next
        Next

        'Display the output
        MsgBox(output.ToString())

        ' This code example produces the following output:
        '
        ' Words of length 3:
        ' THE
        ' FOX
        ' THE
        ' DOG
        ' Words of length 4:
        ' OVER
        ' LAZY
        ' Words of length 5:
        ' QUICK
        ' BROWN
        ' JUMPS 

        ' </Snippet1>
    End Sub
End Module
