
        Dim expenses() As Double = {560.0, 300.0, 1080.5, 29.95, 64.75, 200.0}

        Dim totalExpense = Aggregate expense In expenses Into Sum()

        ' Display the result.
        MsgBox(totalExpense)

        ' This code produces the following output:

        ' 2235.2
