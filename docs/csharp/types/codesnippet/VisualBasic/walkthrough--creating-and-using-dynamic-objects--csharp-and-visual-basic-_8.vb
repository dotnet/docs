        Dim rFile As Object = New ReadOnlyFile("..\..\TextFile1.txt")
        For Each line In rFile.Customer
            Console.WriteLine(line)
        Next
        Console.WriteLine("----------------------------")
        For Each line In rFile.Customer(StringSearchOption.Contains, True)
            Console.WriteLine(line)
        Next