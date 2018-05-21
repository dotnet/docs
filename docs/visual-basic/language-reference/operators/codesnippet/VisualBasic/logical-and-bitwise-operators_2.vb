        Dim a, b, c, d, e, f, g As Boolean

        a = 23 > 14 And 11 > 8
        b = 14 > 23 And 11 > 8
        ' The preceding statements set a to True and b to False.

        c = 23 > 14 Or 8 > 11
        d = 23 > 67 Or 8 > 11
        ' The preceding statements set c to True and d to False.

        e = 23 > 67 Xor 11 > 8
        f = 23 > 14 Xor 11 > 8
        g = 14 > 23 Xor 8 > 11
        ' The preceding statements set e to True, f to False, and g to False.