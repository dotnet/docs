        ' Variable n is a nullable type, but both m and n have proper values.
        Dim m As Integer = 3
        Dim n? As Integer = 2

        ' The comparison evaluated is 3>2, but compare1 is inferred to be of 
        ' type Boolean?.
        Dim compare1 = m > n
        ' The values summed are 3 and 2, but sum1 is inferred to be of type Integer?.
        Dim sum1 = m + n

        ' The following line displays: 3 * 2 * 5 * True
        Console.WriteLine(m & " * " & n & " * " & sum1 & " * " & compare1)