        ' Variable first is a nullable type.
        Dim first? As Integer = 3
        Dim second As Integer = 6

        ' Variable first <> Nothing, so its value, 3, is returned.
        Console.WriteLine(If(first, second))

        second = Nothing
        ' Variable first <> Nothing, so the value of first is returned again.
        Console.WriteLine(If(first, second))

        first = Nothing
        second = 6
        ' Variable first = Nothing, so 6 is returned.
        Console.WriteLine(If(first, second))