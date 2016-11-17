        ' Initialize an enumerable set of integers.
        Dim items = Enumerable.Range(1, 7).ToArray()

        ' Randomly shuffle the array of integers by using IronPython.
        For i = 0 To 4
            random.shuffle(items)
            For Each item In items
                Console.WriteLine(item)
            Next
            Console.WriteLine("-------------------")
        Next