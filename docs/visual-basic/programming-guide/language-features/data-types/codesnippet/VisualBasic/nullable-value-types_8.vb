        ' Change the value of n to Nothing.
        n = Nothing

        Dim compare2 = m > n
        Dim sum2 = m + n

        ' Because the values of n, compare2, and sum2 are all Nothing, the
        ' following line displays 3 * * *
        Console.WriteLine(m & " * " & n & " * " & sum2 & " * " & compare2)