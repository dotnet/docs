
        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim maxTemp = Aggregate temp In temperatures Into Max()

        ' Display the result.
        MsgBox(maxTemp)

        ' This code produces the following output:

        ' 88.6
