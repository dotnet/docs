Module IntroExamples

    Sub Intro1()
        '<snippet1>
        Dim s As String = "You win some. You lose some."
        Dim subs As String() = s.Split()

        For Each substring As String In subs
            Console.WriteLine("Substring: {0}", substring)
        Next

        ' This example produces the following output:
        '
        ' Substring: You
        ' Substring: win
        ' Substring: some.
        ' Substring: You
        ' Substring: lose
        ' Substring: some.
        '</snippet1>
    End Sub

    Sub Intro2()
        '<snippet2>
        Dim s As String = "You win some. You lose some."
        Dim subs As String() = s.Split(" "c, "."c)

        For Each substring As String In subs
            Console.WriteLine("Substring: {0}", substring)
        Next

        ' This example produces the following output:
        '
        ' Substring: You
        ' Substring: win
        ' Substring: some
        ' Substring:
        ' Substring: You
        ' Substring: lose
        ' Substring: some
        ' Substring:
        '</snippet2>
    End Sub

    Sub Intro3()
        '<snippet3>
        Dim s As String = "You win some. You lose some."
        Dim separators As Char() = New Char() {" "c, "."c}
        Dim subs As String() = s.Split(separators, StringSplitOptions.RemoveEmptyEntries)

        For Each substring As String In subs
            Console.WriteLine("Substring: {0}", substring)
        Next

        ' This example produces the following output:
        '
        ' Substring: You
        ' Substring: win
        ' Substring: some
        ' Substring: You
        ' Substring: lose
        ' Substring: some
        '</snippet3>
    End Sub
End Module
