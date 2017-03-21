        Dim dateEntered As String =
        InputBox("Enter a date", DefaultResponse:=Date.Now.ToShortDateString)
        Dim monthsEntered As String =
        InputBox("Enter number of months to add", DefaultResponse:="12")

        Dim dateValue As Date = Date.Parse(dateEntered)
        Dim monthsValue As Integer = Integer.Parse(monthsEntered)

        ' Add the months to the date.
        Dim newDate As Date = DateAdd(DateInterval.Month, monthsValue, dateValue)

        ' This statement has a string interval argument, and
        ' is equivalent to the above statement.
        'Dim newDate As Date = DateAdd("m", monthsValue, dateValue)

        MessageBox.Show("New date: " & newDate.ToShortDateString)