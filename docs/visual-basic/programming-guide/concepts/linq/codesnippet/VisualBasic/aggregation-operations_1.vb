
        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim avg = Aggregate temp In temperatures Into Average()

        ' Display the result.
        MsgBox(avg)

        ' This code produces the following output:

        ' 76.65
