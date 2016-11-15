Module Module1

    Sub Main()
        Dim numbers1 = {1, 2, 3, 4, 5}

        Dim query1 = Aggregate num In numbers1 Into Median(num)

        Console.WriteLine("Median = " & query1)

        Dim numbers2 = {1.9, 2, 8, 4, 5.7, 6, 7.2, 0}

        Dim query2 = Aggregate num In numbers2 Into Median()

        Console.WriteLine("Median = " & query2)
    End Sub

End Module