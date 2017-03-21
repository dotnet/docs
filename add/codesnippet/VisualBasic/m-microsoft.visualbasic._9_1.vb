        Dim firstDate, secondDate As Date
        Dim timeOnly, dateAndTime, noDate As String
        Dim dateCheck As Boolean
        firstDate = CDate("February 12, 1969")
        secondDate = #2/12/1969#
        timeOnly = "3:45 PM"
        dateAndTime = "March 15, 1981 10:22 AM"
        noDate = "Hello"
        dateCheck = IsDate(firstDate)
        dateCheck = IsDate(secondDate)
        dateCheck = IsDate(timeOnly)
        dateCheck = IsDate(dateAndTime)
        dateCheck = IsDate(noDate)