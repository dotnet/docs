        Dim numberArray() = {0, 1, 2, 3, 4, 5, 6}

        Dim evensQuery2 = From num In numberArray
                          Where num Mod 2 = 0
                          Select num

        Console.WriteLine("Evens in original array:")
        For Each number In evensQuery2
            Console.Write("  " & number)
        Next
        Console.WriteLine()

        ' Change a few array elements.
        numberArray(1) = 10
        numberArray(4) = 22
        numberArray(6) = 8

        ' Run the same query again.
        Console.WriteLine(vbCrLf & "Evens in changed array:")
        For Each number In evensQuery2
            Console.Write("  " & number)
        Next
        Console.WriteLine()