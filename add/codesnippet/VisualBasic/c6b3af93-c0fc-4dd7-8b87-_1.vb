        Dim TestDebt As Double = -4456.43
        Dim TestString As String
        ' Returns "($4,456.43)".
        TestString = FormatCurrency(TestDebt, , , TriState.True, TriState.True)