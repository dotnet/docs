        Dim numbers() As Integer = {1, 2, 3, 4}
        Dim words() As String = {"one", "two", "three"}
        Dim numbersAndWords = numbers.AsQueryable().Zip(words, Function(first, second) first & " " & second)

        For Each item In numbersAndWords
            Console.WriteLine(item)
        Next

        ' This code produces the following output:

        ' 1 one
        ' 2 two
        ' 3 three
