        Dim highest, bigArray(10, 15, 20), littleArray(6) As Integer
        highest = UBound(bigArray, 1)
        highest = UBound(bigArray, 3)
        highest = UBound(littleArray)
        ' The three calls to UBound return 10, 20, and 6 respectively.