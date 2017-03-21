        Dim tuple6 = New Tuple(Of String, Integer, Integer, Integer, 
                               Integer, Integer) _
                               ("Jane", 90, 87, 93, 67, 100)
        Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}",
                          tuple6.Item1, tuple6.Item2, tuple6.Item3,
                          tuple6.Item4, tuple6.Item5, tuple6.Item6)
        ' Displays Test scores for Jane: 90, 87, 93, 67, 100