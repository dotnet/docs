        Dim lResult, rResult As Integer
        Dim pattern As Integer = 12
        ' The low-order bits of pattern are 0000 1100.
        lResult = pattern << 3
        ' A left shift of 3 bits produces a value of 96.
        rResult = pattern >> 2
        ' A right shift of 2 bits produces value of 3.