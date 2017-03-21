        Dim lowest, bigArray(10, 15, 20), littleArray(6) As Integer
        lowest = LBound(bigArray, 1)
        lowest = LBound(bigArray, 3)
        lowest = LBound(littleArray)
        ' All three calls to LBound return 0.