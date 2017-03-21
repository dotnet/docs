        ' DateSerial returns the date for a specified year, month, and day.
        Dim aDate As Date
        ' Variable aDate contains the date for February 12, 1969.
        aDate = DateSerial(1969, 2, 12)
        Console.WriteLine(aDate)

        ' The following example uses DateSerial to determine and display
        ' the last day of the previous month.
        ' First, establish a starting date.
        Dim startDate = #1/23/1994#
        ' The 0 for the day represents the last day of the previous month.
        Dim endOfLastMonth = DateSerial(startDate.Year, startDate.Month, 0)
        Console.WriteLine("Last day in the previous month: " & endOfLastMonth)

        ' The following example finds and displays the day of the week that the 
        ' 15th day of the following month will fall on.
        Dim fifteenthsDay = DateSerial(Today.Year, Today.Month + 1, 15)
        Console.WriteLine("The 15th of next month is a {0}", fifteenthsDay.DayOfWeek)