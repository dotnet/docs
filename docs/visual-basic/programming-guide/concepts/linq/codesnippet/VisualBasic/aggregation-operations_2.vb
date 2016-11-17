
        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim highTemps As Integer = Aggregate temp In temperatures Into Count(temp >= 80)

        ' Display the result.
        MsgBox(highTemps)

        ' This code produces the following output:

        ' 3
