        Dim negPattern As Short = -8192
        ' The bit pattern is 1110 0000 0000 0000.
        Dim negResult1, negResult2 As Short
        negResult1 = negPattern >> 4
        negResult2 = negPattern >> 13