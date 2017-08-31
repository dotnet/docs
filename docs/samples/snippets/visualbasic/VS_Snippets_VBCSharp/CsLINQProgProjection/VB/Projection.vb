Module Projection
    Sub Main(ByVal args As String())
        SelectVsSelectMany.SelectVsSelectMany()
    End Sub

    Sub SelectExample()
        ' <Snippet1>
        Dim words = New List(Of String) From {"an", "apple", "a", "day"}

        Dim query = From word In words 
                    Select word.Substring(0, 1)

        Dim sb As New System.Text.StringBuilder()
        For Each letter As String In query
            sb.AppendLine(letter)
        Next

        ' Display the output.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' a
        ' a
        ' a
        ' d

        ' </Snippet1>
    End Sub

    Sub SelectMany()
        ' <Snippet2>

        Dim phrases = New List(Of String) From {"an apple a day", "the quick brown fox"}

        Dim query = From phrase In phrases 
                    From word In phrase.Split(" "c) 
                    Select word

        Dim sb As New System.Text.StringBuilder()
        For Each str As String In query
            sb.AppendLine(str)
        Next

        ' Display the output.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' an
        ' apple
        ' a
        ' day
        ' the
        ' quick
        ' brown
        ' fox

        ' </Snippet2>
    End Sub
End Module

Module SelectVsSelectMany
    ' <Snippet3>
    Class Bouquet
        Public Flowers As List(Of String)
    End Class

    Sub SelectVsSelectMany()
        Dim bouquets = New List(Of Bouquet) From { 
            New Bouquet With {.Flowers = New List(Of String)(New String() {"sunflower", "daisy", "daffodil", "larkspur"})}, 
            New Bouquet With {.Flowers = New List(Of String)(New String() {"tulip", "rose", "orchid"})}, 
            New Bouquet With {.Flowers = New List(Of String)(New String() {"gladiolis", "lily", "snapdragon", "aster", "protea"})}, 
            New Bouquet With {.Flowers = New List(Of String)(New String() {"larkspur", "lilac", "iris", "dahlia"})}}

        Dim output As New System.Text.StringBuilder

        ' Select()
        Dim query1 = bouquets.Select(Function(b) b.Flowers)

        output.AppendLine("Using Select():")
        For Each flowerList In query1
            For Each str As String In flowerList
                output.AppendLine(str)
            Next
        Next

        ' SelectMany()
        Dim query2 = bouquets.SelectMany(Function(b) b.Flowers)

        output.AppendLine(vbCrLf & "Using SelectMany():")
        For Each str As String In query2
            output.AppendLine(str)
        Next

        ' Display the output
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' Using Select():
        ' sunflower
        ' daisy
        ' daffodil
        ' larkspur
        ' tulip
        ' rose
        ' orchid
        ' gladiolis
        ' lily
        ' snapdragon
        ' aster
        ' protea
        ' larkspur
        ' lilac
        ' iris
        ' dahlia

        ' Using SelectMany()
        ' sunflower
        ' daisy
        ' daffodil
        ' larkspur
        ' tulip
        ' rose
        ' orchid
        ' gladiolis
        ' lily
        ' snapdragon
        ' aster
        ' protea
        ' larkspur
        ' lilac
        ' iris
        ' dahlia

    End Sub
    ' </Snippet3>
End Module
