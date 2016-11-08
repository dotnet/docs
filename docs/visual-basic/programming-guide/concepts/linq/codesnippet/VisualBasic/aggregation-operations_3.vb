
        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim numTemps As Long = Aggregate temp In temperatures Into LongCount()

        ' Display the result.
        MsgBox(numTemps)

        ' This code produces the following output:

        ' 6
