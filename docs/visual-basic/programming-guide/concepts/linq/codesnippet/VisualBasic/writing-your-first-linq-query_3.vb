        ' Query execution that results in a sequence of values.
        For Each number In evensQuery
            Console.Write(number & " ")
        Next

        ' Query execution that results in a single value.
        Dim evens = evensQuery.Count()