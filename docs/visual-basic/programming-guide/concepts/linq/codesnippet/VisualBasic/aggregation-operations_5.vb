
        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim minTemp = Aggregate temp In temperatures Into Min()

        ' Display the result.
        MsgBox(minTemp)

        ' This code produces the following output:

        ' 68.5
