        Dim pattern As Short = 2560
        ' The bit pattern is 0000 1010 0000 0000.
        Dim result1, result2, result3, result4, result5 As Short
        result1 = pattern >> 0
        result2 = pattern >> 4
        result3 = pattern >> 10
        result4 = pattern >> 18
        result5 = pattern >> -1