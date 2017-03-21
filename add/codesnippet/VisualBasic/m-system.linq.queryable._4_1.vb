        Dim longs As New List(Of Long)(New Long() {4294967296L, 466855135L, 81125L})

        Dim max As Long = longs.AsQueryable().Max()

        MsgBox(String.Format("The largest number is {0}.", max))

        'This code produces the following output:

        'The largest number is 4294967296.
