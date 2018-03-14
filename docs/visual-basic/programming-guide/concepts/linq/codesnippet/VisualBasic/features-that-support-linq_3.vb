        ' Query example.
        ' If numbers is a one-dimensional array of integers, num will be typed
        ' as an integer and numQuery will be typed as IEnumerable(Of Integer)--
        ' basically a collection of integers.

        Dim numQuery = From num In numbers
                       Where num Mod 2 = 0
                       Select num