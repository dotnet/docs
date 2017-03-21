        Dim DateString, Msg As String
        Dim ActualDate As Date
        ' Enter February 12, 2008, or 2/12/2008.
        DateString = InputBox("Enter a date:")
        ActualDate = CDate(DateString)

        ' The first two examples use enumeration values for the interval.
        Msg = "Quarter: " & DatePart(DateInterval.Quarter, ActualDate)
        ' The quarter is 1.
        MsgBox(Msg)
        Msg = "The day of the month: " & DatePart(DateInterval.Day, ActualDate)
        ' The day of the month is 12.
        MsgBox(Msg)

        ' The next two examples use string values for the interval parameter.
        Msg = "The week of the year: " & DatePart("ww", ActualDate)
        ' The week of the year is 7.
        MsgBox(Msg)
        Msg = "The day of the week: " & DatePart("w", ActualDate)
        ' The day of the week is 3 (Tuesday).
        MsgBox(Msg)