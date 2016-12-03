        ' Data source.
        Dim numbers() As Integer = {0, 1, 2, 3, 4, 5, 6}

        ' Query creation.
        Dim evensQuery = From num In numbers
                         Where num Mod 2 = 0
                         Select num

        ' Query execution.
        For Each number In evensQuery
            Console.Write(number & " ")
        Next