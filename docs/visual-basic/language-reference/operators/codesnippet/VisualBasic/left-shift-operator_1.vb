        Dim pattern As Short = 192
        ' The bit pattern is 0000 0000 1100 0000.
        Dim result1, result2, result3, result4, result5 As Short
        result1 = pattern << 0
        result2 = pattern << 4
        result3 = pattern << 9
        result4 = pattern << 17
        result5 = pattern << -1